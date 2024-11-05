using System;
using System.Collections.Generic;

namespace AeroportoDatabaseFirst.Models;

public partial class Aeroporto
{
    public int IdAeroporto { get; set; }

    public string? Localizacao { get; set; }

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();

    public virtual ICollection<Voo> VooIdAeroportoDestinoNavigations { get; set; } = new List<Voo>();

    public virtual ICollection<Voo> VooIdAeroportoSaidaNavigations { get; set; } = new List<Voo>();
}
