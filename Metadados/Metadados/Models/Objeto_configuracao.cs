using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metadados.Models
{
    public class Objeto_configuracao
    {
        [Key]
        public int sky_objeto_configuracao { get; set; }
        [ForeignKey("Objeto_tipo")]
        public int sky_objeto_tipo{ get; set; }
        [Column(TypeName = "varchar(50)")]
        public string dsc_delimitador_coluna { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string dsc_delimitador_detalhe { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string dsc_qualificador_texto { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string dsc_encode { get; set; }
        public int num_pular_linha { get; set; }
    }
}
