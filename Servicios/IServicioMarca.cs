using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioMarca
    {
        public Task<List<Marca>> lista();

        public Task<bool> Modificar(Marca marca);

        public Task<bool> Insertar(Marca marca);

        public Task<bool> Delete(Guid id);
    }
}
