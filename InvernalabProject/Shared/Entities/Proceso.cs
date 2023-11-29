using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Proceso
{
    public int IdProceso { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaInicio { get; set; }

    public string? Descripcion { get; set; }

    public int Compartir { get; set; }

    public DateTime? FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public int IdProducto { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual ICollection<Intervalo> Intervalos { get; set; } = new List<Intervalo>();

    public virtual ICollection<ProcesoActividad> ProcesoActividads { get; set; } = new List<ProcesoActividad>();

    public virtual ICollection<ProcesoNave> ProcesoNaves { get; set; } = new List<ProcesoNave>();
}
