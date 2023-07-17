using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Vuelo
    {
        public int IdVuelo { get; set; }
        public string NumeroVuelo { get; set; }
        public decimal Origen { get; set; }
        public decimal Destino { get; set; }
        public string FechaSalida { get; set; }
        public List<Object> Vuelos { get; set; }
    }
}
