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
            var builder = new ContainerBuilder();

            var modulesCatalog = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Modules";
            if (!Directory.Exists(modulesCatalog))
                Directory.CreateDirectory(modulesCatalog);

            var mefCatalog = new DirectoryCatalog(modulesCatalog, "*Module.dll");
            builder.RegisterComposablePartCatalog(mefCatalog);

            Container = builder.Build();
        }

        public void Stop()
        {
            Console.WriteLine("Stopping Gadabout Server Application");
        }
    }
}
