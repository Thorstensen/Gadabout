using Autofac;
using Autofac.Integration.Mef;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition.Primitives;
using Gadabout.Server.Infrastructure;
using Gadabout.Server.Contracts;

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

        private static ComposablePartCatalog GetComposableCatalog()
        {
            var modulesPath = Assembly.GetExecutingAssembly().GetModulesLocation();
            var catalog = new DirectoryCatalog(modulesPath);

            return catalog;
        }

        public void Stop()
        {
            Console.WriteLine("Stopping Gadabout Server Application");
        }
    }
}
