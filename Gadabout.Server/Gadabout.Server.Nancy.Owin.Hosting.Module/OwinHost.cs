using Gadabout.Server.Core.Contract;
using Gadabout.Server.Core.Infrastructure.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Owin.Hosting;
using Owin;
using Gadabout.Server.Nancy.Core.Framework;
using Nancy.Owin;

namespace Gadabout.Server.Nancy.Owin.Hosting.Module
{
    [Export(typeof(IServerModule))]
    public class OwinHost : BaseServerModule
    {
        private IDisposable _webApp = null;
        const string url = "http://localhost:8081";

        public override string ModuleName => "Owin Host";

        public override void RegisterTypes(ContainerBuilder builder)
        {

        }

        public override void StartModule()
        {
            _webApp = WebApp.Start(url, GetStartupConfig());
        }

        public override void StopModule()
        {
            _webApp?.Dispose();
        }

        private Action<IAppBuilder> GetStartupConfig()
        {
            return app =>
            {
                var nancyOptions = new NancyOptions();
                nancyOptions.Bootstrapper = new NancyBootstrapper(Container);
                app.UseNancy(nancyOptions);
            };
        }
    }
}
