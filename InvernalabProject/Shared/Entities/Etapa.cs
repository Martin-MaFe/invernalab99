using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Etapa
{
    public int IdEtapa { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();
}
