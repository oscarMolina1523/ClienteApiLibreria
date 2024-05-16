using ConsumirAPILibreria.Models;
using Newtonsoft.Json;
using System.Text;

namespace ConsumirAPILibreria.Servicios
{
    public class ServicioMedida : IServicioMedida
    {
        public static string _baseUrl;

        public ServicioMedida()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<bool> Delete(Guid id)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.DeleteAsync($"/Medida/EliminarMedida/{id}");
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> Insertar(UnidadMedida medida)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(medida), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync("/Medida/CrearMedida", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<List<UnidadMedida>> lista()
        {
            List<UnidadMedida> lista = new List<UnidadMedida>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("/Medida/Listar");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<UnidadMedida>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }

        public async Task<bool> Modificar(UnidadMedida medida)
        {
            bool respuesta = false;

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var content = new StringContent(JsonConvert.SerializeObject(medida), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync("/Medida/ModificarMedida", content);
            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
