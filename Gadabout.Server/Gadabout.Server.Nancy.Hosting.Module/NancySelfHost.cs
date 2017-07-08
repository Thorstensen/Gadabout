using Gadabout.Server.Core.Infrastructure.Logging;
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
        public const string HostingAddress = @"http://localhost:1234";

        public NancySelfHost()
        {
          
        }

        public void Start()
        {
            using (var host = new NancyHost(new Uri(HostingAddress), new NancyBootstrapper()))
            {
                host.Start();
                ConsoleLogger.Log($"Hosting Nancy modules on: {HostingAddress}");
            }
        }
    }
}
