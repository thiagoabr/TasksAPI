using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TasksAPI.Application.Security
{
    public class JwtTokenCreator
    {
        private readonly JwtBearerSettings? _jwtBearerSettings;

        public JwtTokenCreator(IOptions<JwtBearerSettings> jwtBearerSettings)
        {
            _jwtBearerSettings = jwtBearerSettings.Value;
        }

        public string CreateToken(string name)
        {
            var claims = new[] { new Claim(ClaimTypes.Name, name) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtBearerSettings?.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtBearerSettings?.Issuer,
                audience: _jwtBearerSettings?.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtBearerSettings?.ExpirationInMinutes)),
                signingCredentials: credentials
                );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(jwtSecurityToken);
        }
    }
}
