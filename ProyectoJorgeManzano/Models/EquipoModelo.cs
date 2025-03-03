using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoJorgeManzano.Models
{
    public class EquipoModelo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public int founded { get; set; }
        public string logo { get; set; }        
        public string paisId { get; set; }
        public PaisModelo pais { get; set; }
        [NotMapped]
        public List<int> competicionesSeleccionadas { get; set; }
        public List<CompeticionEquipoModelo> competicionesEquipos { get; set; }
    }
}
