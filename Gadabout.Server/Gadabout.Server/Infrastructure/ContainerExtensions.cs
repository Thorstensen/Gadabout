using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Infrastructure
{
    public static class ContainerExtensions
    {
        public static IEnumerable<TImplementation> GetImplementation<TImplementation>(this IContainer container)
        {
            var types = container.ComponentRegistry.Registrations.Where(r => typeof(TImplementation).IsAssignableFrom(r.Activator.LimitType)).Select(r => r.Activator.LimitType);
            
            var resolved =  types.Select(t => (TImplementation)container.Resolve(t));


            return resolved;
        }
    }
}
