using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Bodega
{
    public int BodegaId { get; set; }

    public int? EmpresaId { get; set; }

    public string Direccion { get; set; } = null!;

    public int? ProvinciaId { get; set; }

    public int? EstadoId { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<Existencium> Existencia { get; } = new List<Existencium>();

    public virtual ICollection<Ingreso> Ingresos { get; } = new List<Ingreso>();

    public virtual Provincium? Provincia { get; set; }

    public virtual ICollection<Salidum> Salida { get; } = new List<Salidum>();
}
