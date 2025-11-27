using System;
using System.Collections.Generic;

namespace Proyecto.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<RolesSistema> RolesSistemas { get; set; } = new List<RolesSistema>();
}
