using DotNetCoreAngular.Application.ViewModels;
using System.Threading.Tasks;

namespace DotNetCoreAngular.Application.Services
{
    public interface IAccountService
    {
        Task AddUser(RegisterModel model);
        Task<(string token, string refreshToken)> Login(LoginModel model);
        Task<string> GetUserFullName(string username);
    }
}
