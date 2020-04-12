using DotNetCoreAngular.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DotNetCoreAngular.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSettingsController : ControllerBase
    {
        private readonly ILogger<UserSettingsController> _logger;
        private readonly IUserSettingsService _userSettingsService;

        public UserSettingsController(ILogger<UserSettingsController> logger, IUserSettingsService userSettingsService)
        {
            _logger = logger;
            _userSettingsService = userSettingsService;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetUserTheme()
        {
            _logger.LogInformation("Controller GetUserTheme was hit...");
            var user = User?.Identity?.Name;
            if (user == null) return Ok(0);

            var result = _userSettingsService.GetUserTheme(user);
            return Ok(result);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public IActionResult SaveUserTheme([FromBody]int themeType)
        {
            var user = User?.Identity?.Name;
            _logger.LogInformation("Controller SaveUserTheme was hit by {user}", user);
            _userSettingsService.SaveUserTheme(user, themeType);
            return Ok();
        }
    }
}