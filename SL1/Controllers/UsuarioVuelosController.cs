using Microsoft.AspNetCore.Mvc;

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
    }
}
