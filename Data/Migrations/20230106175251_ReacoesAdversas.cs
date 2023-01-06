using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ReacoesAdversas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReacoesAdversas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Medicamento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Dose = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Reacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReacoesAdversas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReacoesAdversas");
        }
    }
}
