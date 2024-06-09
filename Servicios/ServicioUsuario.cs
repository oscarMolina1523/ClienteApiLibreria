using ConsumirAPILibreria.Models;
using Newtonsoft.Json;
using System.Text;

namespace ConsumirAPILibreria.Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        public static string _baseUrl;

        public ServicioUsuario()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<bool> Delete(Guid id)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.DeleteAsync($"/Usuario/EliminarUsuario/{id}");
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> Insertar(Usuario usuario)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("/Usuario/CrearUsuario", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<List<Usuario>> lista()
        {
            List<Usuario> lista = new List<Usuario>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("/Usuario/Listar");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<Usuario>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        public async Task<bool> Modificar(Usuario usuario)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("/Usuario/ModificarUsuario", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
