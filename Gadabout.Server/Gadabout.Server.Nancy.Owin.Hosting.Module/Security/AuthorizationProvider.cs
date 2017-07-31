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
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (!context.IsCredentailsAvailable())
            {
                context.SetError("invalid_grant", "User or password is missing.");
                return base.GrantResourceOwnerCredentials(context);
            }

            var credentials = context.GetCredentials();

            //TODO: Need to add check against database

            var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
            oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, "TEST!"));

            context.Validated(oAuthIdentity);
            return base.GrantResourceOwnerCredentials(context);
        }
    }
}
