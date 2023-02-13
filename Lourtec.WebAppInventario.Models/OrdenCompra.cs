using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class OrdenCompra
{
    public int OrdenCompraId { get; set; }

    public int? ProveedorId { get; set; }

    public int CodProveedor { get; set; }

    public string? Referencia { get; set; }

    public int? CondicionPagoId { get; set; }

    public string? Observacion { get; set; }

    public double Subtotal { get; set; }

    public virtual CondicionPago? CondicionPago { get; set; }

    public virtual ICollection<LineaCompra> LineaCompra { get; } = new List<LineaCompra>();

    public virtual Proveedor? Proveedor { get; set; }
}
