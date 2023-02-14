using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class Departamento
{
    public int DepartamentoId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<LineaCompra> LineaCompra { get; } = new List<LineaCompra>();

    public virtual ICollection<Requisicion> Requisicion { get; } = new List<Requisicion>();
}
