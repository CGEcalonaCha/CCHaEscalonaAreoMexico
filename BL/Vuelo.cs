using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vuelo
    {
        public static ML.Result GetAll(DateTime FechaInicio, DateTime FechaFinal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CescalonaAeroMexicoContext context = new DL.CescalonaAeroMexicoContext())
                {
                    var query = context.Vuelos.FromSql($"VuelosGetAll {FechaInicio},{FechaFinal}").ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Vuelo vuelos = new ML.Vuelo();
                            vuelos.IdVuelo = obj.IdVuelos;
                            vuelos.NumeroVuelo = obj.NumeroVuelo;
                            vuelos.Origen = obj.Origen.Value;
                            vuelos.Destino = obj.Destino.Value;
                            vuelos.FechaSalida = obj.FechaSalida.Value.ToString("yyyy/MM/dd hh:mm:ss");

                            result.Objects.Add(vuelos);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception Ex)
            {

            }
            return result;
        }    
    }
}
