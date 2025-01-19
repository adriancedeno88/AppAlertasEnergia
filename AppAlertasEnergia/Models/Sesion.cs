namespace AppAlertasEnergia.Models
{
    public class Sesion
    {
        public int Id { get; set; }
        public Usuario oUsuario {  get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime fechaFin { get; set; }
    }
}
