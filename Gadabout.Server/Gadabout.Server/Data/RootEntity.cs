using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Data
{
    public class RootEntity
    {
        public RootEntity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        DateTime CreatedTime { get; set; }
        public byte[] Version { get; set; }
    }
}
