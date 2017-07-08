using Gadabout.Server.Core.Contract;
using Gadabout.Server.Core.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Gadabout.Server.Core.Database;
using Gadabout.Server.Core;
using Gadabout.Server.Core.Infrastructure.Logging;
using Gadabout.Server.Core.Repository;

namespace Gadabout.Server.CoreModule
{
    [Export(typeof(IServerModule))]
    public class CoreModule : BaseServerModule
    {
        public override string ModuleName => "Gadabout Server Core Module";

        public override void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterModule(new DatabaseModule());
            builder.RegisterType<EntityRepository>().As<IEntityRepository>();
        }

        public override void StartModule()
        {
            ConsoleLogger.Log("Initializing Database Layer");
            DatabaseModule.InitializeDatabase(Container);
            ConsoleLogger.Log("Database Layer initialization done", System.Drawing.Color.Green);
        }

        public override void StopModule()
        {
            
        }
    }
}
