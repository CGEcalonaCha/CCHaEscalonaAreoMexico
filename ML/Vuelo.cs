using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Vuelo
    {

        public int IdVuelo { get; set; }
        [StringLength(20, ErrorMessage = "No puede ser mas de 20", MinimumLength = 4)]
        public string NumeroVuelo { get; set; }
        [StringLength(20, ErrorMessage = "No puede ser mas de 20", MinimumLength = 2)]
        public decimal Origen { get; set; }
        [StringLength(20, ErrorMessage = "No puede ser mas de 20", MinimumLength = 2)]
        public decimal Destino { get; set; }
        public string FechaSalida { get; set; }
        public List<Object> Vuelos { get; set; }
    }
}
