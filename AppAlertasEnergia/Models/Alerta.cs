namespace AppAlertasEnergia.Models
{
    public class Alerta
    {       
        public int Id { get; set; }
        public Usuario oUsuario { get; set; }

        public int idsector { get; set; }
        public Cronograma cronograma {  get; set; }
        public string direccion { get; set; }
        public string alias {  get; set; }
        public string correo { get; set; }
        public string estado { get; set; }
        public DateTime fechaRegistro { get; set; }

    }
}
