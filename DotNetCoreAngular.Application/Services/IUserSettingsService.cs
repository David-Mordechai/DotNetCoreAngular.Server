namespace DotNetCoreAngular.Application.Services
{
    public interface IUserSettingsService
    {
        int GetUserTheme(string user);
        void SaveUserTheme(string user, int themeType);
    }
}
