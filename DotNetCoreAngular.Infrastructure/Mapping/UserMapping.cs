using AutoMapper;
using DotNetCoreAngular.Application.ViewModels;
using DotNetCoreAngular.Domain.Entities;

namespace DotNetCoreAngular.Infrastructure.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, RegisterModel>();
            CreateMap<RegisterModel, User>();
        }
    }
}
