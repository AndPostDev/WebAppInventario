using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class Motivo
{
    public int MotivoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ingreso> Ingreso { get; } = new List<Ingreso>();

    public virtual ICollection<Salida> Salida { get; } = new List<Salida>();
}
