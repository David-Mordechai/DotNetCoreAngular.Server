using AutoMapper;
using DotNetCoreAngular.Application.Auth;
using DotNetCoreAngular.Application.DataServices;
using DotNetCoreAngular.Application.Services;
using DotNetCoreAngular.Application.ViewModels;
using DotNetCoreAngular.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCoreAngular.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountDataService _accountDataService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AccountService(IAccountDataService accountDataService, IPasswordHasher passwordHasher, 
            ITokenService tokenService, IConfiguration configuration, IMapper mapper)
        {
            _accountDataService = accountDataService;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _configuration = configuration;
            _mapper = mapper;
        }

        public Task AddUser(RegisterModel model)
        {
            return _accountDataService.AddUser(_mapper.Map<RegisterModel, User>(model));
        }

        public async Task<string> GetUserFullName(string username)
        {
            var user = await _accountDataService.GetUserByUserName(username);
            
            if (user == null) return null;

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<(string token, string refreshToken)> Login(LoginModel model)
        {
            var user = await _accountDataService.GetUserByUserNameOrEmail(model.UserName);
           
            if (user == null || !_passwordHasher.VerifyIdentityV3Hash(model.Password, user.Password)) return (null, null);

            var usersClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var jwtToken = _tokenService.GenerateAccessToken(usersClaims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            var refreshTokenExpDate = DateTime.Now.AddMinutes(
              int.Parse(_configuration["Jwt:RefreshTokenDurationInMinutes"]));
            
            await _accountDataService.UpdateUserRefreshToken(user, refreshToken, refreshTokenExpDate);
            
            return (jwtToken, refreshToken);
        }
    }
}
