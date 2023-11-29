using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Nave
{
    public int IdNave { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime? FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public int IdBloque { get; set; }

    public virtual Bloque IdBloqueNavigation { get; set; } = null!;

    public virtual ICollection<ProcesoNave> ProcesoNaves { get; set; } = new List<ProcesoNave>();
}
