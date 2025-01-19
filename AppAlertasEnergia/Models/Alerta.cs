namespace AppAlertasEnergia.Models
{
    public class Alerta
    {       
        public int Id { get; set; }
        public Usuario oUsuario { get; set; }
        public Sector osector {  get; set; }
        public string direccion { get; set; }
        public string alias {  get; set; }
        public string correo { get; set; }
        public string estado { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
