using ConectaTalentos.Application.Interfaces;
using ConectaTalentos.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ConectaTalentos.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            var secretKey = _configuration.GetValue<string>("JwtSettings:SecretKey")
                ?? throw new InvalidOperationException("SecretKey não configurada.");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var expirationHours = _configuration.GetValue<int>("JwtSettings:ExpirationHours");

            var claims = new List<Claim>
        {
               new Claim("id", user.Id.ToString()),
               new Claim("name", user.Name),
               new Claim("email", user.Email),
               new Claim("role", user.Role.ToString())
        };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expirationHours),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
