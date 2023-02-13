using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class Provincia
{
    public int ProvinciaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Bodega> Bodega { get; } = new List<Bodega>();

    public virtual ICollection<Proveedor> Proveedor { get; } = new List<Proveedor>();
}
