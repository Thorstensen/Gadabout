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
        private const int _saltLength = 32;

        
        public string GenerateSalt()
        {
            using(var provider = new RNGCryptoServiceProvider())
            {
                var salt = new byte[_saltLength];
                provider.GetNonZeroBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }
    }
}
