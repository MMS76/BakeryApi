using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BakeryApi.Helpers;
using BakeryApi.Models.Data;
using BakeryApi.Models.Enum;
using BakeryApi.Models.ViewModel;
using BakeryApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BakeryApi.Repository.Implement
{
    public class UserRepository: IUserRepository
    {
        private readonly BakeryContext _context;
        private readonly SmsHelper _smsHelper;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public UserRepository(BakeryContext context, SmsHelper smsHelper, JwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _smsHelper = smsHelper;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<bool> SignInStepOne(SignInStepOneViewModel model)
        {
            var phone = model.PhoneNumber.Trim().ToNormalPhoneNumber();
            Random rnd = new Random();
            var code = rnd.Next(100000, 999999).ToString();
            if (!await _context.Users.AnyAsync(w => w.PhoneNumber == phone))
            {
                var userAdd=new User
                {
                    PhoneNumber = phone,
                    RoleEnum = (int)RoleEnum.User,
                    SecurityCode = code,
                    SecurityCodeExpiration = DateTime.Now.AddMinutes(3)
                };
                _context.Users.Add(userAdd);
                await _context.SaveChangesAsync();
            }
            else
            {
                var user = await _context.Users.FirstOrDefaultAsync(w => w.PhoneNumber == phone);
                user.SecurityCode = code;
                user.SecurityCodeExpiration = DateTime.Now.AddMinutes(3);
                await _context.SaveChangesAsync();
            }

            //ارسال کد فعالسازی از طریق پیامک
            return _smsHelper.SendSecurityCode(phone, code);
        }

        public async Task<SignInResultViewModel> SignInStepTwo(SignInStepTwoViewModel model)
        {
            var phone = model.PhoneNumber.Trim().ToNormalPhoneNumber();
            var code = model.SecurityCode.Trim().ToNormalNumber();

            var user = await _context.Users.FirstOrDefaultAsync(w => w.PhoneNumber == phone);
            if (user == null)
            {
                throw new Exception("کاربر مورد نظر یافت نشد");
            }

            if ((user.SecurityCode != code) ||
                (user.SecurityCode == code && user.SecurityCodeExpiration < DateTime.Now))
            {
                throw new Exception("کد وارد شده معتبر نیست");
            }

            return new SignInResultViewModel
            {
                PhoneNumber = phone,
                FullName = user.FullName,
                RoleEnum = user.RoleEnum,
                RoleTitle = ((RoleEnum)user.RoleEnum).GetEnumName(),
                Token = _jwtTokenGenerator.GenerateToken(user.Id,true)
            };
        }

        public async Task<bool> CheckUserAccess(long userId, RoleEnum[] roles)
        {
            if (roles.Contains(RoleEnum.Admin))
            {
                return true;
            }

            if (!roles.Any())
            {
                return true;
            }

            return await _context.Users
                .AnyAsync(x => x.Id == userId &&
                               roles.Contains((RoleEnum)x.RoleEnum));
        }
    }
}
