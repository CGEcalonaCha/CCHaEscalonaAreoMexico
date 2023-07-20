using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class UsuaioVuelo
    {
        public int IdUsuarioVuelos { get; set; }

        [Required(ErrorMessage = "*Este campo es obligatoria*")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "*Este campo es obligatoria*")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]

        public Vuelo Vuelo { get; set; }

        [Required(ErrorMessage = "*Este campo es obligatoria*")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]

        public Pasajero Pasajero { get; set; }
    }
}
