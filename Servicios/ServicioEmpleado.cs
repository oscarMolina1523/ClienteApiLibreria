using ConsumirAPILibreria.Models;
using Newtonsoft.Json;
using System.Text;

namespace ConsumirAPILibreria.Servicios
{
    public class ServicioEmpleado : IServicioEmpleado
    {
        public static string _baseUrl;

        public ServicioEmpleado()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<bool> Delete(Guid id)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.DeleteAsync($"/Empleado/EliminarEmpleado/{id}");
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> Insertar(Empleado empleado)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(empleado), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("/Empleado/CrearEmpleado", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<List<Empleado>> lista()
        {
            List<Empleado> lista = new List<Empleado>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("/Empleado/Listar");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Empleado>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        public async Task<bool> Modificar(Empleado empleado)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(empleado), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("/Empleado/ModificarEmpleado", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
