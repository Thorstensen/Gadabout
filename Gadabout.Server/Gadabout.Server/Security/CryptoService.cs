using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Security
{
    public class CryptoService : ICryptoService
    {
        public string GetHash(string plain, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(plain, salt);
        }

        public string GetSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }
    }
}
