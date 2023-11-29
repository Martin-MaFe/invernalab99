using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Sensor
{
    public int IdSensor { get; set; }

    public string? TipoSensor { get; set; }

    public double? ValorMaximoFabricante { get; set; }

    public double? ValorMinimoFabricante { get; set; }

    public virtual ICollection<Intervalo> Intervalos { get; set; } = new List<Intervalo>();

    public virtual ICollection<ReporteSensor> ReporteSensors { get; set; } = new List<ReporteSensor>();
}
