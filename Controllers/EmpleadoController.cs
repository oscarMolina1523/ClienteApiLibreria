using ConsumirAPILibreria.Models;
using ConsumirAPILibreria.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirAPILibreria.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IServicioEmpleado _servicioAPI;

        public EmpleadoController(IServicioEmpleado servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Guardar(Empleado empleado)
        {
            Console.WriteLine(empleado);
            bool respuesta = false;

            if (empleado.Id == Guid.Empty)
            {

                respuesta = await _servicioAPI.Insertar(empleado);
            }
            else
            {
                respuesta = await _servicioAPI.Modificar(empleado);
            }
            return Json(new { resultado = respuesta });
        }

        public async Task<IActionResult> Obtener()
        {
            List<Empleado> lista = await _servicioAPI.lista();

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
