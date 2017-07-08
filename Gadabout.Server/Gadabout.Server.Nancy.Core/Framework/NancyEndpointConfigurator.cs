using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Nancy.Core.Framework
{
    public class NancyEndpointConfigurator : INancyEndpointConfigurator
    {
        public void WithReturnValue(string path, Func<dynamic, object> d)
        {
            RegisterWithReturnValue(path, d);
        }

        public Action<string, Func<dynamic, object>> RegisterWithReturnValue { get; set; }
    }
}
