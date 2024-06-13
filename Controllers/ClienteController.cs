using ConsumirAPILibreria.Models;
using ConsumirAPILibreria.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirAPILibreria.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IServicioCliente _servicioAPI;

        public ClienteController(IServicioCliente servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Guardar(Cliente ObjCliente)
        {
            Console.WriteLine(ObjCliente);
            bool respuesta = false;

            if (ObjCliente.Id == Guid.Empty)
            {
                respuesta = await _servicioAPI.Insertar(ObjCliente);
            }
            else
            {
                respuesta = await _servicioAPI.Modificar(ObjCliente);
            }
            return Json(new { resultado = respuesta });
        }

        public async Task<IActionResult> Obtener()
        {
            List<Cliente> lista = await _servicioAPI.lista();

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
