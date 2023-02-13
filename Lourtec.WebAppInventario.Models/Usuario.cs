using System;
using System.Collections.Generic;

namespace Lourtec.WebAppInventario.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public int Correo { get; set; }

    public string Password { get; set; } = null!;

    public int? EmpresaId { get; set; }

    public virtual Empresa? Empresa { get; set; }
}
