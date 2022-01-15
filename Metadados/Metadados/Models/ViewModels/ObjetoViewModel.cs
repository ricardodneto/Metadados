namespace Metadados.Models.ViewModels
{
    public class ObjetoViewModel
    {
        public Objeto Objeto { get; set; }
        public Objeto_localizacao Objeto_localizacao { get; set; }
        public Objeto_configuracao Objeto_configuracao { get; set; }

        public List<Objeto_localizacao> oObjeto_localizacao { get; set; }
        public List<Objeto_configuracao> oObjeto_configuracao { get; set; }
    }
}
