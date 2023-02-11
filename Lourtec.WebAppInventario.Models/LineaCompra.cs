using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class LineaCompra
{
    public int LineaCompraId { get; set; }

    public int? OrdenCompraId { get; set; }

    public int? ProductoId { get; set; }

    public DateTime Fecha { get; set; }

    public int Cantidad { get; set; }

    public double Descuento { get; set; }

    public double Impuestos { get; set; }

    public double Total { get; set; }

    public virtual OrdenCompra? OrdenCompra { get; set; }

    public virtual Producto? Producto { get; set; }
}
