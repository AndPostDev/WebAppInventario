using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Requisicion
{
    public int RequisicionId { get; set; }

    public int CodigoRequisicion { get; set; }

    public DateTime Fecha { get; set; }

    public string? Solicitado { get; set; }

    public string? Comentario { get; set; }

    public virtual ICollection<Salidum> Salida { get; } = new List<Salidum>();
}
