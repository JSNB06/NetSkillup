using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class Curso
{
    public int IdCursos { get; set; }

    public string NombreCurso { get; set; } = null!;

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();

    public virtual ICollection<Modulo> Modulos { get; set; } = new List<Modulo>();
}
