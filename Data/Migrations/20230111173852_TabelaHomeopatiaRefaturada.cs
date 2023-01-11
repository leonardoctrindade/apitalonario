using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaHomeopatiaRefaturada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntervaloDinamizacaoHomeopatia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Inicial = table.Column<int>(type: "integer", nullable: false),
                    Final = table.Column<int>(type: "integer", nullable: false),
                    TabelaHomeopatiaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntervaloDinamizacaoHomeopatia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuantidadeXValorHomeopatia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuantidadeInicial = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeFinal = table.Column<int>(type: "integer", nullable: false),
                    ValorVenda = table.Column<double>(type: "double precision", nullable: false),
                    ValorAdicional = table.Column<double>(type: "double precision", nullable: false),
                    IntervaloDinamizacaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantidadeXValorHomeopatia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaHomeopatia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Metodo = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    FormaFarmaceuticaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaHomeopatia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VolumeXValorHomeopatia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    ValorVenda = table.Column<double>(type: "double precision", nullable: false),
                    ValorAdicional = table.Column<double>(type: "double precision", nullable: false),
                    IntervaloDinamizacaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolumeXValorHomeopatia", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntervaloDinamizacaoHomeopatia");

            migrationBuilder.DropTable(
                name: "QuantidadeXValorHomeopatia");

            migrationBuilder.DropTable(
                name: "TabelaHomeopatia");

            migrationBuilder.DropTable(
                name: "VolumeXValorHomeopatia");
        }
    }
}
