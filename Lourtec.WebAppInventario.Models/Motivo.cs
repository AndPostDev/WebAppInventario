using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Motivo
{
    public int MotivoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Ingreso> Ingresos { get; } = new List<Ingreso>();

    public virtual ICollection<Salidum> Salida { get; } = new List<Salidum>();
}
