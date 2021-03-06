﻿using FakeItEasy;
using Gadabout.Server.Core.Data;
using Gadabout.Server.Core.Repository;
using Gadabout.Server.Core.Security;
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
           
            var passwordManager = new PasswordManager(new CryptoService());
            var hashResult = passwordManager.GeneratePassword(PlainPassword);
            Assert.IsTrue(passwordManager.VerifyPassword(PlainPassword, hashResult.Hash));
        }


        [Test]
        public void VerifyPassword_ShouldReturnFalse()
        {
            var passwordManager = new PasswordManager(new CryptoService());
            var hashResult = passwordManager.GeneratePassword("Somepassword");
            Assert.IsFalse(passwordManager.VerifyPassword("someOtHerPassW0rd", hashResult.Hash));
        }
    }
}
