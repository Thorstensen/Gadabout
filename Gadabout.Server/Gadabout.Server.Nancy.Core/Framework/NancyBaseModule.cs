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

        protected dynamic GetBody(Stream body)
        {
            int length = (int)body.Length; 
            byte[] data = new byte[length];
            body.Read(data, 0, length);
            return JsonConvert.DeserializeObject(System.Text.Encoding.Default.GetString(data));

        }
    }
}
