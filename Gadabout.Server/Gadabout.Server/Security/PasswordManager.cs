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
        public string Hash(string password)
        {
            var sha512 = new SHA512CryptoServiceProvider();
            var bytes = Encoding.Default.GetBytes(password);
            var hashedValue = sha512.ComputeHash(bytes);

            return Encoding.Default.GetString(hashedValue);
        }
    }
}
