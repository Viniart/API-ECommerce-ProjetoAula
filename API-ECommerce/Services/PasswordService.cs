using API_ECommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace API_ECommerce.Services
{
    public class PasswordService
    {
        // PasswordHasher - PBKDF2
        private readonly PasswordHasher<Cliente> _hasher = new();
        // private readonly PasswordHasher<Cliente> _hasher = new PasswordHasher<Cliente>();


        // 1 - Gerar um Hash
        public string HashPassword(Cliente cliente)
        {
            return _hasher.HashPassword(cliente, cliente.Senha);
        }

        // 2 - Verificar o Hash
        public bool VerificarSenha(Cliente cliente, string senhaInformada)
        {
            var resultado = _hasher.VerifyHashedPassword(cliente, cliente.Senha, senhaInformada);

            //if(resultado == PasswordVerificationResult.Success)
            //{
            //    return true;
            //} else
            //{
            //    return false;
            //}

            return resultado == PasswordVerificationResult.Success;
        }

    }
}
