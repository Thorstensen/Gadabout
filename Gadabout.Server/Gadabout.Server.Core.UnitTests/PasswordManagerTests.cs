using FakeItEasy;
using Gadabout.Server.Core.Data;
using Gadabout.Server.Core.Repository;
using Gadabout.Server.Core.Security;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.UnitTests
{
    [TestFixture]
    public class PasswordManagerTests
    {
        [Test]
        public void VerifyPassword_ShouldReturnTrue()
        {
            const string PlainPassword = "TestP@ssw0rd";
            string salt = string.Empty;

            var passwordManager = new PasswordManager(new CryptoService());
            var hashedPassword = passwordManager.GeneratePassword(PlainPassword, out salt);
            Assert.IsTrue(passwordManager.VerifyPassword(PlainPassword, hashedPassword));
        }


        [Test]
        public void VerifyPassword_ShouldReturnFalse()
        {
            var passwordManager = new PasswordManager(new CryptoService());
            string salt = string.Empty;
            var hashedPassword = passwordManager.GeneratePassword("Somepassword", out salt);
            Assert.IsFalse(passwordManager.VerifyPassword("someOtHerPassW0rd", hashedPassword));
        }
    }
}
