using Gadabout.Server.Nancy.Core;
using Nancy;
using System;
using Gadabout.Server.Nancy.Core.Framework;

namespace Gadabout.Server.Nancy.Services.Module
{
    public class AckService : NancyBaseModule
    {
        public AckService() : base("AckService")
        {
        }

        public override void RegisterEndpoints(INancyEndpointConfigurator configurator)
        {
            configurator.WithReturnValue("/now", p =>
            {
                return $"Greetings. The time is: {DateTime.Now.ToString()}";
            });
        }
    }
}
