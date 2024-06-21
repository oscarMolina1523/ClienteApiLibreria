using ConsumirAPILibreria.Models;
using ConsumirAPILibreria.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirAPILibreria.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly IServicioProveedor _servicioAPI;

        public ProveedorController(IServicioProveedor servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Guardar(Proveedor proveedor)
        {
            Console.WriteLine(proveedor);
            bool respuesta = false;

            if (proveedor.Id == Guid.Empty)
            {

                respuesta = await _servicioAPI.Insertar(proveedor);
            }
            else
            {
                respuesta = await _servicioAPI.Modificar(proveedor);
            }
            return Json(new { resultado = respuesta });
        }

        public async Task<IActionResult> Obtener()
        {
            List<Proveedor> lista = await _servicioAPI.lista();

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
