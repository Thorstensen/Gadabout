using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Data
{
    public class User : RootEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalityIso3Code { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Trip> PerformedTrips { get; set; }
    }
}
