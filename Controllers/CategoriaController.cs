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

        public async Task<IActionResult> Guardar(ModeloCategoria ObjCat)
        {
            Console.WriteLine(ObjCat);

            bool respuesta = false;

            if (ObjCat.Id==Guid.Empty)
            {

                respuesta = await _servicioAPI.Insertar(ObjCat);
            }
            else
            {
                respuesta =await _servicioAPI.Modificar(ObjCat);
            }
            return Json(new { resultado = respuesta });
        }


        public async Task<IActionResult> Obtener()
        {
            List<ModeloCategoria> lista = await _servicioAPI.lista();

            return Json(new { data = lista });
        }

        public async Task<IActionResult> Eliminar(Guid cod)
        {
            bool respuesta = false;

            Console.WriteLine(cod);

            if (cod != null)
            {

                respuesta = await _servicioAPI.Delete(cod);
            }

           return Json(new { resultado = respuesta });
        }


    }
}
