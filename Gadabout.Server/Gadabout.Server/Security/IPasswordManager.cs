using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Security
{
    public interface IPasswordManager
    {
        string GeneratePassword(string plainText, out string salt);
        bool VerifyPassword(string hash, string salt, string providedPassword);
    }
}
