namespace AppAlertasEnergia.Models
{
    public class Cronograma
    {
        public int Id { get; set; }
        public Sector oSector { get; set; }

        public DateTime fechaDesde { get; set; }

        public DateTime fechaHasta { get; set; }

        public TimeOnly horaInicio { get; set; }

        public TimeOnly horaFin {  get; set; }

        public string estado {  get; set; }
    }
}
