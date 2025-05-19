using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _repository;

        public LivroController(ILivroRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var livros = _repository.ListarTodos();

            return Ok(livros);
        }

        [HttpPost]
        public IActionResult Cadastrar(Livro livro)
        {
            _repository.Cadastrar(livro);

            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var livro = _repository.ListarPorId(id);

            if (livro == null) return NotFound();

            return Ok(livro);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Livro livroNovo)
        {
            var livroAtualizado = _repository.Atualizar(id, livroNovo);

            if (livroAtualizado == null) return NotFound();

            return Ok(livroAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var livroDeletado = _repository.Deletar(id);

            if (livroDeletado == null) return NotFound();

            return Ok(livroDeletado);
        }

    }
}
