using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Bloque
{
    public int IdBloque { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Area { get; set; } = null!;

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public int IdTerreno { get; set; }

    public virtual Terreno IdTerrenoNavigation { get; set; } = null!;

    public virtual ICollection<Nave> Naves { get; set; } = new List<Nave>();
}
