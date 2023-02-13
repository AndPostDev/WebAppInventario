using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Grupo
{
    public int GrupoId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto> Producto { get; } = new List<Producto>();
}
