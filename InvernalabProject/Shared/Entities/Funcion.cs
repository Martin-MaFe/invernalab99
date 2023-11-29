using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Funcion
{
    public int IdFuncion { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public int IdRol { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
