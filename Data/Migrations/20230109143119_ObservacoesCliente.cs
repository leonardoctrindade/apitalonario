using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ObservacoesCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObservacoesCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    MensagemVenda = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ObservacaoOp = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ObservacaoGeral = table.Column<string>(type: "text", nullable: true),
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObservacoesCliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObservacoesCliente");
        }
    }
}
