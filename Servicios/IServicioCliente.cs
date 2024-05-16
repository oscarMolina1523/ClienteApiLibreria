using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioCliente
    {
        public Task<List<Cliente>> lista();

        public Task<bool> Modificar(Cliente Objcliente);

        public Task<bool> Insertar(Cliente Objcliente);

        public Task<bool> Delete(Guid id);
    }
}
