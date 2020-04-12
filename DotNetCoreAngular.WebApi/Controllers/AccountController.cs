using System.Threading.Tasks;
using DotNetCoreAngular.Application.Services;
using DotNetCoreAngular.Application.Validators;
using DotNetCoreAngular.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreAngular.WebApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IRegisterValidator _registerValidator;

        public AccountController(IAccountService accountService, IRegisterValidator registerValidator)
        {
            _accountService = accountService;
            _registerValidator = registerValidator;
        }

        [HttpPost, Route("signup")]
        public async Task<IActionResult> Signup([FromBody]RegisterModel model)
        {
            if (!_registerValidator.Validate(model)) return StatusCode(409);

            await _accountService.AddUser(model);

            return Ok();
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            var (token, refreshToken) = await _accountService.Login(model);
            if (string.IsNullOrEmpty(token)) return BadRequest();

            return new ObjectResult(new
            {
                token,
                refreshToken
            });
        }

        [HttpGet, Authorize, Route("getuserdetails")]
        public async Task<IActionResult> GetUserDetails()
        {
            var username = User.Identity.Name;
            string userFullName = await _accountService.GetUserFullName(username);
            
            if (string.IsNullOrEmpty(userFullName)) return BadRequest();
            
            return Ok(new { userFullName });
        }

        [HttpGet, Route("isUsernameUnique")]
        public IActionResult IsUsernameUnique(string username)
        {
            return Ok(_registerValidator.UniqueUsername(username));
        }

        [HttpGet, Route("isEmailUnique")]
        public IActionResult IsEmailUnique(string email)
        {
            return Ok(_registerValidator.UniqueEmail(email));
        }
    }
}