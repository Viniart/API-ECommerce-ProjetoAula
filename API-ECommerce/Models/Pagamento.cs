using System;
using System.Collections.Generic;

namespace API_ECommerce.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public int? IdPedido { get; set; }

    public string? FormaPagamento { get; set; }

    public string? Status { get; set; }

    public DateTime? Data { get; set; }

    public virtual Pedido? IdPedidoNavigation { get; set; }
}
