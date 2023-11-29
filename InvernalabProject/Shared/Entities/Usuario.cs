using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string Email { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string? Foto { get; set; }

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public int IdEmpresa { get; set; }

    public int IdRol { get; set; }

    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual ICollection<ProcesoActividadUsuario> ProcesoActividadUsuarios { get; set; } = new List<ProcesoActividadUsuario>();
}
