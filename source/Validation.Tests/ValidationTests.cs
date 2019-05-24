using DotNetCore.Validation.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DotNetCore.Logging.Tests
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void Validate()
        {
            var validator = new FakeModelValidator();

            Assert.IsNotNull(validator.Valid(null).Message);

            Assert.IsNotNull(validator.Valid(new FakeModel()).Message);
        }
    }
}
