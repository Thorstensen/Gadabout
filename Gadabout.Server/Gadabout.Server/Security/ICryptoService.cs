using Gadabout.Server.Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Security
{
    public interface ICryptoService
    {
        string GetSalt();
        string GetHash(string plain);
    }
}
