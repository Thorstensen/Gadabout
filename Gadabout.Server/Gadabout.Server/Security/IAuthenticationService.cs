using Gadabout.Server.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Security
{
    public interface IAuthenticationService
    {
        void RegisterUser(User user);
        bool UserExists(string userName);
        bool AuthenticateUser(string userName, string password);
    }
}
