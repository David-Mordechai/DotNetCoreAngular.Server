using DotNetCoreAngular.Application.DataServices;
using DotNetCoreAngular.Application.Validators;
using DotNetCoreAngular.Application.ViewModels;

namespace DotNetCoreAngular.Infrastructure.Validators
{
    public class RegisterValidator : IRegisterValidator
    {
        private readonly IRegisterValidatorDataService _registerValidatorDataService;

        public RegisterValidator(IRegisterValidatorDataService registerValidatorDataService)
        {
            _registerValidatorDataService = registerValidatorDataService;
        }

        public bool Validate(RegisterModel registerModel)
        {
            return RequiredFields(registerModel) &&
              UniqueUsername(registerModel.UserName) &&
              UniqueEmail(registerModel.Email) &&
              PasswordLength(registerModel.Password);
        }

        private bool RequiredFields(RegisterModel registerModel)
        {
            if (string.IsNullOrEmpty(registerModel.UserName))
                return false;

            if (string.IsNullOrEmpty(registerModel.Password))
                return false;

            if (string.IsNullOrEmpty(registerModel.Email))
                return false;

            if (string.IsNullOrEmpty(registerModel.FirstName))
                return false;

            if (string.IsNullOrEmpty(registerModel.LastName))
                return false;

            return true;
        }

        public bool UniqueUsername(string username)
        {
            return _registerValidatorDataService.UniqueUsername(username);
        }

        public bool UniqueEmail(string email)
        {
            return _registerValidatorDataService.UniqueEmail(email);
        }

        public bool PasswordLength(string password)
        {
            return password.Length >= 6;
        }
    }
}
