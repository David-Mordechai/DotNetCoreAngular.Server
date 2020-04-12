using DotNetCoreAngular.Application.DataServices;
using DotNetCoreAngular.Application.Services;
using Microsoft.Extensions.Logging;

namespace DotNetCoreAngular.Infrastructure.Services
{
    public class UserSettingsService : IUserSettingsService
    {
        private readonly ILogger<UserSettingsService> _logger;
        private readonly IUserSettingsDataService _userSettingsDataService;

        public UserSettingsService(ILogger<UserSettingsService> logger, IUserSettingsDataService userSettingsDataService)
        {
            _logger = logger;
            _userSettingsDataService = userSettingsDataService;
        }
        public int GetUserTheme(string userName)
        {
            _logger.LogInformation("Service GetUserTheme was hit");

            return _userSettingsDataService.GetUserTheme(userName);
        }

        public void SaveUserTheme(string userName, int themeType)
        {
            _logger.LogInformation("Service SaveUserTheme was hit");

            _userSettingsDataService.SaveUserTheme(userName, themeType); 
        }
    }
}
