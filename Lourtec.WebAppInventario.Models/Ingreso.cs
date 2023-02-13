using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Ingreso
{
    public int IngresoId { get; set; }

    public int CodigoIngreso { get; set; }

    public int? ProveedorId { get; set; }

    public int? MotivoId { get; set; }

    public int? BodegaId { get; set; }

    public DateTime Fecha { get; set; }

    public virtual Bodega? Bodega { get; set; }

    public virtual ICollection<IngresoDetalle> IngresoDetalle { get; } = new List<IngresoDetalle>();

    public virtual Motivo? Motivo { get; set; }

    public virtual Proveedor? Proveedor { get; set; }
}
