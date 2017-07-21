using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Security
{
    public class GeneratedPasswordResult
    {
        public GeneratedPasswordResult(string hash, string salt)
        {
            Hash = hash;
            Salt = salt;
        }

        public string Hash { get; private set; }
        public string Salt { get; private set; }
    }
}
