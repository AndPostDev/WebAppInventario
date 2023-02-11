using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class LineaSalidum
{
    public int LineaSalidaId { get; set; }

    public int? SalidaId { get; set; }

    public int Cantidad { get; set; }

    public int? ProductoId { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Salidum? Salida { get; set; }
}
