using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioMedida
    {
        public Task<List<UnidadMedida>> lista();

        public Task<bool> Modificar(UnidadMedida medida);

        public Task<bool> Insertar(UnidadMedida medida);

        public Task<bool> Delete(Guid id);
    }
}
