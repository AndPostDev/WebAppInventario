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

    public virtual ICollection<Existencia> Existencia { get; } = new List<Existencia>();

    public virtual ICollection<Ingreso> Ingreso { get; } = new List<Ingreso>();

    public virtual Provincia? Provincia { get; set; }

    public virtual ICollection<Salida> Salida { get; } = new List<Salida>();
}
