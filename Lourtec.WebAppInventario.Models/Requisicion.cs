using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class Requisicion
{
    public int RequisicionId { get; set; }

    public string CodigoRequisicion { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public int? OrdenCompraId { get; set; }

    public string? Comentario { get; set; }

    public virtual Departamento? OrdenCompra { get; set; }

    public virtual ICollection<Salida> Salida { get; } = new List<Salida>();
}
