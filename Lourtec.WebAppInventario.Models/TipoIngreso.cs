using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class TipoIngreso
{
    public int TipoIngresoId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Ingreso> Ingreso { get; } = new List<Ingreso>();
}
