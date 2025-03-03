using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoJorgeManzano.Models
{
    public class CompeticionModelo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string logo { get; set; }       
        public string paisId { get; set; }
        public PaisModelo pais { get; set; }
        [NotMapped]
        public List<int> equiposSeleccionados { get; set; }
        public List<CompeticionEquipoModelo> competicionesEquipos { get; set; }
    }
}
