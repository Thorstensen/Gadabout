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
            return _cryptoService.GetHash(providedPassword, salt);
        }

        public bool VerifyPassword(string providedPassword, string hash)
        {
            var testableHash = _cryptoService.GetHash(providedPassword, hash);
            return BCrypt.Net.BCrypt.Verify(providedPassword, hash);
        }

        private string AddSalt(string salt, string password)
        {
            return salt + password;
        }
    }
}
