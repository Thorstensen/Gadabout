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
        public string GetHash(string plain)
        {
            return BCrypt.Net.BCrypt.HashPassword(plain);
        }

        public string GetSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt();
        }
    }
}
