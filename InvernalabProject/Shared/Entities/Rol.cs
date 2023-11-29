using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Rol
{
    public int IdRol { get; set; }

    public string NombreRol { get; set; } = null!;

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public virtual ICollection<Funcion> Funcions { get; set; } = new List<Funcion>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
