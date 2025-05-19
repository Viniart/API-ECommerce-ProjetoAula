using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_ECommerce.Services
{
    public class TokenService
    {

        public string GenerateToken(string email)
        {
            // Claims - Informações do Usuário que quero guardar
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            // Criar uma chave de segurança e criptografar ela
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-secreta-senai"));

            // Criptografando a chave de segurança
            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            // Montar um Token
            var token = new JwtSecurityToken(
                issuer: "ecommerce",
                audience: "ecommerce",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
