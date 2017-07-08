using Gadabout.Server.Core.Contract;
using Gadabout.Server.Core.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Gadabout.Server.NancyHosting.Module;

namespace Gadabout.Server.Nancy.Services.Module
{
    [Export(typeof(IServerModule))]
    public class ServiceModule : BaseServerModule
    {
        public override string ModuleName => "Nancy Service Discovery Module";

        public override void RegisterTypes(ContainerBuilder builder)
        {
            
        }

        public override void StartModule()
        {
           // var nancyBootStrapper = Container.Resolve<NancyHostBootstrapper>();  
        }

        public override void StopModule()
        {
          
        }
    }
}
