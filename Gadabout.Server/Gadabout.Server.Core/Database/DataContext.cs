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

        public DbSet<User> Users { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Attraction>  Attractions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Types().Configure(conventionConfiguration =>
            {
                if (typeof(RootEntity).IsAssignableFrom(conventionConfiguration.ClrType))
                {
                    conventionConfiguration.Property(nameof(RootEntity.Version)).IsRowVersion();
                }
            });
        }
    }
}
