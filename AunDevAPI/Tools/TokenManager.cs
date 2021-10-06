using BLL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AunDevAPI.Tools
{
    public class TokenManager
    {
        internal static string secret = "dwqfgkjlbhgiougbIUOGIYOZSOhzfgiuDHSiosdPOIUGHspsoiHFGSOPHger8fgZRT4S6QE68Y4QE8R7GYHS9SWFTHZ89Z7RHZ498RTHS3sexrtdyqseryqet4qz8e94ery65+m/ygdfk894td-ydrt8ju94ry";
        public static string myIssuer = "monSiteApi.com";
        public static string myAudience = "monSite.com";

        public string GenerateJWT(IUser user)
        {
            if(user.Email is null)
            {
                throw new ArgumentNullException();
            }

            //creation des credentials
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            //cree l'objet claim qui contiendra les infos du token 
            Claim[] myclaims = new[]
            {
                new Claim(ClaimTypes.Sid,user.Id.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,$"{user.Lastname} {user.Firstname}"),
                new Claim(ClaimTypes.Role,user.GetType().Name)
            };

            //creation du token 
            JwtSecurityToken token = new JwtSecurityToken
                (
                    claims: myclaims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: credentials,
                    issuer: myIssuer,
                    audience: myAudience
                );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
