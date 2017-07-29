using IdentityModel;
using IdentityServer4;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WSCME.Service
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public static Claim[] GetUserClaims()
        {
            return new Claim[]
            {
            //new Claim("user_id", user.UserId.ToString() ?? ""),
            new Claim("user_id", "12677"),
            new Claim(JwtClaimTypes.Name, "tanglin"),
            new Claim(JwtClaimTypes.GivenName, "tang"),
            new Claim(JwtClaimTypes.FamilyName, "linlin"),
            new Claim(JwtClaimTypes.Email, "3447063@qq.com"),
            new Claim("some_claim_you_want_to_see", "aaaa"),

            //roles
            new Claim(JwtClaimTypes.Role, "person")
            };
        }
        public  Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var test = context.Request.Raw["logintype"];
            try
            {
                context.Result = new GrantValidationResult(
                            subject: test,
                            authenticationMethod: "custom",
                            claims: GetUserClaims()
                        );
            }
            catch (Exception)
            {

                throw;
            }
            return Task.FromResult(0);
        }
    }
}
