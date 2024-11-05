using System;
using System.Collections.Generic;

namespace AeroportoDatabaseFirst.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nome { get; set; }

    public string? Contato { get; set; }

    public string? Genero { get; set; }

    public DateTime? DataNascimento { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
