using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioAPI
    {
        Task<List<ModeloCategoria>> lista();
    }
}
