using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class Pasajero
    {
        public static ML.Result RegistrarPasajero(string NombrePasajero, string ApellidoPaterno, string ApellidoMaterno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CescalonaAeroMexicoContext context = new DL.CescalonaAeroMexicoContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"PasajeroAdd '{NombrePasajero}','{ApellidoPaterno}','{ApellidoMaterno}'");
                    if (query > 0)
                    {
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
                result.Correct = false;
            }
            return result;
        }
    }
}
