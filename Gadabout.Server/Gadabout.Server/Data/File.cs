using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Data
{
    public class File : RootEntity
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public byte[] Data { get; set; }

        public Guid AttractionId { get; set; }
        public virtual Attraction Attraction { get; set; }
      
    }
}
