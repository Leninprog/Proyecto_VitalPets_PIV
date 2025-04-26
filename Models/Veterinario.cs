using System.ComponentModel.DataAnnotations;

namespace Proyecto_VitalPets_PIV.Models
{
    public class Veterinario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public string Especialidad { get; set; }

    }
}

