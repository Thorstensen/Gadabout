using Nancy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Nancy.Core.Extensions
{
    public static class NancyRequestExtensions
    {
        public static dynamic ReadHttpBody(this Request request)
        {
            int length = (int)request.Body.Length;
            byte[] data = new byte[length];
            request.Body.Read(data, 0, length);
            return JsonConvert.DeserializeObject(System.Text.Encoding.Default.GetString(data));
        }
    }
}
