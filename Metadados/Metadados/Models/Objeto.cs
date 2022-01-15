using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metadados.Models
{
    public class Objeto
    {
        [Key]
        public int sky_objeto { get; set; }
        [ForeignKey("objeto_configuracao")]
        public int sky_objeto_configuracao { get; set; }
        [ForeignKey ("objeto_localizacao")]
        public int sky_objeto_localizacao { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string nom_objeto { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string nom_compactacao { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string nom_tabela { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string nom_entidade { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string dsc_coluna_ranges { get; set; }

    }
}
