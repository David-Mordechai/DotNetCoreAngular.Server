using DotNetCoreAngular.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace DotNetCoreAngular.Application.DataServices
{
    public interface IAccountDataService
    {
        Task AddUser(User user);
        Task<User> GetUserByUserNameOrEmail(string username);
        Task UpdateUserRefreshToken(User user, string refreshToken, DateTime refreshTokenExpDate);
        Task<User> GetUserByUserName(string username);
        Task Revoke(User user);
    }
}
