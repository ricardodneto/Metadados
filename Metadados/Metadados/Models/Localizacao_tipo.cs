using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metadados.Models
{
    public class Localizacao_tipo
    {
        [Key]
        public int sky_localizacao_tipo { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string nom_localizacao_tipo { get; set; }
    }
}
