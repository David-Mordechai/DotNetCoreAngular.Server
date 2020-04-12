using DotNetCoreAngular.Application.DataServices;
using System.Linq;

namespace DotNetCoreAngular.Persistence.DataServices
{
    public class RegisterValidatorDataService : IRegisterValidatorDataService
    {
        private readonly DotNetCoreAngularDbContext _dbContext;

        public RegisterValidatorDataService(DotNetCoreAngularDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool UniqueEmail(string email)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Email == email);
            return user == null;
        }

        public bool UniqueUsername(string username)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Username == username);
            return user == null;
        }
    }
}
