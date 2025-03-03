using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoJorgeManzano.Models
{
    public class CompeticionEquipoModelo
    {
        public int ID { get; set; }               
        public int competicionID { get; set; }
        public CompeticionModelo competicion { get; set; }
        public int equipoID { get; set; }
        public EquipoModelo equipo { get; set; }
    }
}
