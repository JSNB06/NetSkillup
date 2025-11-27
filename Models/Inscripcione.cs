using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class Inscripcione
{
    public int IdInscripcion { get; set; }

    public int IdCursos { get; set; }

    public int Identificacion { get; set; }

    public DateTime? FechaInscripcion { get; set; }

    public string? Estado { get; set; }

    public virtual Curso IdCursosNavigation { get; set; } = null!;

    public virtual RolesSistema IdentificacionNavigation { get; set; } = null!;
}
