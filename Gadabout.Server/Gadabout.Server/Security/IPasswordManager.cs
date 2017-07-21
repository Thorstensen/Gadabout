using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Security
{
    public interface IPasswordManager
    {
        GeneratedPasswordResult GeneratePassword(string plainText);
        bool VerifyPassword(string providedPassword, string hash);
    }
}
