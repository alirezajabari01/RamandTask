using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace Application.Security
{
    public static class TokenGenerator
    {
        public static string Generate(this User user)
        {

            var claims = new List<Claim>();
            claims.Add(new Claim("userid", user.Id.ToString()));
            claims.Add(new Claim("userName", user.UserName.Value));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddYears(9),
                Issuer = "www.OnlineGym.ir",
                Audience = "www.OnlineGym.ir",
                SigningCredentials = new SigningCredentials
                    (
                        new SymmetricSecurityKey
                            (Encoding.ASCII.GetBytes("in shabi@ke migan shab nist age shabe^mesle dishab nist")), SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(securityToken);
        }
        public static ClaimsPrincipal ValidateToken(string token)
        {
            var parameters = new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes
                ("in shabi@ke migan shab nist age shabe^mesle dishab nist"))
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            //tokenHandler.CanReadToken();
            return tokenHandler.ValidateToken(token, parameters, out SecurityToken securityToken);
        }
    }
}
