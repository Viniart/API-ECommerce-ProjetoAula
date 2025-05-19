using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Interfaces;
using ProjetoLivros.Models;

namespace ProjetoLivros.Controllers
{
    // Versão Assíncrona do Controller
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaAsyncController : ControllerBase
    {
       
        private readonly ICategoriaRepositoryAsync _repository;

        public CategoriaAsyncController(ICategoriaRepositoryAsync repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var categorias = await _repository.ListarTodosAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPorId(int id)
        {
            var categoria = await _repository.BuscarPorIdAsync(id);

            if (categoria == null) return NotFound();

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Categoria categoria)
        {
            await _repository.CadastrarAsync(categoria);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Categoria categoria)
        {
            var categoriaAtualizada = await _repository.AtualizarAsync(id, categoria);

            if (categoriaAtualizada == null) return NotFound();

            return Ok(categoriaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var categoriaDeletada = await _repository.DeletarAsync(id);

            if (categoriaDeletada == null) return NotFound();

            return Ok(categoriaDeletada);
        }
    }
}
