using DotNetCoreAngular.Application.ViewModels;
using DotNetCoreAngular.Domain.Entities;
using System.Threading.Tasks;

namespace DotNetCoreAngular.Application.Services
{
    public interface IAccountService
    {
        Task AddUser(RegisterModel model);
        Task<(string token, string refreshToken)> Login(LoginModel model);
        Task<string> GetUserFullName(string username);
        Task<(string token, string refershToken, bool isExpired)> Refresh(TokensModel model);
        Task<User> Revoke(string username);
    }
}
