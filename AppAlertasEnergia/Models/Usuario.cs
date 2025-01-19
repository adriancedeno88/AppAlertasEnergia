namespace AppAlertasEnergia.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string nombres { get; set; }
        public string apellidos {  get; set; }
        public string telefono { get; set; }
        public string clave {  get; set; }
        public DateTime fechaCreacion { get; set; }
        public int tipo {  get; set; }
        public int estado { get; set; }
        public string cedula { get; set; }
    }
}
