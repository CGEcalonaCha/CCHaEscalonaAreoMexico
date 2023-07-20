using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UsuarioVuelo
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CescalonaAeroMexicoContext context = new DL.CescalonaAeroMexicoContext())
                {
                    var RowsAfected = context.UsuarioVuelos.FromSqlRaw($"UsuarioVuelosGetAll").ToList();

                    result.Objects = new List<object>();

                    if (context != null)
                    {
                        foreach (var obj in RowsAfected)
                        {
                            ML.UsuaioVuelo usuario = new ML.UsuaioVuelo();
                            usuario.IdUsuarioVuelos= obj.IdUsuarioVuelos;
                            usuario.Vuelo = new ML.Vuelo();
                            usuario.Vuelo.IdVuelo = obj.IdVuelos.Value;
                            usuario.Usuario = new ML.Usuario();
                            usuario.Usuario.IdUsuario = obj.IdUsuario.Value;
                            usuario.Pasajero = new ML.Pasajero();
                            usuario.Pasajero.IdPasajero = obj.IdPasajero.Value;


                             result.Objects.Add(usuario);
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
        public static ML.Result Add(int IdUsuario, int NumeroVuelo, int Pasajero)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CescalonaAeroMexicoContext context = new DL.CescalonaAeroMexicoContext())
                {
                    int FilasAfectadas = context.Database.ExecuteSqlRaw($"UsuarioVuelosAdd {IdUsuario},{NumeroVuelo}, {Pasajero}");
                    if (FilasAfectadas > 0)
                    {
                        result.ErrorMessage = "El Vuelo se a reservado correctamente";
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
