using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class ReporteSensor
{
    public int IdReporteSensor { get; set; }

    public double ValorMinimoLectura { get; set; }

    public double ValorMaximoLectura { get; set; }

    public DateTime Fecha { get; set; }

    public int IdSensor { get; set; }

    public virtual Sensor IdSensorNavigation { get; set; } = null!;
}
