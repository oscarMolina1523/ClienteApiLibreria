using ConsumirAPILibreria.Models;
using ConsumirAPILibreria.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirAPILibreria.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IServicioProducto _servicioAPI;

        public ProductoController(IServicioProducto servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Guardar(Producto producto)
        {
            Console.WriteLine(producto);
            bool respuesta = false;

            if (producto.Id == Guid.Empty)
            {

                respuesta = await _servicioAPI.Insertar(producto);
            }
            else
            {
                respuesta = await _servicioAPI.Modificar(producto);
            }
            return Json(new { resultado = respuesta });
        }

        public async Task<IActionResult> Obtener()
        {
            List<Producto> lista = await _servicioAPI.lista();

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
