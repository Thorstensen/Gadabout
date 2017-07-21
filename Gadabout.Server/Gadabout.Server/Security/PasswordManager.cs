using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Security
{
    public class PasswordManager : IPasswordManager
    {
        private readonly ICryptoService _cryptoService;

        public PasswordManager(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }

        public string GeneratePassword(string providedPassword, out string salt)
        {
            salt = _cryptoService.GetSalt();
            return _cryptoService.GetHash(AddSalt(salt, providedPassword));
        }

        public bool VerifyPassword(string hash, string salt, string providedPassword)
        {
            var testableHash = _cryptoService.GetHash(AddSalt(salt, providedPassword));
            return BCrypt.Net.BCrypt.Verify(testableHash, hash);
        }

        private string AddSalt(string salt, string password)
        {
            return salt + password;
        }
    }
}
