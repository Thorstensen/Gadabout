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
        private NancySelfHost _nancyHost;

        public override string ModuleName => "Nancy Hosting Module.";

        public override void RegisterTypes(ContainerBuilder builder)
        {
        }

        public override void ContainerUpdated(IContainer container)
        {
            base.ContainerUpdated(container);
            _nancyHost = new NancySelfHost(container);
            
        }

        public override void StartModule()
        {
            _nancyHost.Start();
        }

        public override void StopModule()
        {
            _nancyHost.Stop();
        }
    }
}
