using System.ComponentModel.DataAnnotations.Schema;

namespace atleticaGestor_parteDois.Models
{
    [Table("atleta", Schema = "atleticagestor")]
    public class Atleta
    {
        public long membro_matricula { get; set; }
    }
}
