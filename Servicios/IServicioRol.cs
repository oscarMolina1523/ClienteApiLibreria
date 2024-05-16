using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioRol
    {
        public Task<List<Rol>> lista();

        public Task<bool> Modificar(Rol rol);

        public Task<bool> Insertar(Rol rol);

        public Task<bool> Delete(Guid id);
    }
}
