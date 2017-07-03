using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Data
{
    public class User : RootEntity
    {
        public List<Trip> PerformedTrips { get; set; }
    }
}
