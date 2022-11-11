using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces.Autenticacao;
using Application.Common.Interfaces.Services;
using Microsoft.IdentityModel.Tokens;

namespace Infra
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateProvider;
        public JwtTokenGenerator(IDateTimeProvider dateProvider)
        {
            _dateProvider = dateProvider;
        }

        public string GenerateToken(
            Guid userId, 
            string firstName, 
            string lastName)
        {
            var siginingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key")),
                    SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var securityToken = new JwtSecurityToken(
                issuer: "helloword",
                expires: _dateProvider.UtcNow.AddMinutes(60),
                claims: claims,
                signingCredentials: siginingCredentials
                ); 

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
