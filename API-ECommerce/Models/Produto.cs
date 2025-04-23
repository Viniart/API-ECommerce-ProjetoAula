using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_ECommerce.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }

    public decimal Preco { get; set; }

    public int EstoqueDisponivel { get; set; }

    public string Categoria { get; set; } = null!;

    public string? Imagem { get; set; }

    public virtual ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();


}
