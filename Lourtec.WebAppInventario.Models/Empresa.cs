using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Empresa
{
    public int EmpresaId { get; set; }

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Bodega> Bodega { get; } = new List<Bodega>();

    public virtual ICollection<Proveedor> Proveedor { get; } = new List<Proveedor>();

    public virtual ICollection<Usuario> Usuario { get; } = new List<Usuario>();
}
