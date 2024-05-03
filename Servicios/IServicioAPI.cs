using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioAPI
    {
       public Task<List<ModeloCategoria>> lista();

        public Task<bool> Modificar(ModeloCategoria categoria);

        public Task<bool> Insertar(ModeloCategoria mc);

        public Task<bool> Delete(Guid id);
    }
}
