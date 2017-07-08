using Gadabout.Server.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Core.Database
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("Data Source=localhost;Initial Catalog=Gadabout;Integrated Security=True")
        {

        }

        DbSet<User> Users { get; set; }
        DbSet<Trip> Trips { get; set; }
        DbSet<Destination> Destinations { get; set; }
        DbSet<Attraction>  Attractions { get; set; } 


        
    }
}
