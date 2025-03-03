using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoJorgeManzano.Models
{
    public class PaisModelo
    {
        public string id { get; set; }
        public string countryName { get; set; }
        public string countryFlag { get; set; }
        //[NotMapped]
        //public List<int> equiposID { get; set; }
        //public List<EquipoModelo> equipos { get; set; }
        //[NotMapped]
        //public List<int> competicionesID { get; set; }
        //public List<CompeticionModelo> competiciones { get; set; }
    }
}
