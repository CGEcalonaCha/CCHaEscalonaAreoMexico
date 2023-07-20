using System;
using System.Collections.Generic;

namespace DL;

public partial class Vuelo
{
    public int IdVuelos { get; set; }

    public string? NumeroVuelo { get; set; }

    public decimal? Origen { get; set; }

    public decimal? Destino { get; set; }

    public DateTime? FechaSalida { get; set; }

    public virtual ICollection<UsuarioVuelo> UsuarioVuelos { get; set; } = new List<UsuarioVuelo>();
}
