using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class ProcesoActividadMaquinarium
{
    public int IdProcesoActividadMaquinaria { get; set; }

    public int IdProcesoActividad { get; set; }

    public int IdMaquinaria { get; set; }

    public virtual Maquinarium IdMaquinariaNavigation { get; set; } = null!;

    public virtual ProcesoActividad IdProcesoActividadNavigation { get; set; } = null!;
}
