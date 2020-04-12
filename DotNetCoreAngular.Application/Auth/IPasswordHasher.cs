namespace DotNetCoreAngular.Application.Auth
{
    public interface IPasswordHasher
    {
        string GenerateIdentityV3Hash(string password);
        bool VerifyIdentityV3Hash(string password, string passwordHash);
    }
}
