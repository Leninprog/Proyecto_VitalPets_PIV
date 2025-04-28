using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_VitalPets_PIV.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La especie es obligatoria.")]
        public string Especie { get; set; }

        public string Raza { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "Debe seleccionar un dueño.")]
        public int? UsuarioId { get; set; } 

        public virtual Usuario Usuario { get; set; }
    }
}
