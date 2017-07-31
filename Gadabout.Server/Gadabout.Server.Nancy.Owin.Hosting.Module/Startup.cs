using Autofac;
using Gadabout.Server.Nancy.Core.Framework;
using Nancy.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gadabout.Server.Nancy.Owin.Hosting.Module
{
    public class Startup
    {
        private readonly ILifetimeScope _scope;
        public Startup(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public void Configuration(IAppBuilder app)
        {
            var nancyOptions = new NancyOptions();
            nancyOptions.Bootstrapper = new NancyBootstrapper(_scope);
            app.UseNancy(nancyOptions);
            
           // app.Map("", siteBuilder => siteBuilder.UseNancy());
        }
    }
}
