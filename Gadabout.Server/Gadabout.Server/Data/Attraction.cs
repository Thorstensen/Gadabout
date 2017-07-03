using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Data
{
    public class Attraction : RootEntity
    {
        public string Name { get; set; }
        public long Longitude { get; set; }
        public long Latitude { get; set; }
    }
}
