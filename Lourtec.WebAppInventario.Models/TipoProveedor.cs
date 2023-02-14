using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class TipoProveedor
{
    public int TipoProveedorId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Proveedor> Proveedor { get; } = new List<Proveedor>();
}
