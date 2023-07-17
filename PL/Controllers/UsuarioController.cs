using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string userName, string contrasena)
        {
            ML.Result result = BL.Usuario.GetByUserName(userName);

            if (result.Correct)//si el usuario existe
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                if (contrasena == usuario.Contrasena)
                {
                    return RedirectToAction("Index", "Home");

                    
                }
                else
                {
                    ViewBag.Mensaje = "Contraseña invalida";
                    return PartialView("ModalLogin");
                }
            }
            else
            {
                ViewBag.Mensaje = "Usuario invalido";
                return PartialView("ModalLogin");
            }
        }
    }
}
