using System.ComponentModel.DataAnnotations.Schema;

namespace atleticaGestor_parteDois.Models
{
    [Table("associacaomembrotime", Schema = "atleticagestor")]
    public class Associacaomembrotime
    {
        public long membro_matricula { get; set; }
        public long idtime { get; set; }
    }
}
