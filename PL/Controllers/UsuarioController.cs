using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        private IConfiguration configuration;
        public UsuarioController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Usuarios = new List<object>();


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configuration["WebApi"]);

                var responseTask = client.GetAsync("Usuario/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;


                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                        usuario.Usuarios.Add(resultItemList);
                    }
                }
            }

            return View(usuario);
        }
        [HttpGet]
        public IActionResult Form(int? idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();


            if (idUsuario == null)
            {
                return View(usuario);

            }
            else
            {

                return View(usuario);
            }
        }
        [HttpPost]
        public IActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            if (usuario.IdUsuario == 0)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(configuration["WebApi"]);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/Add", usuario);
                    postTask.Wait();

                    var libroresult = postTask.Result;
                    if (libroresult.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se agrego correctamente el libro";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error al agregar el libro";
                    }
                }
            }
            else
            {
            }
            return View("Modal");
        }
    }
}
