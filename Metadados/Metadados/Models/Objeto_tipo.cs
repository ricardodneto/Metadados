using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metadados.Models
{
    public class Objeto_tipo
    {
        [Key]
        public int sky_objeto_tipo { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string nom_objeto_tipo { get; set; }
    }
}
