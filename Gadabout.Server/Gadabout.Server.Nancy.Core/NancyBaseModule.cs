using Gadabout.Server.Nancy.Core.Framework;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Nancy.Core
{
    public abstract class NancyBaseModule : NancyModule
    {
        public NancyBaseModule(string prefix) : base(prefix)
        {
            //Get("/dummy", p =>
            //{
            //    return "Nothing interesting here, Cowboy.";
            //});

            var configurator = new NancyEndpointConfigurator()
            {
                RegisterWithReturnValue = (path, action) =>
                {
                    Get(path, action);
                }
            };

            RegisterEndpoints(configurator);
        }

        public abstract void RegisterEndpoints(INancyEndpointConfigurator configurator);
    }
}
