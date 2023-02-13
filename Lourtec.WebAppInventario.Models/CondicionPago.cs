using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class CondicionPago
{
    public int CondicionPagoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<OrdenCompra> OrdenCompra { get; } = new List<OrdenCompra>();
}
