using Gadabout.Server.Core.Contract;
using Gadabout.Server.Core.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Gadabout.Server.CoreModule
{
    [Export(typeof(IServerModule))]
    public class CoreModule : BaseServerModule
    {
        public override string ModuleName => "Gadabout Server Core Module";

        public override void RegisterTypes(ContainerBuilder builder)
        {
           
        }

        public override void StartModule()
        {
          
        }

        public override void StopModule()
        {
            
        }
    }
}
