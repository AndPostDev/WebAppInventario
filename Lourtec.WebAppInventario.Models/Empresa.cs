using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Empresa
{
    public int EmpresaId { get; set; }

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Bodega> Bodegas { get; } = new List<Bodega>();

    public virtual ICollection<Proveedor> Proveedors { get; } = new List<Proveedor>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
