using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Ncc.China.Services.Identity.Api
{
    public static class Util
    {
        public static object GenerateJwt(string subValue, string issuer, string audience,
            DateTime? expires, string securityKey)
        {
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Sub, subValue),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var jwt = new JwtSecurityToken(issuer: issuer,
                audience: audience,
                expires: expires,
                claims:claims,
                signingCredentials: new SigningCredentials(signingKey,
                    SecurityAlgorithms.HmacSha256)
            );
            var token = new JwtSecurityTokenHandler()
                .WriteToken(jwt);
            return new { token, type = "Bearer", expireAt = jwt.ValidTo };
        }
    }
}
