using Autofac;
using Autofac.Integration.Mef;
using Gadabout.Server.Core.Contract;
using Gadabout.Server.Core.Infrastructure;
using Gadabout.Server.Core.Infrastructure.Logging;
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
        private List<IServerModule> _modules = null;
        private ContainerBuilder _containerBuilder = new ContainerBuilder();

        public IContainer Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterComposablePartCatalog(GetComposableCatalog());

            using (var container = containerBuilder.Build())
            {
                _modules = container.Resolve<IEnumerable<IServerModule>>().ToList();

                _modules.ForEach(module =>
                {
                    ConsoleLogger.Log($"Loading module {module.ModuleName}", LogLevel.Trace);
                    module.RegisterTypes(_containerBuilder);
                });
            }

            var builtContainer = _containerBuilder.Build();

            foreach(var module in _modules.OrderBy(p => p.InitializationPreference))
            {
                module.SetContainer(builtContainer);
                module.StartModule();
            }

            return builtContainer;
        }

        private static ComposablePartCatalog GetComposableCatalog()
        {
            var modulesPath = Assembly.GetExecutingAssembly().GetModulesLocation();
            return new DirectoryCatalog(modulesPath);
        }
    }
}
