using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AcompanhamentoPessoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcompanhamentoPessoal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Peso = table.Column<double>(type: "double precision", maxLength: 20, nullable: false),
                    PressaoArterial = table.Column<double>(type: "double precision", maxLength: 20, nullable: false),
                    OutrasInformacoes = table.Column<string>(type: "text", nullable: true),
                    TipoSanguineo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    InformacoesLaboratoriais = table.Column<string>(type: "text", nullable: true),
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcompanhamentoPessoal", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcompanhamentoPessoal");
        }
    }
}
