namespace DotNetCore.AspNetCore
{
    public interface IDataProtectionService
    {
        string Hash(string value);

        string Protect(string value);

        string Unprotect(string value);
    }
}
