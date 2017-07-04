using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Data
{
    public class Trip : RootEntity
    {
        public List<Destination> VisitedDestinations { get; set; }
    }
}
