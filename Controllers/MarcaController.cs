using ConsumirAPILibreria.Models;
using ConsumirAPILibreria.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirAPILibreria.Controllers
{
    public class MarcaController : Controller
    {

        private readonly IServicioMarca _servicioAPI;

        public MarcaController(IServicioMarca servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Guardar(Marca ObjMarca)
        {

            bool respuesta = false;

            if (ObjMarca.Id == Guid.Empty)
            {

                respuesta = await _servicioAPI.Insertar(ObjMarca);
            }
            else
            {
                respuesta = await _servicioAPI.Modificar(ObjMarca);
            }
            return Json(new { resultado = respuesta });
        }

        public async Task<IActionResult> Obtener()
        {
            List<Marca> lista = await _servicioAPI.lista();

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
