using Autofac;
using Gadabout.Server.Core.Infrastructure.Logging;
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
        }

        public void Stop()
        {
            _host.Stop();
        }
    }
}
