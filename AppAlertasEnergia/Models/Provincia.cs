namespace AppAlertasEnergia.Models
{
    public class Provincia
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public ICollection<Canton> cantones { get; set; }
    }
}
