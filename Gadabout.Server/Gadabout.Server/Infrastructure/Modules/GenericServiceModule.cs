using Gadabout.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Core;
using Autofac;

namespace Gadabout.Server.Infrastructure.Modules
{
    public abstract class GenericServiceModule : Autofac.Module, IServerModule
    {
        public abstract string ModuleName { get; }

        public abstract void RegisterTypes(ContainerBuilder builder);
        public abstract void StartModule();
        public abstract void StopModule();
    }
}
