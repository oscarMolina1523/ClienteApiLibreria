using ConsumirAPILibreria.Models;
using Newtonsoft.Json;

namespace ConsumirAPILibreria.Servicios
{
    public class ServicioAPI : IServicioAPI
    {
        public static string _baseUrl;

        public ServicioAPI()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            _baseUrl = builder.GetSection("ApiSetting:baseUrl").Value;
        }

        public async Task<List<ModeloCategoria>> lista()
        {
            List<ModeloCategoria> lista = new List<ModeloCategoria>();

            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri(_baseUrl);

            var response = await cliente.GetAsync("/Categoria/Listar");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta= await response.Content.ReadAsStringAsync();

                var resultado= JsonConvert.DeserializeObject<List<ModeloCategoria>>(json_respuesta);

                lista = resultado;
            }

            return lista;
        }
    }
}
