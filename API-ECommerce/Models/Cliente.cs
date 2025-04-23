using System;
using System.Collections.Generic;

namespace API_ECommerce.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string NomeCompleto { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefone { get; set; }

    public string? Endereco { get; set; }

    public string Senha { get; set; } = null!;

    public DateOnly? DataCadastro { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
