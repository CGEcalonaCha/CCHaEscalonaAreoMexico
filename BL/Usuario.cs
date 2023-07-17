using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CescalonaAeroMexicoContext context = new DL.CescalonaAeroMexicoContext())
                {
                    var RowsAfected = context.Usuarios.FromSqlRaw($"UsuarioGetAll").ToList();

                    result.Objects = new List<object>();

                    if (context != null)
                    {
                        foreach (var objUsuario in RowsAfected)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = objUsuario.IdUsuario;
                            usuario.Nombre = objUsuario.Nombre;
                            usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                            usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                            usuario.UserName = objUsuario.UserName;
                            usuario.Email = objUsuario.Email;
                            usuario.Contrasena = objUsuario.Contrasena;

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
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CescalonaAeroMexicoContext context = new DL.CescalonaAeroMexicoContext())
                {
                    int RowsAfected = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}', '{usuario.Email}', '{usuario.UserName}', '{usuario.Contrasena}'");

                    if (RowsAfected > 0)
                    {
                        result.Correct = true; ;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al ingresar el usuario";
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
        public static ML.Result GetByUserName(string userName)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.CescalonaAeroMexicoContext context = new DL.CescalonaAeroMexicoContext())
                {
                    var objUsuario = context.Usuarios.FromSqlRaw($"UsuarioGetByUserName {userName} ").AsEnumerable().FirstOrDefault();

                    //result.Objects = new List<object>();

                    if (objUsuario != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.UserName = objUsuario.UserName;
                        usuario.Contrasena = objUsuario.Contrasena;

                        

                        result.Object = usuario; //boxing


                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Ocurrio un erro al obtener los regristro en la tabla";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = !false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
