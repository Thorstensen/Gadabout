using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Data
{
    public class Destination : RootEntity
    {
        public string DestinationName { get; set; }
        public DateTime DateVisited { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public List<Attraction> Attractions { get; set; }

        public virtual Trip Trip { get; set; }
    }
}
