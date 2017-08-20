using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gadabout.Server.Nancy.Owin.Hosting.Module.Security
{
    public class OAuthTokenProvider : OAuthBearerAuthenticationProvider
    {
        private const string AuthHeader = "Authorization";

        private readonly List<Func<IOwinRequest, string>> locations;
        private readonly Regex bearerRegex = new Regex("((B|b)earer\\s)");

        /// <summary>
        /// By Default the Token will be searched for on the "Authorization" header.
        /// <para> pass additional getters that might return a token string</para>
        /// </summary>
        /// <param name="locations"></param>
        public OAuthTokenProvider(params Func<IOwinRequest, string>[] locations)
        {
            this.locations = locations.ToList();
            this.locations.Add(x => x.Headers.Get(AuthHeader));
        }

        public override async Task RequestToken(OAuthRequestTokenContext context)
        {
            var getter = locations.FirstOrDefault(x => !String.IsNullOrWhiteSpace(x(context.Request)));
            if (getter != null)
            {
                var tokenStr = getter(context.Request);
                context.Token = bearerRegex.Replace(tokenStr, "").Trim();
            }
        }
    }
}
