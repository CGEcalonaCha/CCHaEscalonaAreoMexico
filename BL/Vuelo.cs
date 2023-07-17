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
        public static ML.Result GetAll(ML.Vuelo vuelo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CescalonaAeroMexicoContext context = new DL.CescalonaAeroMexicoContext())
                {
                    var RowsAfected = context.Vuelos.FromSqlRaw($"VuelosGetAll'{vuelo.FechaSalida}' ").ToList();

                    result.Objects = new List<object>();

                    if (context != null)
                    {
                        foreach (var obj in RowsAfected)
                        {

                            vuelo.IdVuelo = obj.IdVuelos;
                            vuelo.NumeroVuelo = obj.NumeroVuelo;
                            vuelo.Origen = obj.Origen.Value;
                            vuelo.Destino = obj.Destino.Value;
                            vuelo.FechaSalida = obj.FechaSalida;


                            result.Objects.Add(vuelo);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Vuelo vuelo)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CescalonaAeroMexicoContext context = new DL.CescalonaAeroMexicoContext())
                {
                    int RowsAfected = context.Database.ExecuteSqlRaw($"VuelosAdd '{vuelo.NumeroVuelo}', '{vuelo.Origen}', '{vuelo.Destino}', '{vuelo.FechaSalida}'");

                    if (RowsAfected > 0)
                    {
                        result.Correct = true; ;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al ingresar el vuelo";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
