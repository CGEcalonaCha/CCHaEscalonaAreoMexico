using System;
using System.Collections.Generic;

namespace DL;

public partial class UsuarioVuelo
{
    public int IdUsuarioVuelos { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdVuelos { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual Vuelo? IdVuelosNavigation { get; set; }
}
