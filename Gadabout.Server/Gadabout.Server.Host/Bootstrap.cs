using Autofac;
using Autofac.Integration.Mef;
using Gadabout.Server.Contracts;
using Gadabout.Server.Infrastructure;
using Gadabout.Server.Infrastructure.Logging;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;
using System;

namespace Gadabout.Server.Host
{
    public sealed class Bootstrap
    {
        private IEnumerable<IServerModule> _modules = null;
        private IContainer _container = null;
        private ContainerBuilder _containerBuilder = new ContainerBuilder();

        public IContainer Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterComposablePartCatalog(GetComposableCatalog());

            using (var container = containerBuilder.Build())
            {
                var modules = container.Resolve<IEnumerable<IServerModule>>().ToList();

                modules.ForEach(module =>
                {
                    ConsoleLogger.Log($"Loading module {module.ModuleName}", System.Drawing.Color.Green);
                    module.RegisterTypes(_containerBuilder);
                    module.StartModule();
                });
            }

            return _containerBuilder.Build();
        }

        private static ComposablePartCatalog GetComposableCatalog()
        {
            var modulesPath = Assembly.GetExecutingAssembly().GetModulesLocation();
            var catalog = new DirectoryCatalog(modulesPath);

            return catalog;
        }
    }
}
