using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Maquinarium
{
    public int IdMaquinaria { get; set; }

    public string NombreMaquinaria { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public virtual ICollection<ProcesoActividadMaquinarium> ProcesoActividadMaquinaria { get; set; } = new List<ProcesoActividadMaquinarium>();
}
