using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class ProcesoActividad
{
    public int IdProcesoActividad { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFinal { get; set; }

    public DateTime? FechaEjecucion { get; set; }

    public int Estado { get; set; }

    public int IdProceso { get; set; }

    public int IdActividad { get; set; }

    public virtual Actividad IdActividadNavigation { get; set; } = null!;

    public virtual Proceso IdProcesoNavigation { get; set; } = null!;

    public virtual ICollection<ProcesoActividadInsumo> ProcesoActividadInsumos { get; set; } = new List<ProcesoActividadInsumo>();

    public virtual ICollection<ProcesoActividadMaquinarium> ProcesoActividadMaquinaria { get; set; } = new List<ProcesoActividadMaquinarium>();

    public virtual ICollection<ProcesoActividadUsuario> ProcesoActividadUsuarios { get; set; } = new List<ProcesoActividadUsuario>();
}
