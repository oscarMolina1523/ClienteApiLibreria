using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioUsuario
    {
        public Task<List<Usuario>> lista();

        public Task<bool> Modificar(Usuario usuario);

        public Task<bool> Insertar(Usuario usuario);

        public Task<bool> Delete(Guid id);
    }
}
