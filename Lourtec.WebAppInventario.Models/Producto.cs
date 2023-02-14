using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public int? Codigo { get; set; }

    public int? LineaId { get; set; }

    public int? TipoId { get; set; }

    public int? Unidad { get; set; }

    public int? Caja { get; set; }

    public int? GrupoId { get; set; }

    public bool? Activo { get; set; }

    public bool? Iva { get; set; }

    public bool? Perecible { get; set; }

    public string? Comentario { get; set; }

    public DateTime? FechaCaducidad { get; set; }

    public double Precio { get; set; }

    public virtual ICollection<Color> Color { get; } = new List<Color>();

    public virtual ICollection<Existencia> Existencia { get; } = new List<Existencia>();

    public virtual Grupo? Grupo { get; set; }

    public virtual ICollection<IngresoDetalle> IngresoDetalle { get; } = new List<IngresoDetalle>();

    public virtual Linea? Linea { get; set; }

    public virtual ICollection<LineaCompra> LineaCompra { get; } = new List<LineaCompra>();

    public virtual ICollection<LineaSalida> LineaSalida { get; } = new List<LineaSalida>();

    public virtual ICollection<Marca> Marca { get; } = new List<Marca>();

    public virtual ICollection<Medida> Medida { get; } = new List<Medida>();

    public virtual Tipo? Tipo { get; set; }
}
