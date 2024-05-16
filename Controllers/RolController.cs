using ConsumirAPILibreria.Models;
using ConsumirAPILibreria.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirAPILibreria.Controllers
{
    public class RolController : Controller
    {
        private readonly IServicioRol _servicioAPI;

        public RolController(IServicioRol servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }


        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Guardar(Rol ObjRol)
        {

            bool respuesta = false;

            if (ObjRol.Id == Guid.Empty)
            {

                respuesta = await _servicioAPI.Insertar(ObjRol);
            }
            else
            {
                respuesta = await _servicioAPI.Modificar(ObjRol);
            }
            return Json(new { resultado = respuesta });
        }

        public async Task<IActionResult> Obtener()
        {
            List<Rol> lista = await _servicioAPI.lista();

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
