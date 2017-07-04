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
using Nancy.Bootstrappers.Autofac;
using Gadabout.Server.Infrastructure.Logging;

namespace Gadabout.Server.NancyHosting.Module
{
    public class NancyBootstrapper : DefaultNancyBootstrapper, NancyHostBootstrapper
    {
        public NancyBootstrapper()
        {

        }

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            pipelines.BeforeRequest.AddItemToStartOfPipeline(ctx =>
            {    
                ConsoleLogger.Log($"Nancy Method {ctx.Request.Path} invoked by {ctx.Request.UserHostAddress}");
                
                return ctx.Response;
            });
        }

    }
}
