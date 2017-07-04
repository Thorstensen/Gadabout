using Gadabout.Server.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Core;
using Autofac;
using Gadabout.Server.Core.Framework;

namespace Gadabout.Server.Core.Infrastructure.Modules
{
    public abstract class GenericServiceModule : Module, IServerModule
    {
        public abstract string ModuleName { get; }

        public abstract void RegisterTypes(ContainerBuilder builder);
        public abstract void StartModule();
        public abstract void StopModule();

        public void SetContainer(IContainer container)
        {
            Container = container;
        }

        public IContainer Container { get; private set; }

        public InitializationPreference InitializationPreference => InitializationPreference.PerferLast;
    }
}
