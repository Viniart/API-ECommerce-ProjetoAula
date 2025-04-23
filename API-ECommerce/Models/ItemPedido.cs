using System;
using System.Collections.Generic;

namespace API_ECommerce.Models;

public partial class ItemPedido
{
    public int IdItemPedido { get; set; }

    public int IdPedido { get; set; }

    public int IdProduto { get; set; }

    public int Quantidade { get; set; }

    public virtual Pedido Pedido { get; set; } = null!;

    public virtual Produto Produto { get; set; } = null!;
}
