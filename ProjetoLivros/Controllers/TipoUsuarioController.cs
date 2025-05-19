using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _repository;

        public TipoUsuarioController(ITipoUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var tipos = _repository.ListarTodos();

            return Ok(tipos);
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario tipo)
        {
            _repository.Cadastrar(tipo);

            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var tipo = _repository.ListarPorId(id);

            if (tipo == null) return NotFound();

            return Ok(tipo);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, TipoUsuario tipoNovo)
        {
            var tipoAtualizado = _repository.Atualizar(id, tipoNovo);

            if (tipoAtualizado == null) return NotFound();

            return Ok(tipoAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var tipoDeletado = _repository.Deletar(id);

            if (tipoDeletado == null) return NotFound();

            return Ok(tipoDeletado);
        }
    }
}
