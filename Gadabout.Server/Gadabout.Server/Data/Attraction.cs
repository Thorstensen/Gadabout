using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Data
{
    public class Attraction : RootEntity
    {
        public string Name { get; set; }

        //Should probably be refactored to a blob-storage 
        public ICollection<File> Images { get; set; }

        public Guid DestinationId { get; set; }
        public virtual Destination Destination { get; set; }
    }
}
