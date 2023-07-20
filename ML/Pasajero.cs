using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pasajero
    {
        public int IdPasajero { get; set; }

        [Required(ErrorMessage = "*Este campo es obligatoria*")]
        [RegularExpression("^[a-zA-z]+$", ErrorMessage = "*Este campo solo acepta letras*")]
        public string NombrePasajero { get; set; }

        [Required(ErrorMessage = "*Este campo es obligatoria*")]
        [RegularExpression("^[a-zA-z]+$", ErrorMessage = "*Este campo solo acepta letras*")]
        public string ApellidoPaternio { get; set; }
        public string ApellidoMaternio { get; set; }
    }
}
