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
using Microsoft.Owin.Security.OAuth;
using Gadabout.Server.Nancy.Owin.Hosting.Module.Security;
using Microsoft.Owin;
using Gadabout.Server.Core.Security;
using Gadabout.Server.Core.Infrastructure.Logging;

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
            ConsoleLogger.Log($"OWIN Hosted successfully on: {url}", LogLevel.Information);
        }

        public override void StopModule()
        {
            _webApp?.Dispose();
        }

        private Action<IAppBuilder> GetStartupConfig()
        {
            return app =>
            {
                ConfigureOAuth(app);

                var nancyOptions = new NancyOptions()
                {
                    Bootstrapper = new NancyBootstrapper(Container)
                };
                app.UseNancy(nancyOptions);
            };
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
            {
                Provider = new OAuthTokenProvider(
                   req => req.Query.Get("bearer_token"),
                   req => req.Query.Get("access_token"),
                   req => req.Query.Get("token"),
                   req => req.Headers.Get("X-Token"))
            });

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true, // you should use this for debugging only
                TokenEndpointPath = new PathString("/login"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(8),
                Provider = new AuthorizationProvider(Container.Resolve<IAuthenticationService>()),
            });
        }
    }
}
