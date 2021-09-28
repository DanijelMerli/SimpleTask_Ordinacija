using Microsoft.IdentityModel.Tokens;
using ordinacija_be.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ordinacija_be.Security
{
    public class JWTGenerator : ITokenGenerator
    {
        public string GenerateTokenString(Dentist dentist)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // problem - vulnerable because of hardcoded key
            byte[] key = Encoding.ASCII.GetBytes("tnMSeCUE4YKtPtwokpgPDq7yNHUXzPbs");

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, dentist.Id.ToString()),
                    new Claim(ClaimTypes.Email, dentist.Email)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
