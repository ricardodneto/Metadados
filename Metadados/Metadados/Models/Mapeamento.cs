using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metadados.Models
{
    public class Mapeamento
    {
        [Key]
        public int sky_mapeamento { get; set; }
        [ForeignKey("Pipeline")]
        public int sky_pipeline { get; set; }
        public int sky_objeto_destino { get; set; }
        public int sky_objeto_origem { get; set; }
        [Column(TypeName = "varchar(250)")]
        public int dsc_mapeamento_colunas { get; set; }
   
    }
}
