using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Data
{
    public class RootEntity
    {
        DateTime CreatedTime { get; set; }
        public byte[] Version { get; set; }
    }
}
