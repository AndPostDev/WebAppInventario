using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Salidum
{
    public int SalidaId { get; set; }

    public int Codigo { get; set; }

    public int? MotivoId { get; set; }

    public DateTime Fecha { get; set; }

    public string? Comentario { get; set; }

    public int? RequisicionId { get; set; }

    public int BodegaId { get; set; }

    public virtual Bodega Bodega { get; set; } = null!;

    public virtual ICollection<LineaSalidum> LineaSalida { get; } = new List<LineaSalidum>();

    public virtual Motivo? Motivo { get; set; }

    public virtual Requisicion? Requisicion { get; set; }
}
