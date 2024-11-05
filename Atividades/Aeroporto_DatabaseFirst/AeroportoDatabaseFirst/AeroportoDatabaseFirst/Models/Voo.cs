using System;
using System.Collections.Generic;

namespace AeroportoDatabaseFirst.Models;

public partial class Voo
{
    public int IdVoo { get; set; }

    public DateTime? HorarioSaida { get; set; }

    public DateTime? HorarioDestino { get; set; }

    public int? IdAeroportoSaida { get; set; }

    public int? IdAeroportoDestino { get; set; }

    public int? IdAeronave { get; set; }

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();

    public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();

    public virtual Aeronave? IdAeronaveNavigation { get; set; }

    public virtual Aeroporto? IdAeroportoDestinoNavigation { get; set; }

    public virtual Aeroporto? IdAeroportoSaidaNavigation { get; set; }
}
