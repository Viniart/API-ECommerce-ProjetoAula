using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using API_ECommerce.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpGet("/buscar/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(_clienteRepository.BuscarClientePorNome(nome));
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(_clienteRepository.BuscarPorId(id));
        }

        // /api/cliente/vini@senai.com/12345
        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            var cliente = _clienteRepository.BuscarPorEmailSenha(login.Email, login.Senha);

            if (cliente == null)
            {
                return Unauthorized("Email ou Senha invalidos!");
            }

            var tokenService = new TokenService();

            var token = tokenService.GenerateToken(cliente.Email);
            
            return Ok(token);
        }

        [HttpPost]
        public IActionResult CadastrarCliente(CadastrarClienteDto cliente)
        {

            _clienteRepository.Cadastrar(cliente);

            return Created();
        }
    }
}
