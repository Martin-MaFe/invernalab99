using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class ProcesoActividadInsumo
{
    public int IdProcesoInsumo { get; set; }

    public int? IdInsumo { get; set; }

    public int IdProcesoActividad { get; set; }

    public double CantidadAplicada { get; set; }

    public virtual Insumo? IdInsumoNavigation { get; set; }

    public virtual ProcesoActividad IdProcesoActividadNavigation { get; set; } = null!;
}
