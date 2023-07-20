using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SL1.Controllers
{
    public class UsuarioVuelosController : Controller
    {
        [HttpGet]
        [Route("api/UsuarioVuelo/GetAll")]
        public IActionResult GetAll()
        {
            ML.UsuaioVuelo vuelo = new ML.UsuaioVuelo();

            ML.Result result = BL.UsuarioVuelo.GetAll();

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
        [Route("api/UsuarioVuelo/UsuarioVuelosAdd")]
        public IActionResult Reservacion([Required] int IdUsuario, [Required] int NumeroVuelo, [Required] int Pasajero)
        {
            ML.Result result = BL.UsuarioVuelo.Add(IdUsuario,NumeroVuelo,Pasajero);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                result.ErrorMessage = "El vuelo no se pudo reservar";
                return StatusCode(500, result);
            }
        }

    }
}
