using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class NfeExpedicaoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NfeExpedicaoCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    EstadoEmbarqueId = table.Column<int>(type: "integer", nullable: false),
                    LocalEmbarque = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    RegimeTributacao = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NfeExpedicaoCliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NfeExpedicaoCliente");
        }
    }
}
