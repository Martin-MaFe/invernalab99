using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Terreno
{
    public int IdTerreno { get; set; }

    public string CodigoTerreno { get; set; } = null!;

    public string Ubicacion { get; set; } = null!;

    public string Area { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaInsert { get; set; }

    public DateTime FechaUpdate { get; set; }

    public int IdEmpresa { get; set; }

    public virtual ICollection<Bloque> Bloques { get; set; } = new List<Bloque>();

    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
}
