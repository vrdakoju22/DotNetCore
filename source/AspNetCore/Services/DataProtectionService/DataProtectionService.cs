using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Text;

namespace DotNetCore.AspNetCore
{
    public class DataProtectionService : IDataProtectionService
    {
        public DataProtectionService(IDataProtectionProvider provider)
        {
            Protector = provider.CreateProtector(nameof(DataProtectionService));
        }

        private IDataProtector Protector { get; }

        public string Hash(string value)
        {
            var salt = Encoding.UTF8.GetBytes(value);

            var bytes = KeyDerivation.Pbkdf2(value, salt, KeyDerivationPrf.HMACSHA512, 10000, 256);

            return Convert.ToBase64String(bytes);
        }

        public string Protect(string value)
        {
            return Protector.Protect(value);
        }

        public string Unprotect(string value)
        {
            return Protector.Unprotect(value);
        }
    }
}
