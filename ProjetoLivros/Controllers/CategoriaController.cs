using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        // Injetar o Repository
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var categorias = _repository.ListarTodos();

            return Ok(categorias);
        }

        [HttpPost]
        public IActionResult Cadastrar(Categoria categoria)
        {
            _repository.Cadastrar(categoria);

            return Created();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            var categoria = _repository.ListarPorId(id);

            if (categoria == null) return NotFound();

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Categoria categoriaNova)
        {
            var categoriaAtualizada = _repository.Atualizar(id, categoriaNova);

            if (categoriaAtualizada == null) return NotFound();

            return Ok(categoriaAtualizada);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var categoriaDeletada = _repository.Deletar(id);

            if(categoriaDeletada == null) return NotFound();

            return Ok(categoriaDeletada);
        }
    }
}
