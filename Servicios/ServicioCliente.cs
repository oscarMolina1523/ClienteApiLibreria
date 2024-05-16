using ConsumirAPILibreria.Models;
using Newtonsoft.Json;
using System.Text;

namespace ConsumirAPILibreria.Servicios
{
    public class ServicioCliente : IServicioCliente
    {
        public static string _baseUrl;

        public ServicioCliente()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<bool> Delete(Guid id)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.DeleteAsync($"/Cliente/EliminarCliente/{id}");
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> Insertar(Cliente Objcliente)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(Objcliente), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("/Cliente/CrearCliente", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<List<Cliente>> lista()
        {
            List<Cliente> lista = new List<Cliente>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("/Cliente/Listar");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Cliente>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        public async Task<bool> Modificar(Cliente Objcliente)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(Objcliente), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("/Cliente/ModificarCliente", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
