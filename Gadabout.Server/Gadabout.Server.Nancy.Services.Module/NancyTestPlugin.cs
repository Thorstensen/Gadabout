using Nancy;
using System;

namespace Gadabout.Server.Nancy.Services.Module
{
    public class AckService : NancyModule
    {
        public AckService()
        {
            Get("/now", p =>
            {
                return $"Greetings. The time is: {DateTime.Now.ToString()}";
            });
        }
    }
}
