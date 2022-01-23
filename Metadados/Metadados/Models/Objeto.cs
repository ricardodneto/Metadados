using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metadados.Models
{
    public class Objeto
    {
        [Key]
        [Display(Name ="ID")]
        public int sky_objeto { get; set; }
        [ForeignKey("objeto_configuracao")]

        [Display(Name = "ID Objeto Configuração")]
        public int sky_objeto_configuracao { get; set; }
        [ForeignKey ("objeto_localizacao")]

        [Display(Name = "ID Objeto Localização")]
        public int sky_objeto_localizacao { get; set; }
        [Column(TypeName = "varchar(250)")]

        [Display(Name = "Nome Objeto")]
        public string nom_objeto { get; set; }
        [Column(TypeName = "varchar(250)")]

        [Display(Name = "Compactação")]
        public string nom_compactacao { get; set; }
        [Column(TypeName = "varchar(250)")]

        [Display(Name = "Nome Tabela")]
        public string nom_tabela { get; set; }
        [Column(TypeName = "varchar(250)")]

        [Display(Name = "Nome Entidade")]
        public string nom_entidade { get; set; }
        [Column(TypeName = "varchar(250)")]

        [Display(Name = "Range de colunas")]
        public string dsc_coluna_ranges { get; set; }

    }
}
