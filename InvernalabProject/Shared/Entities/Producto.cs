using System;
using System.Collections.Generic;

namespace InvernalabProject.Shared.Entities;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public string? Caracteristicas { get; set; }

    public DateTime FechaInsert { get; set; }

    public DateTime? FechaUpdate { get; set; }

    public int IdCategoria { get; set; }

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Proceso> Procesos { get; set; } = new List<Proceso>();
}
