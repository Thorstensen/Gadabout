using Autofac;
using Autofac.Integration.Mef;
using Gadabout.Server.Contracts;
using Gadabout.Server.Infrastructure;
using Gadabout.Server.Infrastructure.Logging;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;

namespace Gadabout.Server.Host
{
    public sealed class Bootstrap
    {
        public IContainer Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterComposablePartCatalog(GetComposableCatalog());

            var container = containerBuilder.Build();
            var modules = container.Resolve<IEnumerable<IServerModule>>();

            foreach (var module in modules)
            {
                ConsoleLogger.Log($"Loading module {module.ModuleName}", System.Drawing.Color.Green);
                module.RegisterTypes(containerBuilder);
                module.StartModule();
            }

            return container;
        }

        private static ComposablePartCatalog GetComposableCatalog()
        {
            var modulesPath = Assembly.GetExecutingAssembly().GetModulesLocation();
            var catalog = new DirectoryCatalog(modulesPath);

            return catalog;
        }
    }
}
