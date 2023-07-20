using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SL1.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        [Route("api/Usuario/GetAll")]
        public IActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Usuario/Add")]
        public IActionResult Add([FromBody] ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpGet]
        [Route("api/Usuario/GetByUserName/{Usuario}/{Password}")]
        public IActionResult GetByUserName(string Usuario, string Contrasena)
        {

            ML.Result result = BL.Usuario.GetByUserName(Usuario);
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;

                if (Contrasena == usuario.Contrasena)
                {
                    result.ErrorMessage = "Autorice";
                    return Ok(result.ErrorMessage);

                }
                else
                {
                    result.ErrorMessage = "No Autorice";
                    return NotFound(result.ErrorMessage);
                }
            }
            else
            {
                ViewBag.Mensaje = "Usuario no existe";
                return PartialView("ModalLogin");
            }
        }
    }
}
