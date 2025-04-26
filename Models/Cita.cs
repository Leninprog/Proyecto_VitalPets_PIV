namespace Proyecto_VitalPets_PIV.Models
{
    // Models/Cita.cs
    public class Cita
    {
        public int Id { get; set; }
        public int MascotaId { get; set; }
        public Mascota Mascota { get; set; }

        public DateTime FechaHora { get; set; }
        public string TipoConsulta { get; set; }
        public string Veterinaria { get; set; }
        public string Estado { get; set; } // Activa, Cancelada, Reprogramada
    }

}
