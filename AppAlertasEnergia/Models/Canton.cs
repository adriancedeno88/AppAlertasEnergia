namespace AppAlertasEnergia.Models
{
    public class Canton
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public int idProvincia { get; set; }
        public Provincia provincia {  get; set; }

        public ICollection<Sector> Sectores { get; set; }
    }
}
