using Microsoft.AspNetCore.Mvc;

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
        
    }
}
