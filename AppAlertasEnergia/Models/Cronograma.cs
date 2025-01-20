namespace AppAlertasEnergia.Models
{
    public class Cronograma
    {
        public int Id { get; set; }
        public DateTime fechaDesde { get; set; }

        public DateTime fechaHasta { get; set; }

        public TimeOnly horaInicio { get; set; }

        public TimeOnly horaFin {  get; set; }

        public string estado {  get; set; }

        public int idSector { get; set; }
        public Sector Sector { get; set; }

        public ICollection<Alerta> Alertas { get; set; }
    }
}
