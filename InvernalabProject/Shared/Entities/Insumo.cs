using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Insumo
{
    public int IdInsumo { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaCaducidad { get; set; }

    public string? Descripcion { get; set; }

    public double Cantidad { get; set; }

    public string? Imagen { get; set; }

    public string Presentacion { get; set; } = null!;

    public double Medida { get; set; }

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public virtual ICollection<ProcesoActividadInsumo> ProcesoActividadInsumos { get; set; } = new List<ProcesoActividadInsumo>();
}
