using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class HabitosCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HabitosCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    TempoFumante = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Fumante = table.Column<bool>(type: "boolean", nullable: false),
                    BebidasAlcolicas = table.Column<string>(type: "text", nullable: true),
                    OutrosHabitos = table.Column<string>(type: "text", nullable: true),
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitosCliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitosCliente");
        }
    }
}
