namespace DotNetCoreAngular.Application.DataServices
{
    public interface IRegisterValidatorDataService
    {
        bool UniqueUsername(string username);
        bool UniqueEmail(string email);
    }
}
