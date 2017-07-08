using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Data
{
    public class Trip : RootEntity
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ICollection<Destination> VisitedDestinations { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

    }
}
