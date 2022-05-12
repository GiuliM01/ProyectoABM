namespace ProyectoABM.Models
{
    public class Facturacion
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Cliente { get; set; }

        public string Numero { get; set; }

        public string Precio { get; set; }

        public int PersonasId { get; set; }

        public Personas Personas{ get; set; }
    }
}
