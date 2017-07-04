using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.NancyHosting.Module
{
    public class NancyBaseModule : NancyModule
    {
        public void RegisterGetMethod(string path, Func<dynamic, bool> func)
        {
            
            Get(path, func);
        }
    }
}
