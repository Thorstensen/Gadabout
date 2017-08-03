using Gadabout.Server.Core.Contract;
using Gadabout.Server.Core.Infrastructure.Modules;
using System.ComponentModel.Composition;
using Autofac;
using Gadabout.Server.Core;
using Gadabout.Server.Core.Infrastructure.Logging;
using Gadabout.Server.Core.Repository;
using Gadabout.Server.Core.Security;

namespace Gadabout.Server.CoreModule
{
    [Export(typeof(IServerModule))]
    public class CoreModule : BaseServerModule
    {
        public override string ModuleName => "Gadabout Server Core Module";

        public override void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterModule(new DatabaseModule());

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CryptoService>().As<ICryptoService>();
            builder.RegisterType<PasswordManager>().As<IPasswordManager>();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
        }

        public override void StartModule()
        {
            ConsoleLogger.Log("Initializing Database Layer");
            DatabaseModule.InitializeDatabase(Container);
            ConsoleLogger.Log("Database Layer initialization done", LogLevel.Trace);
        }

        public override void StopModule()
        {
            
        }
    }
}
