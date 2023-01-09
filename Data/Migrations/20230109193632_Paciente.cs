using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Paciente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Genero = table.Column<int>(type: "integer", nullable: false),
                    CpfCnpj = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    Rg = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    OrgaoExpedidor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EstadoExpedidorId = table.Column<int>(type: "integer", nullable: false),
                    DataExpedicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NomeRotulo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    NaoAvisarUsoContinuo = table.Column<bool>(type: "boolean", nullable: false),
                    Observacoes = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PesoPaciente = table.Column<double>(type: "double precision", nullable: false),
                    EspecieId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Acao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
