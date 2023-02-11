using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Estado
{
    public int EstadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Bodega> Bodegas { get; } = new List<Bodega>();

    public virtual ICollection<Proveedor> Proveedors { get; } = new List<Proveedor>();
}
