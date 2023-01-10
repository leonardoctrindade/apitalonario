using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Cliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ContribuinteIcms = table.Column<bool>(type: "boolean", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Genero = table.Column<int>(type: "integer", nullable: false),
                    ReterIss = table.Column<bool>(type: "boolean", nullable: false),
                    InscricaoMunicipal = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    NomeRotulo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    CpfCnpj = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    ReterRps = table.Column<bool>(type: "boolean", nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    Rg = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    OrgaoExpedidor = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    EstadoOrgaoExpedidorId = table.Column<int>(type: "integer", nullable: true),
                    DddTelefone = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DddCelular = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Whats = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ConfirmaCpfCupom = table.Column<bool>(type: "boolean", nullable: false),
                    DataExpedicao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Endereco = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Numero = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    Proximidade = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TipoContatoId = table.Column<int>(type: "integer", nullable: true),
                    BairroId = table.Column<int>(type: "integer", nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: true),
                    NaoUsoContinuo = table.Column<bool>(type: "boolean", nullable: false),
                    FidelidadeId = table.Column<int>(type: "integer", nullable: true),
                    CartaoFidelidade = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CartaoFidelidadeAtivo = table.Column<bool>(type: "boolean", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    TelefoneCopia = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CelularCopia = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PafCpfCnpj = table.Column<string>(type: "character varying(96)", maxLength: 96, nullable: true),
                    PafCliente = table.Column<string>(type: "character varying(96)", maxLength: 96, nullable: true),
                    NumeroDocumento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CelularCompletoCliente = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    DocumentoExterior = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    PedirSenhaVendaLimite = table.Column<int>(type: "integer", nullable: true),
                    IntegracaoId = table.Column<int>(type: "integer", nullable: true),
                    ClienteParcelamento = table.Column<bool>(type: "boolean", nullable: false),
                    NovaMsgWhats = table.Column<bool>(type: "boolean", nullable: false),
                    ContatoWhatsInativo = table.Column<bool>(type: "boolean", nullable: false),
                    SyncNumberConflit = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
