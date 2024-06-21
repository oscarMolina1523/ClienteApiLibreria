using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioProducto
    {
        public Task<List<Producto>> lista();

        public Task<bool> Modificar(Producto producto);

        public Task<bool> Insertar(Producto producto);

        public Task<bool> Delete(Guid id);
    }
}
