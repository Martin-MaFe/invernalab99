using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class ProcesoActividadUsuario
{
    public int IdProcesoActividadUsuario { get; set; }

    public int IdProcesoActividad { get; set; }

    public int IdUsuario { get; set; }

    public virtual ProcesoActividad IdProcesoActividadNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
