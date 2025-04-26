
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_VitalPets_PIV.Models;

namespace Proyecto_VitalPets_PIV.Models
{
    public class Mascota
    {
        // Identificador único para cada mascota
        public int Id { get; set; }
        //Required, hace que sea obligatorio ingresar un dato
        //Nombre de la mascota
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        // Especie de la mascota
        [Required]
        public string Especie { get; set; }

        // Raza de la mascota
        public string Raza { get; set; }

        // Fecha de nacimiento
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        // Llave foránea que enlaza esta mascota con su dueño
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        // Permite acceder al objeto Usuario relacionado
        public virtual Usuario Usuario { get; set; }
    }
}

