namespace ConsumirAPILibreria.Models
{
    public class Producto : BaseEntity
    {
        public string DescripcionProducto { get; set; }

        public Guid IdCategoria { get; set; }

        public ModeloCategoria categoria { get; set; }

        public bool Estado { get; set; }
    }
}
