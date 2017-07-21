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

        public GeneratedPasswordResult GeneratePassword(string providedPassword)
        {
            var salt = _cryptoService.GetSalt();
            var hash = _cryptoService.GetHash(providedPassword, salt);

            return new GeneratedPasswordResult(hash, salt);
        }

        public bool VerifyPassword(string providedPassword, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, hash);
        }
    }
}
