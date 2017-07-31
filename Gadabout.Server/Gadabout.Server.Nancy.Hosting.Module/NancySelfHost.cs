using Autofac;
using Gadabout.Server.Core.Infrastructure.Logging;
using Gadabout.Server.Nancy.Core.Framework;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.NancyHosting.Module
{
    public class NancySelfHost
    {
        public const string HostingAddress = "http://localhost:1234";

        private readonly NancyHost _host;

        public NancySelfHost(ILifetimeScope scope)
        {
            _host = new NancyHost(new Uri(HostingAddress), new NancyBootstrapper(scope));
        }

        public void Start()
        {
            _host.Start();
            ConsoleLogger.Log($"Hosting Nancy Modules on: {HostingAddress}", System.Drawing.Color.LightSkyBlue);
        }

        public void Stop()
        {
            _host.Stop();
        }
    }
}
