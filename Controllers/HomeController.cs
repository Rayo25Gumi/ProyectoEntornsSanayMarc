using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Newtonsoft.Json;

namespace mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index() // Función que carga la página
    {
        const string apiImage = "https://api.thecatapi.com/v1/images/search"; // API de imagen
        const string apiFact = "https://catfact.ninja/fact"; // API de frase

        var client = new HttpClient(); // Cliente para hacer las peticiones

        var responseImagen = client.GetAsync(apiImage).Result; // Pido la imagen
        var contentImagen = responseImagen.Content.ReadAsStringAsync().Result; // Guardo la respuesta como texto
        var imagenconlista = JsonConvert.DeserializeObject<List<Gato>>(contentImagen); // Convierto el texto en lista
        var imagenFinal = imagenconlista[0]; // Cojo la primera imagen

        var responseFact = client.GetAsync(apiFact).Result; // Pido la frase
        var contentFact = responseFact.Content.ReadAsStringAsync().Result; // Guardo la respuesta como texto
        var factFinal = JsonConvert.DeserializeObject<Gato>(contentFact); // Convierto el texto en objeto

        var model = new Gato // Junto la imagen y la frase en un solo modelo
        {
            Url = imagenFinal.Url,
            Fact = factFinal.Fact,
        };

        return View(model); // Mando el modelo a la vista
    }
}
