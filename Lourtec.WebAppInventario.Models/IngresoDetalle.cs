using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class IngresoDetalle
{
    public int IngresoDetalleId { get; set; }

    public int? ProductoId { get; set; }

    public int? IngresoId { get; set; }

    public double Precio { get; set; }

    public double Descuento { get; set; }

    public double Impuestos { get; set; }

    public double Total { get; set; }

    public virtual Ingreso? Ingreso { get; set; }

    public virtual Producto? Producto { get; set; }
}
