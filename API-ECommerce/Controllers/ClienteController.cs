using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly EcommerceContext _context;
        private IClienteRepository _clienteRepository;

        public ClienteController(EcommerceContext context)
        {
            _context = context;
            _clienteRepository = new ClienteRepository(_context);
        }

        [HttpGet]
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
        [HttpGet("{email}/{senha}")]
        public IActionResult Login(string email, string senha)
        {
            var cliente = _clienteRepository.BuscarPorEmailSenha(email, senha);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }
    }
}
