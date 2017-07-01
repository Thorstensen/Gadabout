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

namespace Gadabout.Server.Host
{
    public class GadaboutApp
    {
        private static IContainer Container { get; set; }
        
        public void Start()
        {
            var mefContainer = new CatalogConfigurator()
                                .AddAssembly(Assembly.GetExecutingAssembly())
                                .AddDirectory("Modules")
                                .BuildContainer();

            Container = Bootstrap.Initialize(mefContainer);
        }

        public void Stop()
        {
            Console.WriteLine("Stopping Gadabout Server Application");
        }
    }
}
