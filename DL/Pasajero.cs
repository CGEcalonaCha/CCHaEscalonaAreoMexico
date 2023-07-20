using System;
using System.Collections.Generic;

namespace DL;

public partial class Pasajero
{
    public int IdPasajero { get; set; }

    public string? NumeroPasajero { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public virtual ICollection<UsuarioVuelo> UsuarioVuelos { get; set; } = new List<UsuarioVuelo>();
}
