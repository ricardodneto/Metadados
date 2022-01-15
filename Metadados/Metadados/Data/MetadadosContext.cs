using Microsoft.EntityFrameworkCore;

namespace Metadados.Data
{
    public class MetadadosContext : DbContext
    {
        public MetadadosContext(DbContextOptions<MetadadosContext> options)
            : base(options)
        {
        }


        public DbSet<Metadados.Models.Objeto> Objeto { get; set; }

        public DbSet<Metadados.Models.Objeto_configuracao> Objeto_configuracao { get; set; }

        public DbSet<Metadados.Models.Objeto_localizacao> Objeto_localizacao { get; set; }

        public DbSet<Metadados.Models.Objeto_tipo> Objeto_tipo { get; set; }
        public DbSet<Metadados.Models.Pipeline> Pipeline { get; set; }
        public DbSet<Metadados.Models.Localizacao_tipo> Localizacao_tipo { get; set; }
        public DbSet<Metadados.Models.Mapeamento> Mapeamento { get; set; }

    }
}
