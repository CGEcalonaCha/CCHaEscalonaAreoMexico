﻿using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Email { get; set; }

    public string? UserName { get; set; }

    public string? Contrasena { get; set; }

    public virtual ICollection<UsuarioVuelo> UsuarioVuelos { get; set; } = new List<UsuarioVuelo>();
}
