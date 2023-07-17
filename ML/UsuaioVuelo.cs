using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class UsuaioVuelo
    {
        public int IdUsuarioVuelos { get; set; }
        public Usuario Usuario { get; set; }
        public Vuelo Vuelo { get; set; }
        public List<Object> UsuariosVuelos { get; set; }
    }
}
