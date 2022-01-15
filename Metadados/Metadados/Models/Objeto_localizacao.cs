using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metadados.Models
{
    public class Objeto_localizacao
    {
        [Key]
        public int sky_objeto_localizacao { get; set; }
        [ForeignKey("Localizacao_tipo")]
        public int sky_localizacao_tipo { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string nom_objeto_identificador { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string dsc_endereco_localizacao { get; set; }
        public int num_porta { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string nom_usuario { get; set; }
        [Column(TypeName = "varchar(250)")]
        public int nom_password { get; set; }
        [Column(TypeName = "varchar(250)")]
        public int nom_fornecedor { get; set; }
    }
}
