using System;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApi.Helpers
{
    //[ApiController]
    public class BaseApi : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public long UserId => !string.IsNullOrEmpty(User.Identity.Name) ? 
            Convert.ToInt64(User.Identity.Name)
            : 0;
    }
}