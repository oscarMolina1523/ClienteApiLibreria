using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioProveedor
    {
        public Task<List<Proveedor>> lista();

        public Task<bool> Modificar(Proveedor proveedor);

        public Task<bool> Insertar(Proveedor proveedor);

        public Task<bool> Delete(Guid id);
    }
}
