using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class CondicionPago
{
    public int CondicionPagoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<OrdenCompra> OrdenCompra { get; } = new List<OrdenCompra>();
}
