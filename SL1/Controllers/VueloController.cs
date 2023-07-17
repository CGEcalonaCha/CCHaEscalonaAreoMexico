using Microsoft.AspNetCore.Mvc;

namespace SL1.Controllers
{
    public class VueloController : Controller
    {
        [HttpGet]
        [Route("api/Vuelo/GetAll")]
        public IActionResult GetAll()
        {
            ML.Vuelo vuelo = new ML.Vuelo();

            ML.Result result = BL.Vuelo.GetAll(vuelo);

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
        [Route("api/Vuelo/Add")]
        public IActionResult Add([FromBody] ML.Vuelo vuelo)
        {
            ML.Result result = BL.Vuelo.Add(vuelo);

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
