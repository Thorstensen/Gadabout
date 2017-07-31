using Nancy;
using Nancy.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Gadabout.Server.Nancy.Core.Framework
{
    public abstract class NancyBaseModule : NancyModule
    {
        public NancyBaseModule(string prefix) : base("/api/v1/" + prefix)
        {

        }

        protected ClaimsPrincipal Principal
        {
            get { return Context.GetMSOwinUser(); }
        }


        public bool IsAuthenticated
        {
            get
            {
                if (Principal == null)
                    return false;
                if (Principal.Identity == null)
                    return false;

                return Principal.Identity.IsAuthenticated;
            }
        }
    }
}
