using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class Evaluacione
{
    public int IdEvaluacion { get; set; }

    public int IdModulo { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Modulo IdModuloNavigation { get; set; } = null!;
}
