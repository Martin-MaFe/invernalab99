using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string Caracteristicas { get; set; } = null!;

    public DateTime? FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
