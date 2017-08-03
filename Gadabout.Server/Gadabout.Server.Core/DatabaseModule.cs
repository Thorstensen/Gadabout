using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Gadabout.Server.Core.Database;

namespace Gadabout.Server.Core
{
    public class DatabaseModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<DataContext>().As<IDataContext>();
        }

        public static void InitializeDatabase(ILifetimeScope lifeTimeScope)
        {
            using (var ctx = (DataContext)lifeTimeScope.Resolve<IDataContext>())
            {
                var initializer = new DatabaseInitializer();
                initializer.InitializeDatabase(ctx);
                ctx.Users.Count();
            }
        }
    }
}
