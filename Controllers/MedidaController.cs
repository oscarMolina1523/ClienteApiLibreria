using ConsumirAPILibreria.Models;
using ConsumirAPILibreria.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirAPILibreria.Controllers
{
    public class MedidaController : Controller
    {
        private readonly IServicioMedida _servicioAPI;

        public MedidaController(IServicioMedida servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Guardar(UnidadMedida ObjMedida)
        {

            bool respuesta = false;

            if (ObjMedida.Id == Guid.Empty)
            {

                respuesta = await _servicioAPI.Insertar(ObjMedida);
            }
            else
            {
                respuesta = await _servicioAPI.Modificar(ObjMedida);
            }
            return Json(new { resultado = respuesta });
        }

        public async Task<IActionResult> Obtener()
        {
            List<UnidadMedida> lista = await _servicioAPI.lista();

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
