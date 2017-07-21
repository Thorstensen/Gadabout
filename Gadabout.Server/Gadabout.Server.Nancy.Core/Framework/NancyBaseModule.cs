using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Nancy.Core.Framework
{
    public abstract class NancyBaseModule : NancyModule
    {
        public NancyBaseModule(string prefix) : base("/api/v1/" + prefix)
        {
               
        }
    }
}
