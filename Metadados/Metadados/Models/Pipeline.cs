using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metadados.Models
{
    public class Pipeline
    {
        [Key]
        public int sky_pipeline { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string nom_pipeline { get; set; }
    }
}
