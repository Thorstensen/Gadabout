using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.ComponentModel.Composition;
using Autofac.Core;
using Gadabout.Server.Contracts;
using Gadabout.Server.Infrastructure.Modules;
using Gadabout.Server.Services.Module;

namespace Gadabout.Server.Services
{
    [Export(typeof(IServerModule))]
    public class NancyHostingModule : GenericServiceModule
    {
        public NancyHostingModule()
        {

        }

        public override string ModuleName => "Nancy Hosting Module.";

        public override void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<NancyHost>().As<INancyHost>();
        }

        public override void StartModule()
        {
           
        }

        public override void StopModule()
        {
           
        }
    }
}
