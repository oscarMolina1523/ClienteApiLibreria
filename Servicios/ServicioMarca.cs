using ConsumirAPILibreria.Models;
using Newtonsoft.Json;
using System.Text;

namespace ConsumirAPILibreria.Servicios
{
    public class ServicioMarca : IServicioMarca
    {

        public static string _baseUrl;

        public ServicioMarca()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<bool> Delete(Guid id)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.DeleteAsync($"/Marca/EliminarMarca/{id}");
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> Insertar(Marca marca)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(marca), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("/Marca/CrearMarca", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<List<Marca>> lista()
        {
            List<Marca> lista = new List<Marca>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("/Marca/Listar");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Marca>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        public async Task<bool> Modificar(Marca marca)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(marca), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("/Marca/ModificarMarca", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
