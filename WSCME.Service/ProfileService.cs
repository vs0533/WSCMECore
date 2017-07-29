using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using IdentityModel;
using System.Linq;

namespace WSCME.Service
{
    
    public class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var claims = GetUserClaims();
                context.IssuedClaims = context.Subject.Claims.ToList();//claims.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            var userId = context.Subject.Claims.FirstOrDefault(x => x.Type == "user_id");

            try
            {
                if (!string.IsNullOrEmpty(userId?.Value) && long.Parse(userId.Value) > 0)
                {
                    //var user = await _userRepository.FindAsync(long.Parse(userId.Value));

                    //if (user != null)
                    //{
                    //    if (user.IsActive)
                    //    {
                    //        context.IsActive = user.IsActive;
                    //    }
                    //}
                    context.IsActive = true;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Task.FromResult(0);
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
    }
}
