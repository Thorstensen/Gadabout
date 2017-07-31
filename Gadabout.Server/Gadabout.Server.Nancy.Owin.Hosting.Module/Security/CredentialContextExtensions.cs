using Gadabout.Server.Nancy.Owin.Hosting.Module.Infrastructure;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Nancy.Owin.Hosting.Module.Security
{
    public static class CredentialContextExtensions
    {
        public static bool IsCredentailsAvailable(this OAuthGrantResourceOwnerCredentialsContext context)
        {
            return !string.IsNullOrEmpty(context.UserName) || !string.IsNullOrEmpty(context.Password);
        }

        public static Credentials GetCredentials(this OAuthGrantResourceOwnerCredentialsContext context)
        {
            return new Credentials
            {
                UserName = context.UserName,
                Password = context.Password
            };
        }
    }
}
