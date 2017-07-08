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
using Gadabout.Server.Core.Contract;
using Gadabout.Server.Core.Infrastructure.Modules;
using Nancy.Hosting.Self;
using Gadabout.Server.Core.Infrastructure.Logging;
using Gadabout.Server.NancyHosting.Module;
using Nancy.Bootstrapper;

namespace Gadabout.Server.Services.NancyHosting
{
    [Export(typeof(IServerModule))]
    public class NancyHostingModule : BaseServerModule
    {
        public override string ModuleName => "Nancy Hosting Module.";

        public override void RegisterTypes(ContainerBuilder builder)
        {
           
        }

        public override void StartModule()
        {
            var nancyHost = new NancySelfHost();
            nancyHost.Start();
        }

        public override void StopModule()
        {
           
        }
    }
}
