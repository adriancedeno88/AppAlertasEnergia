namespace AppAlertasEnergia.Models
{
    public class Sector
    {
        public int Id { get; set; }

        public int idcanton {  get; set; }
        public Canton Canton { get; set; }

        public string nombre {  get; set; }

        public Cronograma Cronograma { get; set; }

        
    }
}
