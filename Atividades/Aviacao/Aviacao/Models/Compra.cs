using System;
using System.Collections.Generic;

namespace Aviacao.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int? IdHorario { get; set; }

    public int? IdCliente { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Horario? IdHorarioNavigation { get; set; }
}
