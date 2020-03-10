using System;
using System.Linq;
using BakeryApi.Models.Enum;
using BakeryApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BakeryApi.Helpers
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(params RoleEnum[] roles) : base(typeof(CustomAuthorizeFilter))
        {
            Arguments = new object[] { roles };
        }
    }
    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        private readonly IUserRepository _userRepository;
        private readonly RoleEnum[] _roles;

        public CustomAuthorizeFilter(IUserRepository userRepository, RoleEnum[] roles)
        {
            _userRepository = userRepository;
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Allow Anonymous skips all authorization
            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                return;
            }

            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            if (!_userRepository.CheckUserAccess(Convert.ToInt32(user.Identity.Name), _roles).Result)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }

}
