using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioMaterial
    {

        public Task<List<Material>> lista();

        public Task<bool> Modificar(Material material);

        public Task<bool> Insertar(Material material);

        public Task<bool> Delete(Guid id);

    }
}
