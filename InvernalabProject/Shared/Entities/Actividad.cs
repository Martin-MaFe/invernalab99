using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Actividad
{
    public int IdActividad { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string Imagen { get; set; } = null!;

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public int IdEtapa { get; set; }

    public virtual Etapa IdEtapaNavigation { get; set; } = null!;

    public virtual ICollection<ProcesoActividad> ProcesoActividads { get; set; } = new List<ProcesoActividad>();
}
