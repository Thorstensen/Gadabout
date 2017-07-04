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
        private readonly INancyBootstrapper _nancyBootStrapper;
        public const string HostingAddress = @"http://localhost:1234";

        public NancySelfHost(INancyBootstrapper bootStrapper)
        {
            _nancyBootStrapper = bootStrapper;
        }

        public void Start()
        {
            using (var host = new NancyHost(new Uri(HostingAddress), _nancyBootStrapper))
            {
                host.Start();
                Console.WriteLine($"Nancy hosting running address: {HostingAddress}");
                Console.ReadLine();
            }
        }
    }
}
