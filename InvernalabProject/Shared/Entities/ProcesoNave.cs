using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class ProcesoNave
{
    public int IdProcesoNave { get; set; }

    public int IdProceso { get; set; }

    public int IdNave { get; set; }

    public virtual Nave IdNaveNavigation { get; set; } = null!;

    public virtual Proceso IdProcesoNavigation { get; set; } = null!;
}
