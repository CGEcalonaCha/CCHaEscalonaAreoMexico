using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class VueloController : Controller
    {
        private IConfiguration configuration;
        public VueloController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        //[HttpPost]
        //public ActionResult GetAll(ML.Vuelo vuelo)
        //{

        //    //ML.Usuario usuario = new ML.Usuario();
        //    ML.Result result = BL.Vuelo.GetAll(vuelo);
        //    vuelo.Vuelos = result.Objects;
        //    if (result.Correct)
        //    {
        //        vuelo.Vuelos = result.Objects;
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Ocurrio un error al hacer la consulta de alumnos" + result.ErrorMessage;
        //    }
        //    return View(vuelo);
        //}
        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    ML.Vuelo vuelo = new ML.Vuelo();
        //    vuelo.Vuelos = new List<object>();


        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(configuration["WebApi"]);

        //        var responseTask = client.GetAsync("Vuelo/GetAll");
        //        responseTask.Wait();

        //        var result = responseTask.Result;


        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<ML.Result>();
        //            readTask.Wait();

        //            foreach (var resultItem in readTask.Result.Objects)
        //            {
        //                ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Vuelo>(resultItem.ToString());
        //                vuelo.Vuelos.Add(resultItemList);
        //            }
        //        }
        //    }

        //    return View(vuelo);
        //}
    }
}
