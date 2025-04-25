namespace API_ECommerce.DTO
{
    // Recebo os dados do Pedido
    // E recebo os produtos comprados
    public class CadastrarPedidoDto
    {
        public DateOnly DataPedido { get; set; }

        public string Status { get; set; } = null!;

        public decimal? ValorTotal { get; set; }

        public int IdCliente { get; set; }

        // Produtos Comprados
        public List<int> Produtos { get; set; }
    }
}
