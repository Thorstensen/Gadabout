using Autofac;
using Gadabout.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Infrastructure
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterNancyModule<TNancyModule>(this ContainerBuilder builder) where TNancyModule : INancyModule
        {
            builder.RegisterType<TNancyModule>().As<INancyModule>();
        }
    }
}
