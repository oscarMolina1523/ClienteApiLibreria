using ConsumirAPILibreria.Models;
using ConsumirAPILibreria.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirAPILibreria.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IServicioMaterial _servicioAPI;

        public MaterialController(IServicioMaterial servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Guardar(Material ObjMaterial)
        {

            bool respuesta = false;

            if (ObjMaterial.Id == Guid.Empty)
            {

                respuesta = await _servicioAPI.Insertar(ObjMaterial);
            }
            else
            {
                respuesta = await _servicioAPI.Modificar(ObjMaterial);
            }
            return Json(new { resultado = respuesta });
        }

        public async Task<IActionResult> Obtener()
        {
            List<Material> lista = await _servicioAPI.lista();

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
