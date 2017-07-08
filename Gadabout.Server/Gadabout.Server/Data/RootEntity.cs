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
        [Key]
        public long Id { get; set; }
        DateTime CreatedTime { get; set; }
        public byte[] Version { get; set; }
    }
}
