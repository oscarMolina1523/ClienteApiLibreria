using ConsumirAPILibreria.Models;

namespace ConsumirAPILibreria.Servicios
{
    public interface IServicioEmpleado
    {
        public Task<List<Empleado>> lista();

        public Task<bool> Modificar(Empleado empleado);

        public Task<bool> Insertar(Empleado empleado);

        public Task<bool> Delete(Guid id);
    }
}
