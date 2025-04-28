namespace Proyecto_VitalPets_PIV.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public List<Mascota> Mascotas { get; set; }
    }
}
