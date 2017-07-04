using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.NancyHosting.Module
{
    public class NancyTestPlugin : NancyBaseModule
    {
        public NancyTestPlugin()
        {
            Get("/test", p =>
            {
                return "test-response";
            });
        }
    }
}
