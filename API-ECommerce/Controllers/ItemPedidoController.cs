using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemPedidoController : ControllerBase
    {
        private IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoController(IItemPedidoRepository itemPedidoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
        }

        [HttpGet]
        public IActionResult ListarItemPedidos()
        {
            return Ok(_itemPedidoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarItemPedido(ItemPedido item)
        {
            _itemPedidoRepository.Cadastrar(item);

            return Created();
        }
    }
}
