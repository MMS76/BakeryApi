using System;
using System.Threading.Tasks;
using BakeryApi.Helpers;
using BakeryApi.Models.Response;
using BakeryApi.Models.ViewModel;
using BakeryApi.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BakeryApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{v:apiVersion}/Accounts")]
    [ApiController]
    public class AccountController : BaseApi
    {
        private readonly ILogger<AccountController> _logger;
        private readonly Result _result;
        private readonly IUserRepository _userRepository;

        public AccountController(ILogger<AccountController> logger, IUserRepository userRepository, Result result)
        {
            _logger = logger;
            _userRepository = userRepository;
            _result = result;
        }

        [HttpPost("SignIn/StepOne")]
        public async Task<IActionResult> SingInStepOne([FromBody] SignInStepOneViewModel model)
        {
            try
            {
                var result = await _userRepository.SignInStepOne(model);
                return Ok(_result.SetSuccess(result));
            }
            catch (Exception ex)
            {
                return BadRequest(_result.SetBadRequest(ex));
            }
        }

        [HttpPost("SignIn/StepTwo")]
        public async Task<IActionResult> SingInStepTwo([FromBody] SignInStepTwoViewModel model)
        {
            try
            {
                var result = await _userRepository.SignInStepTwo(model);
                return Ok(_result.SetSuccess(result));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequest(_result.SetBadRequest(ex));
            }
        }

        [CustomAuthorize]
        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            return Ok("تست");
        }
    }
}