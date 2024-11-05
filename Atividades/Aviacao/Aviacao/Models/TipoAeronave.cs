using System;
using System.Collections.Generic;

namespace Aviacao.Models;

public partial class TipoAeronave
{
    public int IdTipoAeronave { get; set; }

    public string? Descricao { get; set; }

    public virtual ICollection<Aeronave> Aeronaves { get; set; } = new List<Aeronave>();
}
