using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using API_ECommerce.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {        
        private IProdutoRepository _produtoRepository;        

        // Injeção de Dependência
        // Ao invés de EU instanciar a classe
        // Eu aviso que DEPENDO dela
        // E a responsibilidade de criar vem pra classe que chama (C#)
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        // GET
        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }

        // Cadastrar Produto
        [HttpPost]
        public IActionResult CadastrarProduto(CadastrarProdutoDto prod)
        {
            // 1 - Coloco o Produto no Banco de Dados
            _produtoRepository.Cadastrar(prod);

            // 2 - Retorno o resultado
            // 201 - Created
            return Created();
        }

        // Buscar Produto por Id
        // /api/produtos
        // /api/produtos/1
        [HttpGet("{id}")]
        public IActionResult ListarPorId(int id)
        {
            Produto produto = _produtoRepository.BuscarPorId(id);

            if(produto == null)
            {
                // 404 - Nao Encontrado
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, Produto prod)
        {
            try
            {
                _produtoRepository.Atualizar(id, prod);

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _produtoRepository.Deletar(id);

                // 204 - Deu certo!
                return NoContent();
            }
            // Caso de erro
            catch (Exception ex)
            {
                return NotFound("Produto não encontrado!");
            }

        }
    }
}
