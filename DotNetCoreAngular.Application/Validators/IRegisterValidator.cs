using DotNetCoreAngular.Application.ViewModels;

namespace DotNetCoreAngular.Application.Validators
{
    public interface IRegisterValidator
    {
        bool UniqueEmail(string email);
        bool UniqueUsername(string username);
        bool PasswordLength(string password);
        bool Validate(RegisterModel registerModel);
    }
}
