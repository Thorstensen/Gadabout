using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Nancy.Core.Framework
{
    public interface INancyEndpointConfigurator
    {
        void WithReturnValue(string path, Func<dynamic, object> d);
    }
}
