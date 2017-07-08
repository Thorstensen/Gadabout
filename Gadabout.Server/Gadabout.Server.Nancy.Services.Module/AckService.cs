using Gadabout.Server.Core.Database;
using Nancy;
using System;

namespace Gadabout.Server.Nancy.Services.Module
{
    public class AckService : NancyModule
    {
        public AckService(IDataContext context) : base("/ack")
        {
            Get("/now", p =>
            {
                return $"Greetings. The time is: {DateTime.Now.ToString()}";
            });
        }
    }
}
