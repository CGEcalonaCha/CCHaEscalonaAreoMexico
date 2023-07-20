using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SL1.Controllers
{
    public class VueloController : Controller
    {
        [HttpGet]
        [Route("api/Vuelo/GetAll")]
        public IActionResult GetAll(DateTime FechaInicio, DateTime FechaFinal)
        {

            ML.Result result = BL.Vuelo.GetAll(FechaInicio, FechaFinal);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return BadRequest(result);
            }
            //return View();
        }
       

    }
}
