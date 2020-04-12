using DotNetCoreAngular.Application.Auth;
using DotNetCoreAngular.Application.DataServices;
using DotNetCoreAngular.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DotNetCoreAngular.Persistence.DataServices
{
    public class AccountDataService : IAccountDataService
    {
        private readonly DotNetCoreAngularDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;

        public AccountDataService(DotNetCoreAngularDbContext dbContext, IPasswordHasher passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public async Task AddUser(User user)
        {
            user.Password = _passwordHasher.GenerateIdentityV3Hash(user.Password);
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByUserName(string username)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
        }

        public Task<User> GetUserByUserNameOrEmail(string username)
        {
            return _dbContext.Users.SingleOrDefaultAsync(u => u.Username == username || u.Email == username);
        }

        public async Task Revoke(User user)
        {
            user.RefreshToken = null;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserRefreshToken(User user, string refreshToken, DateTime refreshTokenExpDate)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpDate = refreshTokenExpDate;
            await _dbContext.SaveChangesAsync();
        }
    }
}
