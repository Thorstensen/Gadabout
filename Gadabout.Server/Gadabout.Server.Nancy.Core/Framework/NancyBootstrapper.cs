using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Conventions;
using Autofac;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using Nancy.Configuration;
using Nancy.Diagnostics;
using Nancy.Bootstrappers.Autofac;
using Gadabout.Server.Core.Infrastructure.Logging;
using Gadabout.Server.Core.Security;
using NancyContextExtensions = Gadabout.Server.Nancy.Core.Extensions;

namespace Gadabout.Server.Nancy.Core.Framework
{
    public class NancyBootstrapper : AutofacNancyBootstrapper
    {
        private readonly ILifetimeScope _scope;

        public NancyBootstrapper(ILifetimeScope scope)
        {
            _scope = scope;
        }

        protected override ILifetimeScope GetApplicationContainer()
        {
            return _scope;
        }

        protected override void ApplicationStartup(ILifetimeScope container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            pipelines.BeforeRequest.AddItemToStartOfPipeline(ctx =>
            {               
               var route = ctx.ResolvedRoute;
               
               // ctx.IsAuthenticated();
               //Add support here to check wheter the resolved route is whitelisted
               //This enables us to avoid checking if the user is authenticated within the method
               //If route is not whitelisted, check for authentication

                string callingHost = ctx.Request.UserHostAddress;
                if (callingHost.StartsWith("::1"))
                    callingHost = "localhost";

                ConsoleLogger.Log($"Nancy Request {ctx.Request.Url} invoked by {callingHost}");

                return ctx.Response;
            });
        }

        protected override void RegisterRequestContainerModules(ILifetimeScope container, IEnumerable<ModuleRegistration> moduleRegistrationTypes)
        {
            base.RegisterRequestContainerModules(container, moduleRegistrationTypes);

            var modules = string.Join(", ", moduleRegistrationTypes.Select(p => p.ModuleType.Name));
            ConsoleLogger.Log($"Initializing Nancy Module(s): {modules}", LogLevel.Information);
        }

        protected override IEnumerable<INancyModule> GetAllModules(ILifetimeScope container)
        {
            var all = base.GetAllModules(container);
          
            return all;
        }
    }
}
