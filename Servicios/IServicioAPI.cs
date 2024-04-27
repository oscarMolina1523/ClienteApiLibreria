using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioAPI
    {
       public Task<List<ModeloCategoria>> lista();
    }
}
