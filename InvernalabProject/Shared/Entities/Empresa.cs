using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string? Nombre { get; set; }

    public bool NitExits(InvernalabContext context)
    {
        return context.Empresas.Any(e => e.Nit == Nit);

    }

    public string Nit { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int Estado { get; set; }

    public string Logo { get; set; } = null!;

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public virtual ICollection<Terreno> Terrenos { get; set; } = new List<Terreno>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
