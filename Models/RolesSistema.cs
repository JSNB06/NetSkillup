using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class RolesSistema
{
    public int Identificacion { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido1 { get; set; }

    public string? Apellido2 { get; set; }

    public string? Contraseña { get; set; }

    public int IdRol { get; set; }

    public string? Correo { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual ICollection<Inscripcione> Inscripciones { get; set; } = new List<Inscripcione>();
}
