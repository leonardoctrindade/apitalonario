using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class LimiteDeCompraCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LimiteDeCompraCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    LimiteDeCompra = table.Column<double>(type: "double precision", nullable: false),
                    BloqueioLimiteExcedido = table.Column<bool>(type: "boolean", nullable: false),
                    FormaPagamento = table.Column<int>(type: "integer", nullable: false),
                    DiaPagamento = table.Column<int>(type: "integer", nullable: false),
                    PrazoDias = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimiteDeCompraCliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LimiteDeCompraCliente");
        }
    }
}
