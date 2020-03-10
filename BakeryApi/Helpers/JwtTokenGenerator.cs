using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BakeryApi.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class JwtTokenGenerator
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public JwtTokenGenerator(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// تولید توکن احراز هویت
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isRemember"></param>
        /// <returns></returns>
        public string GenerateToken(long userId, bool isRemember = false)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, userId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_config["Jwt:ExpireDays"]));

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}