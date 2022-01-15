namespace Metadados.Models.ViewModels
{
    public class Objeto_localizacaoViewModel
    {
        public Objeto_localizacao Objeto_localizacao { get; set; }

        public  Localizacao_tipo Localizacao_tipo { get; set; }

        public List<Localizacao_tipo> oLocalizacao_tipo { get; set; }
    }
}
