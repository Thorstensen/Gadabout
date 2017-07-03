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

namespace Gadabout.Server.Services
{
    [Export(typeof(IServerModule))]
    public class OwinModule : GenericServiceModule
    {
        public OwinModule()
        {

        }

        public override string ModuleName => "Owin Module. Responsible for hosting api's";

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
