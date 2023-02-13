using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Medida
{
    public int MedidaId { get; set; }

    public string Dimension { get; set; } = null!;

    public int? ProductoId { get; set; }

    public virtual Producto? Producto { get; set; }
}
