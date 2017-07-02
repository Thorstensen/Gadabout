using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Host
{
    public sealed class Bootstrap
    {
        private static readonly object _lockObject = new object();
        private static Bootstrap _instance;
            
        [ImportMany(typeof(IModule))]
        internal IModule[] Modules { get; set; }
      
        private Bootstrap()
        {
        }
       
        public static IContainer Initialize(CompositionContainer container)
        {
            return Initialize(container, false);
        }
        public static IContainer Initialize(CompositionContainer container, bool resetSingleton)
        {
            Bootstrap bootStrap = null;
            ContainerBuilder builder = new ContainerBuilder();

            lock (_lockObject)
            { 
                if (resetSingleton || _instance == null)
                {
                    bootStrap = new Bootstrap();
                    container.SatisfyImportsOnce(bootStrap);
                  
                    _instance = bootStrap;
                }
               
                bootStrap = _instance;
            }

            bootStrap.Modules.ToList().ForEach(module =>
            {
                builder.RegisterModule(module);
            });

       
            return builder.Build();
        }
    }
}
