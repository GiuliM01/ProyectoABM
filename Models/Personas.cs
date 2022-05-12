using System.ComponentModel.DataAnnotations;

namespace ProyectoABM.Models
{
    public class Personas
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Direccion { get; set; }

      
        public int TipoId { get; set; }

        public string Codigo { get; set; }
    }
}
