using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Intervalo
{
    public int IdIntervalo { get; set; }

    public int IdProceso { get; set; }

    public int IdSensor { get; set; }

    public double ValorMinimo { get; set; }

    public double ValorMaximo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Accion { get; set; }

    public DateTime? Fecha { get; set; }

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public virtual Proceso IdProcesoNavigation { get; set; } = null!;

    public virtual Sensor IdSensorNavigation { get; set; } = null!;
}
