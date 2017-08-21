using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
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
        private readonly IUnitAccountServices unitAccountServices = null;
        public ResourceOwnerPasswordValidator(IUnitAccountServices unitAccountServices)
        {
            this.unitAccountServices = unitAccountServices;
        }
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
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var loggedIn = await unitAccountServices.GetFirstOrDefault(c => c.Code == context.UserName && c.PassWord == context.Password);

            if (loggedIn == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidClient, "用户名密码不正确");
                return;

            }
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
            return;
        }
    }
}
