using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SL1.Controllers
{
    public class PasajeroController : Controller
    {
        [HttpPost]
        [Route("api/Usuario/RegistrarPasajero")]
        public IActionResult RegistrarPasajero([Required] string NombrePasajero, [Required] string ApellidoPaternio, string ApellidoMaternio)
        {
            ML.Result result = BL.Pasajero.RegistrarPasajero(NombrePasajero, ApellidoMaternio, ApellidoPaternio);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
