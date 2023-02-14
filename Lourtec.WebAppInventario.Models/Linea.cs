using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class Linea
{
    public int LineaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Producto { get; } = new List<Producto>();
}
