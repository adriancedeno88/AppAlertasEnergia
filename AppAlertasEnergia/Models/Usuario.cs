using System.ComponentModel.DataAnnotations;

namespace AppAlertasEnergia.Models
{
    public class Usuario
    {
        public long Id { get; set; }

        [MaxLength(250)]
        public required string email { get; set; }
        public required string nombres { get; set; }
        public required string apellidos {  get; set; }
        public string? telefono { get; set; }

        [MaxLength(250)]
        public required string clave {  get; set; }
        public DateTime fechaCreacion { get; set; }
        public int tipo {  get; set; }
        public int estado { get; set; }
        public string? cedula { get; set; }
    }
}
