using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metadados.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Localizacao_tipo",
                columns: table => new
                {
                    sky_localizacao_tipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_localizacao_tipo = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacao_tipo", x => x.sky_localizacao_tipo);
                });

            migrationBuilder.CreateTable(
                name: "Mapeamento",
                columns: table => new
                {
                    sky_mapeamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sky_pipeline = table.Column<int>(type: "int", nullable: false),
                    sky_objeto_destino = table.Column<int>(type: "int", nullable: false),
                    sky_objeto_origem = table.Column<int>(type: "int", nullable: false),
                    dsc_mapeamento_colunas = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mapeamento", x => x.sky_mapeamento);
                });

            migrationBuilder.CreateTable(
                name: "Objeto",
                columns: table => new
                {
                    sky_objeto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sky_objeto_configuracao = table.Column<int>(type: "int", nullable: false),
                    sky_objeto_localizacao = table.Column<int>(type: "int", nullable: false),
                    nom_objeto = table.Column<string>(type: "varchar(250)", nullable: false),
                    nom_compactacao = table.Column<string>(type: "varchar(250)", nullable: false),
                    nom_tabela = table.Column<string>(type: "varchar(250)", nullable: false),
                    nom_entidade = table.Column<string>(type: "varchar(250)", nullable: false),
                    dsc_coluna_ranges = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objeto", x => x.sky_objeto);
                });

            migrationBuilder.CreateTable(
                name: "Objeto_configuracao",
                columns: table => new
                {
                    sky_objeto_configuracao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sky_objeto_tipo = table.Column<int>(type: "int", nullable: false),
                    dsc_delimitador_coluna = table.Column<string>(type: "varchar(50)", nullable: false),
                    dsc_delimitador_detalhe = table.Column<string>(type: "varchar(50)", nullable: false),
                    dsc_qualificador_texto = table.Column<string>(type: "varchar(50)", nullable: false),
                    dsc_encode = table.Column<string>(type: "varchar(100)", nullable: false),
                    num_pular_linha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objeto_configuracao", x => x.sky_objeto_configuracao);
                });

            migrationBuilder.CreateTable(
                name: "Objeto_localizacao",
                columns: table => new
                {
                    sky_objeto_localizacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sky_localizacao_tipo = table.Column<int>(type: "int", nullable: false),
                    nom_objeto_identificador = table.Column<string>(type: "varchar(250)", nullable: false),
                    dsc_endereco_localizacao = table.Column<string>(type: "varchar(250)", nullable: false),
                    num_porta = table.Column<int>(type: "int", nullable: false),
                    nom_usuario = table.Column<string>(type: "varchar(250)", nullable: false),
                    nom_password = table.Column<string>(type: "varchar(250)", nullable: false),
                    nom_fornecedor = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objeto_localizacao", x => x.sky_objeto_localizacao);
                });

            migrationBuilder.CreateTable(
                name: "Objeto_tipo",
                columns: table => new
                {
                    sky_objeto_tipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_objeto_tipo = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objeto_tipo", x => x.sky_objeto_tipo);
                });

            migrationBuilder.CreateTable(
                name: "Pipeline",
                columns: table => new
                {
                    sky_pipeline = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom_pipeline = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pipeline", x => x.sky_pipeline);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Localizacao_tipo");

            migrationBuilder.DropTable(
                name: "Mapeamento");

            migrationBuilder.DropTable(
                name: "Objeto");

            migrationBuilder.DropTable(
                name: "Objeto_configuracao");

            migrationBuilder.DropTable(
                name: "Objeto_localizacao");

            migrationBuilder.DropTable(
                name: "Objeto_tipo");

            migrationBuilder.DropTable(
                name: "Pipeline");
        }
    }
}
