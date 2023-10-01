using System.ComponentModel.DataAnnotations.Schema;

namespace atleticaGestor_parteDois.Models
{
    [Table("time", Schema = "atleticagestor")]

    public class Time
    {
        public long idtime { get; set; }
        public string nome { get; set; }
        public string esporte { get; set; }
        public string treinador { get; set; }
        public long idatletica { get; set; }
    }
}
