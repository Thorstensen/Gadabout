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

namespace Gadabout.Server.Services
{
    [Export(typeof(IModule))]
    public class ServiceModule : Autofac.Module
    {
        public ServiceModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
           
        }
    }
}
