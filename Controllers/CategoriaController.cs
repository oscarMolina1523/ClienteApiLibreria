using ConsumirAPILibreria.Models;
using ConsumirAPILibreria.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConsumirAPILibreria.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly IServicioAPI _servicioAPI;

        public CategoriaController(IServicioAPI servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Obtener()
        {
            List<ModeloCategoria> lista = await _servicioAPI.lista();

            return Json(new{data=lista });
        }
        [ResponseCache(Duration =0,Location =ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }) ;
        }


    }
}
