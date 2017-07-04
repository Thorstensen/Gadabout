using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Conventions;
using Autofac;
using Nancy.Bootstrapper;

namespace Gadabout.Server.NancyHosting.Module
{
    public class NancyBootstrapper : DefaultNancyBootstrapper, INancyBootstrapper
    {
        public NancyBootstrapper()
        {

        }
    }
}
