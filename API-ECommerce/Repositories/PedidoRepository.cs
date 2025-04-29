using API_ECommerce.Context;
using API_ECommerce.DTO;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace API_ECommerce.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EcommerceContext _context;

        public PedidoRepository(EcommerceContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(CadastrarPedidoDto pedidoDto)
        {
            // Cadastrar o Pedido
            // Crio uma variável pedido, para guardar as informações do pedido
            var pedido = new Pedido
            {
                DataPedido = pedidoDto.DataPedido,
                Status = pedidoDto.Status,
                IdCliente = pedidoDto.IdCliente,
                ValorTotal = pedidoDto.ValorTotal
            };

            _context.Pedidos.Add(pedido);

            _context.SaveChanges();

            // Cadastrar os ItensPedido
            // Para cada PRODUTO, eu crio um ItemPedido
            for (int i = 0; i < pedidoDto.Produtos.Count; i++)
            {
                // Encontro o Produto
                var produto = _context.Produtos.Find(pedidoDto.Produtos[i]);

                // TODO: Lançar erro se produto não existe

                // Crio uma variável ItemPedido
                var itemPedido = new ItemPedido
                {
                    IdPedido = pedido.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 0
                };

                // Jogo no Banco de Dados e Salvo
                _context.ItemPedidos.Add(itemPedido);

                _context.SaveChanges();
            }

        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListarTodos()
        {
            return _context.Pedidos
                .Include(p => p.ItemPedidos)
                .ThenInclude(p => p.Produto)
                .ToList();
        }
    }
}
