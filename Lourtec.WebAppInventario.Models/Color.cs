using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class Color
{
    public int ColorId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? ProductoId { get; set; }

    public virtual Producto? Producto { get; set; }
}
