using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssinaturaController : ControllerBase
    {
        private readonly IAssinaturaRepository _repository;

        public AssinaturaController(IAssinaturaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var assinaturas = _repository.ListarTodos();

            return Ok(assinaturas);
        }

        [HttpPost]
        public IActionResult Cadastrar(Assinatura assinatura)
        {
            _repository.Cadastrar(assinatura);

            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var assinatura = _repository.ListarPorId(id);

            if (assinatura == null) return NotFound();

            return Ok(assinatura);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Assinatura assinaturaNova)
        {
            var assinaturaAtualizada = _repository.Atualizar(id, assinaturaNova);

            if (assinaturaAtualizada == null) return NotFound();

            return Ok(assinaturaAtualizada);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var assinaturaDeletada = _repository.Deletar(id);

            if (assinaturaDeletada == null) return NotFound();

            return Ok(assinaturaDeletada);
        }
    }
}
