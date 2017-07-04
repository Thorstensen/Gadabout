﻿using Autofac;
using Autofac.Core;
using Gadabout.Server.Framework;
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
        void SetContainer(IContainer container);
        string ModuleName { get; }
        IContainer Container { get; }
        InitializationPreference InitializationPreference { get; }
    }
}
