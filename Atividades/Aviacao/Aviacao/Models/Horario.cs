using System;
using System.Collections.Generic;

namespace Aviacao.Models;

public partial class Horario
{
    public int IdHorario { get; set; }

    public int Disponibilidade { get; set; }

    public string? LadoPoltrona { get; set; }

    public string? LocalizacaoPoltrona { get; set; }

    public int? IdVoo { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Voo? IdVooNavigation { get; set; }
}
