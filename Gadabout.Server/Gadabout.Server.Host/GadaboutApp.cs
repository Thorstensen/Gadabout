using Autofac;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.ComponentModel.Composition.Primitives;
using Gadabout.Server.Infrastructure;

namespace Gadabout.Server.Host
{
    public class GadaboutApp
    {
        private static IContainer Container { get; set; }

        public void Start()
        {
            var bootstrapper = new Bootstrap();
            Container = bootstrapper.Initialize();
        }

        public void Stop()
        {
            Console.WriteLine("Stopping Gadabout Server Application");
        }

        private static ComposablePartCatalog GetComposableCatalog()
        {
            var modulesPath = Assembly.GetExecutingAssembly().GetModulesLocation();
            return new DirectoryCatalog(modulesPath);
        }
    }
}
