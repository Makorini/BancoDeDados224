using System;
using System.Collections.Generic;

namespace Aviacao.Models;

public partial class Escala
{
    public int IdEscala { get; set; }

    public DateTime? HorarioSaida { get; set; }

    public int? IdVoo { get; set; }

    public int? IdAeroportoSaida { get; set; }

    public virtual Aeroporto? IdAeroportoSaidaNavigation { get; set; }

    public virtual Voo? IdVooNavigation { get; set; }
}
