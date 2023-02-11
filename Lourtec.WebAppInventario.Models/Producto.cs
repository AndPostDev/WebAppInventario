using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public int Codigo { get; set; }

    public int? LineaId { get; set; }

    public int? Tipo { get; set; }

    public int? Unidad { get; set; }

    public int? Caja { get; set; }

    public int? Grupo { get; set; }

    public bool Activo { get; set; }

    public bool Iva { get; set; }

    public bool? Perecible { get; set; }

    public string? Comentario { get; set; }

    public DateTime? FechaCaducidad { get; set; }

    public double Precio { get; set; }

    public virtual ICollection<Color> Colors { get; } = new List<Color>();

    public virtual ICollection<Existencium> Existencia { get; } = new List<Existencium>();

    public virtual Grupo? GrupoNavigation { get; set; }

    public virtual ICollection<IngresoDetalle> IngresoDetalles { get; } = new List<IngresoDetalle>();

    public virtual Linea? Linea { get; set; }

    public virtual ICollection<LineaCompra> LineaCompras { get; } = new List<LineaCompra>();

    public virtual ICollection<LineaSalidum> LineaSalida { get; } = new List<LineaSalidum>();

    public virtual ICollection<Marca> Marcas { get; } = new List<Marca>();

    public virtual ICollection<Medidum> Medida { get; } = new List<Medidum>();

    public virtual Tipo? TipoNavigation { get; set; }
}
