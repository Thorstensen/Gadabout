using Gadabout.Server.Core.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Gadabout.Server.Nancy.Owin.Hosting.Module.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthorizationProvider(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            if (!context.IsCredentailsAvailable())
            {
                context.SetError("invalid_grant", "User or password is missing.");
                return;
            }

            var credentials = context.GetCredentials();

            if (!_authenticationService.AuthenticateUser(credentials.UserName, credentials.Password))
            {
                context.SetError("invalid_grant", "Invalid credentials.");
                return;
            }

            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, credentials.UserName));

            context.Validated(oAuthIdentity);
        }
    }
}
