using DotNetCoreAngular.Application.DataServices;
using DotNetCoreAngular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DotNetCoreAngular.Persistence.DataServices
{
    public class UserSettingsDataService : IUserSettingsDataService
    {
        private readonly DotNetCoreAngularDbContext _dbContext;

        public UserSettingsDataService(DotNetCoreAngularDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUser(string userName)
        {
            return _dbContext.Users.Include(x => x.UserExtensions).FirstOrDefault(x => x.Username == userName);
        }

        public int GetUserTheme(string userName)
        {
            var user = GetUser(userName);
            return (user == null || user.UserExtensions == null) ? 0 : user.UserExtensions.Theme;
        }

        public void SaveUserTheme(string userName, int themeType)
        {
            var user = GetUser(userName);

            if (user.UserExtensions != null)
            {
                user.UserExtensions.Theme = themeType;
                _dbContext.SaveChanges();
                return;
            }

            user.UserExtensions = new UserExtensions { UserId = user.Id, Theme = themeType };
            _dbContext.SaveChanges();
        }
    }
}
