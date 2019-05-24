using DotNetCore.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotNetCore.Logging.Tests
{
    [TestClass]
    public class SecurityTests
    {
        public SecurityTests()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ICriptography>(_ => new Criptography(Guid.NewGuid().ToString()));

            Criptography = services.BuildServiceProvider().GetService<ICriptography>();
        }

        private ICriptography Criptography { get; }

        [TestMethod]
        public void Encrypt_Decrypt()
        {
            const string value = nameof(SecurityTests);

            var crypt = Criptography.Encrypt(value);

            var decrypt = Criptography.Decrypt(crypt);

            Assert.AreEqual(value, decrypt);
        }
    }
}
