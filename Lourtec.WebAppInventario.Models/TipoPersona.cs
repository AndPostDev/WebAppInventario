using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class TipoPersona
{
    public int TipoPersonaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Proveedor> Proveedors { get; } = new List<Proveedor>();
}
