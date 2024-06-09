using ConsumirAPILibreria.Models;
using ConsumirAPILibreria.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ConsumirAPILibreria.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IServicioUsuario _servicioAPI;

        public UsuarioController(IServicioUsuario servicioAPI)
        {
            _servicioAPI = servicioAPI;
        }

        public IActionResult Crear()
        {
            return View();
        }

        public async Task<IActionResult> Guardar(Usuario usuario)
        {

            bool respuesta = false;

            if (usuario.Id == Guid.Empty)
            {

                respuesta = await _servicioAPI.Insertar(usuario);
            }
            else
            {
                respuesta = await _servicioAPI.Modificar(usuario);
            }
            return Json(new { resultado = respuesta });
        }

        public async Task<IActionResult> Obtener()
        {
            List<Usuario> lista = await _servicioAPI.lista();

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
