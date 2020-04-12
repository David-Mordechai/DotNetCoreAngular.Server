using DotNetCoreAngular.Domain.Entities;

namespace DotNetCoreAngular.Application.DataServices
{
    public interface IUserSettingsDataService
    {
        User GetUser(string userName);
        int GetUserTheme(string userName);
        void SaveUserTheme(string userName, int themeType);
    }
}
