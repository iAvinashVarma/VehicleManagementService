using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VehicleManagementSystemApi.Infrastructure.Security
{
    /// <summary>
    /// Token Auth Server Provider
    /// </summary>
    public class TokenAuthServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// ValidateClientAuthentication
        /// </summary>
        /// <param name="context"></param>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() =>
            {
                context.Validated();
            });
        }

        /// <summary>
        /// GrantResourceOwnerCredentials
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            await Task.Run(() =>
            {
                if (context.UserName == "admin" && context.Password == "admin")
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                    identity.AddClaim(new Claim("username", "admin"));
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Administrator"));
                    context.Validated(identity);
                }
                else if (context.UserName == "user" && context.Password == "user")
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                    identity.AddClaim(new Claim("username", "user"));
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Customer/User"));
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", "Invalid username or password.");
                    return;
                }
            });
        }
    }
}