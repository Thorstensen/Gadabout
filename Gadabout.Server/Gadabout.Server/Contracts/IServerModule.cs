using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Contracts
{
    public interface IServerModule : IModule
    {
        void StartModule();
        void StopModule();
        void RegisterTypes(ContainerBuilder builder);
        string ModuleName { get; }
    }
}
