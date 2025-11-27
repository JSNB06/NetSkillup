using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class Modulo
{
    public int IdModulo { get; set; }

    public int IdCursos { get; set; }

    public string NombreModulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? Orden { get; set; }

    public virtual ICollection<Evaluacione> Evaluaciones { get; set; } = new List<Evaluacione>();

    public virtual Curso IdCursosNavigation { get; set; } = null!;
}
