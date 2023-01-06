using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AliquotaEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EstadoOrigemId = table.Column<int>(type: "integer", nullable: true),
                    EstadoDestinoId = table.Column<int>(type: "integer", nullable: true),
                    AliquotaIcms = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AliquotaEstado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bairro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bairro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Balanca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Modelo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PortaCom = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    BitsPorSegundo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Dtr = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    BitsDeDados = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Rts = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Paridade = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    XonXoff = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Maquina = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SeparadorDecimal = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Opcoes = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    DescricaoModelo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balanca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeBanco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CodigoBanco = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Carteira = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Modalidade = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    FormaCobranca = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Layout = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    SequenciaRemessa = table.Column<int>(type: "integer", nullable: true),
                    NomeCedente = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    CnpjCedente = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    CodigoCedente = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CodigoTransmissao = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ComplementoTransmissao = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Agencia = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    AgenciaDigito = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    DiasProtesto = table.Column<int>(type: "integer", nullable: true),
                    Juros = table.Column<decimal>(type: "numeric", nullable: true),
                    Multa = table.Column<decimal>(type: "numeric", nullable: true),
                    ContaCorrente = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ContaCorrenteDigito = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Convenio = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Producao = table.Column<bool>(type: "boolean", nullable: false),
                    LocalPagamento = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    MensagemInstrucao1 = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    MensagemInstrucao2 = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    MensagemInstrucao3 = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    MensagemInstrucao4 = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true),
                    MensagemInstrucao5 = table.Column<string>(type: "character varying(70)", maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Link = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AcaoLink = table.Column<int>(type: "integer", nullable: false),
                    Posicao = table.Column<int>(type: "integer", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DataFim = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ImagemBanner = table.Column<byte[]>(type: "bytea", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    TipoDadoImagem = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    Integrados = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    BannerMagentoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    LimitacaoVisual = table.Column<bool>(type: "boolean", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CategoriaPaiId = table.Column<int>(type: "integer", nullable: true),
                    CategoriaAtiva = table.Column<bool>(type: "boolean", nullable: false),
                    CategoriaMagentoId = table.Column<int>(type: "integer", nullable: true),
                    Integrados = table.Column<bool>(type: "boolean", nullable: false),
                    Excluidos = table.Column<bool>(type: "boolean", nullable: false),
                    AlteradoPais = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categoria_Categoria_CategoriaPaiId",
                        column: x => x.CategoriaPaiId,
                        principalTable: "Categoria",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroConta = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Limite = table.Column<double>(type: "double precision", nullable: true),
                    FilialId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dcb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoDcb = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dcb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoDci = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiasHoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiaSemana = table.Column<string>(type: "text", nullable: true),
                    HoraInicial = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HoraFinal = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: true),
                    Hash = table.Column<string>(type: "text", nullable: true),
                    CodigoDia = table.Column<int>(type: "integer", nullable: false),
                    Sequencia = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasHoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diferimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Icms = table.Column<double>(type: "double precision", nullable: true),
                    AliquotaDiferimento = table.Column<double>(type: "double precision", nullable: false),
                    Cst = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    SiglaEstado = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    FilialId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diferimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DOM_RegimeTributario",
                columns: table => new
                {
                    idRegimeTributario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegimeTributario = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOM_RegimeTributario", x => x.idRegimeTributario);
                });

            migrationBuilder.CreateTable(
                name: "Ecf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroEquipamento = table.Column<int>(type: "integer", nullable: false),
                    NumeroSerie = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Marca = table.Column<int>(type: "integer", nullable: false),
                    Modelo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CniEcf = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Cro = table.Column<int>(type: "integer", nullable: true),
                    TipoModelo = table.Column<string>(type: "text", nullable: true),
                    OrdemUsuario = table.Column<int>(type: "integer", nullable: true),
                    DataCadastroUsuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HoraCadastroUsuario = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    MfAdicional = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    VersaoSb = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    DataGravacaoSb = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HoraGravacaoSb = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    VersaoDll = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    AcentoFormaPagamento = table.Column<bool>(type: "boolean", nullable: false),
                    MaiusculoFormaPagamento = table.Column<bool>(type: "boolean", nullable: false),
                    SaltoFinalCupom = table.Column<int>(type: "integer", nullable: true),
                    PafNumeroFabricacao = table.Column<string>(type: "character varying(96)", maxLength: 96, nullable: true),
                    PafEcf = table.Column<string>(type: "character varying(96)", maxLength: 96, nullable: true),
                    NumeroFabricacaoCripto = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    GrandeTotalCripto = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    FilialId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ecf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entregador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    IeEntregador = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Ddd = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Fax = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Contato = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TelefoneContato = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EntregadorInativo = table.Column<bool>(type: "boolean", nullable: false),
                    NomeUsuario = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    NomeUsuarioRec = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataAtualizacaoRec = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EspecificacaoCapsula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Prioridade = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecificacaoCapsula", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etapa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sequencia = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Processo = table.Column<string>(type: "text", nullable: true),
                    Obrigatoria = table.Column<string>(type: "text", nullable: true),
                    TempoMaximo = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etapa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etiqueta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    MargemSuperior = table.Column<double>(type: "double precision", nullable: false),
                    MargemLateral = table.Column<double>(type: "double precision", nullable: false),
                    AlturaEtiqueta = table.Column<double>(type: "double precision", nullable: false),
                    LarguraEtiqueta = table.Column<double>(type: "double precision", nullable: false),
                    DistanciaVertical = table.Column<double>(type: "double precision", nullable: false),
                    DistanciaHorizontal = table.Column<double>(type: "double precision", nullable: false),
                    LinhasPorPagina = table.Column<int>(type: "integer", nullable: false),
                    ColunasPorPagina = table.Column<int>(type: "integer", nullable: false),
                    LayoutEtiquetaEntrada = table.Column<int>(type: "integer", nullable: false),
                    TextoCabecalho = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
                    TextoRodape = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
                    Observacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    LinhasPorEtiqueta = table.Column<int>(type: "integer", nullable: false),
                    EspacoEntreLinhas = table.Column<double>(type: "double precision", nullable: false),
                    DefinirEtiquetaPadrao = table.Column<bool>(type: "boolean", nullable: false),
                    CodigoDeBarraVertical = table.Column<bool>(type: "boolean", nullable: false),
                    RetirarEspacoEntreUnidEQtd = table.Column<bool>(type: "boolean", nullable: false),
                    LayoutWeleda = table.Column<int>(type: "integer", nullable: true),
                    TipoModeloEtiqueta = table.Column<int>(type: "integer", nullable: true),
                    ModeloImagem = table.Column<byte[]>(type: "bytea", nullable: true),
                    FilialId = table.Column<int>(type: "integer", nullable: true),
                    TipoLayoutEtiquetaPersonalizado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiqueta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farmacopeia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farmacopeia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fidelidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PontosIniciais = table.Column<int>(type: "integer", nullable: true),
                    ValidadePontos = table.Column<int>(type: "integer", nullable: true),
                    PontosPrimeiraCompra = table.Column<int>(type: "integer", nullable: true),
                    AvisoCliente = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fidelidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FidelidadeFormaPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoFidelidade = table.Column<int>(type: "integer", nullable: false),
                    CodigoFormaPagamento = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    Pontos = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FidelidadeFormaPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaFarmaceuticaFaixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuantidadeInicial = table.Column<double>(type: "double precision", nullable: true),
                    QuantidadeFinal = table.Column<double>(type: "double precision", nullable: true),
                    ValorMinimo = table.Column<double>(type: "double precision", nullable: true),
                    SiglaUnidadeFaixa = table.Column<string>(type: "text", nullable: true),
                    FormaFarmaceuticaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaFarmaceuticaFaixa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuncionarioLaboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionarioLaboratorio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Comissao = table.Column<double>(type: "double precision", nullable: false),
                    PercentualDesconto = table.Column<double>(type: "double precision", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    AtivaPesagemGrupo = table.Column<bool>(type: "boolean", nullable: false),
                    DescontoMaximo = table.Column<double>(type: "double precision", nullable: true),
                    AtivaControleDeLotesAcabados = table.Column<bool>(type: "boolean", nullable: false),
                    FatorReferenciaGrupo = table.Column<double>(type: "double precision", nullable: true),
                    AtivaControleLotesDrogaria = table.Column<bool>(type: "boolean", nullable: false),
                    CodigoGrupoLp = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrupoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NivelGrupo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Laboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laboratorio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListaControlado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    ReceitaObrigatorio = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaControlado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MensagensPadrao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusDescricao = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Mensagem = table.Column<string>(type: "text", nullable: false),
                    EnviarAutomatico = table.Column<bool>(type: "boolean", nullable: false),
                    DescricaoRotulo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensagensPadrao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Metodo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    QuantidadeGotas = table.Column<int>(type: "integer", nullable: true),
                    Percentual = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metodo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Moeda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moeda", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nbm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CodigoNbm = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    VlrAgregadoEst = table.Column<double>(type: "double precision", nullable: true),
                    VlrAgregadoInt = table.Column<double>(type: "double precision", nullable: true),
                    VlrComplementarEst = table.Column<double>(type: "double precision", nullable: true),
                    VlrComplementarInt = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nbm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperadorCaixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NomeAbreviado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    FilialId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperadorCaixa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CodigoIbge = table.Column<int>(type: "integer", nullable: false),
                    CodigoTelefonico = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pbm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Observacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pbm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanoDeContas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NivelConta = table.Column<int>(type: "integer", nullable: false),
                    NumeroConta = table.Column<string>(type: "text", nullable: false),
                    NumeroContaPai = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Sequencia = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoDeContas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Portador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PortadorInativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PosAdquirente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ChaveRequisicao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosAdquirente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posologia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    QuantidadeCapsulasOuDoses = table.Column<int>(type: "integer", nullable: true),
                    Periodo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posologia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipioAtivo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipioAtivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regiao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Taxa = table.Column<double>(type: "double precision", nullable: true),
                    IeSegunda = table.Column<bool>(type: "boolean", nullable: false),
                    IeTerca = table.Column<bool>(type: "boolean", nullable: false),
                    IeQuarta = table.Column<bool>(type: "boolean", nullable: false),
                    IeQuinta = table.Column<bool>(type: "boolean", nullable: false),
                    IeSexta = table.Column<bool>(type: "boolean", nullable: false),
                    IeSabado = table.Column<bool>(type: "boolean", nullable: false),
                    IeDomingo = table.Column<bool>(type: "boolean", nullable: false),
                    HoraInicialSegunda = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HoraInicialTerca = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HoraInicialQuarta = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HoraInicialQuinta = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HoraInicialSexta = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HoraInicialSabado = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HoraInicialDomingo = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HoraFinalSegunda = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    HoraFinalTerca = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HoraFinalQuarta = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HoraFinalQuinta = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HoraFinalSexta = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HoraFinalSabado = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    HoraFinalDomingo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    NomeUsuario = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    NomeUsuarioRec = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DataAtualizacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataAtualizacaoRec = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    IntervaloProducaoEntrega = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetorDiasHoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SetorId = table.Column<int>(type: "integer", nullable: false),
                    DiasHorasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetorDiasHoras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetorForma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SetorId = table.Column<int>(type: "integer", nullable: false),
                    FormaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetorForma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaFloral",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeInicial = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeFinal = table.Column<int>(type: "integer", nullable: false),
                    ValorVenda = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaFloral", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaHomeopatia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Metodo = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    FormaFarmaceuticaId = table.Column<int>(type: "integer", nullable: true),
                    DinamizacaoInicial = table.Column<int>(type: "integer", nullable: false),
                    DinamizacaoFinal = table.Column<int>(type: "integer", nullable: false),
                    Volume = table.Column<int>(type: "integer", nullable: false),
                    ValorVenda = table.Column<double>(type: "double precision", nullable: true),
                    ValorAdicional = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaHomeopatia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TabelaHomeopatiaQuantidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Metodo = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    FormaFarmaceuticaId = table.Column<int>(type: "integer", nullable: true),
                    DinamizacaoInicial = table.Column<int>(type: "integer", nullable: false),
                    DinamizacaoFinal = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeInicial = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeFinal = table.Column<int>(type: "integer", nullable: false),
                    ValorVenda = table.Column<double>(type: "double precision", nullable: false),
                    ValorAdicional = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaHomeopatiaQuantidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoContato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoContato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoJustificativa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoJustificativa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tributo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    Codigo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tributo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HoraInicial = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    HoraFinal = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    FilialId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sigla = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Fator = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ensaio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    FarmacopeiaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ensaio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ensaio_Farmacopeia_FarmacopeiaId",
                        column: x => x.FarmacopeiaId,
                        principalTable: "Farmacopeia",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GrupoEnsaio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GrupoId = table.Column<int>(type: "integer", nullable: false),
                    EnsaioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoEnsaio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrupoEnsaio_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeAbreviado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    GrupoUsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Senha = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Nivel = table.Column<int>(type: "integer", nullable: true),
                    Logon = table.Column<bool>(type: "boolean", nullable: false),
                    Email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    LidoNovidade = table.Column<bool>(type: "boolean", nullable: false),
                    HoraUltimoAcesso = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataUltimoAcesso = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DataTrocaSenha = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FilialUsuarioId = table.Column<int>(type: "integer", nullable: true),
                    FilialProducaoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_GrupoUsuario_GrupoUsuarioId",
                        column: x => x.GrupoUsuarioId,
                        principalTable: "GrupoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Sigla = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    AliquotaIcmsEstado = table.Column<decimal>(type: "numeric", nullable: true),
                    AliquotaFcpEstado = table.Column<decimal>(type: "numeric", nullable: true),
                    DifalComCalculoPorDentro = table.Column<bool>(type: "boolean", nullable: false),
                    DifalComCalculoDeIsento = table.Column<bool>(type: "boolean", nullable: false),
                    ChecagemContribuinteIsento = table.Column<bool>(type: "boolean", nullable: false),
                    PaisId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estado_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormaPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TipoFormaPagamento = table.Column<int>(type: "integer", nullable: false),
                    AutorizarDescontos = table.Column<int>(type: "integer", nullable: false),
                    Conciliacao = table.Column<bool>(type: "boolean", nullable: false),
                    PlanoDeContaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPagamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormaPagamento_PlanoDeContas_PlanoDeContaId",
                        column: x => x.PlanoDeContaId,
                        principalTable: "PlanoDeContas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaquinaPos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    SerialPos = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AdquirentePosId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaquinaPos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaquinaPos_PosAdquirente_AdquirentePosId",
                        column: x => x.AdquirentePosId,
                        principalTable: "PosAdquirente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FidelidadePremios",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GrupoId = table.Column<int>(type: "integer", nullable: false),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    Pontos = table.Column<int>(type: "integer", nullable: false),
                    FidelidadeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FidelidadePremios", x => x.id);
                    table.ForeignKey(
                        name: "FK_FidelidadePremios_Fidelidade_FidelidadeId",
                        column: x => x.FidelidadeId,
                        principalTable: "Fidelidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FidelidadePremios_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FidelidadePremios_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoCapsula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    VolumeInterno = table.Column<double>(type: "double precision", nullable: true),
                    VolumeTotal = table.Column<double>(type: "double precision", nullable: true),
                    Peso = table.Column<double>(type: "double precision", nullable: true),
                    CapsulaPadraoId = table.Column<int>(type: "integer", nullable: true),
                    Inativo = table.Column<bool>(type: "boolean", nullable: false),
                    GrupoCapsulasId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCapsula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoCapsula_Produto_CapsulaPadraoId",
                        column: x => x.CapsulaPadraoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TipoCapsula_Produto_GrupoCapsulasId",
                        column: x => x.GrupoCapsulasId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntregadorRegiao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntregadorId = table.Column<int>(type: "integer", nullable: false),
                    RegiaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregadorRegiao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntregadorRegiao_Entregador_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Entregador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntregadorRegiao_Regiao_RegiaoId",
                        column: x => x.RegiaoId,
                        principalTable: "Regiao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CodigoIbge = table.Column<int>(type: "integer", nullable: true),
                    CodigoCfpsId = table.Column<int>(type: "integer", nullable: true),
                    CodigoSiafi = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidade_Tributo_CodigoCfpsId",
                        column: x => x.CodigoCfpsId,
                        principalTable: "Tributo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NaturezaOperacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<decimal>(type: "numeric", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    ExportarSintegra = table.Column<bool>(type: "boolean", nullable: false),
                    Observacao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ExibeDocumentoReferenciado = table.Column<bool>(type: "boolean", nullable: false),
                    ConsiderarCfopCreditoIcms = table.Column<bool>(type: "boolean", nullable: false),
                    NaoInsidePis = table.Column<bool>(type: "boolean", nullable: false),
                    NaoInsideCofins = table.Column<bool>(type: "boolean", nullable: false),
                    NaoInsideIcms = table.Column<bool>(type: "boolean", nullable: false),
                    CfopDevolucao = table.Column<bool>(type: "boolean", nullable: false),
                    CfopSubstituicaoTributaria = table.Column<bool>(type: "boolean", nullable: false),
                    PlanoDeContaId = table.Column<int>(type: "integer", nullable: true),
                    CstId = table.Column<int>(type: "integer", nullable: true),
                    CsosnId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NaturezaOperacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NaturezaOperacao_PlanoDeContas_PlanoDeContaId",
                        column: x => x.PlanoDeContaId,
                        principalTable: "PlanoDeContas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NaturezaOperacao_Tributo_CsosnId",
                        column: x => x.CsosnId,
                        principalTable: "Tributo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NaturezaOperacao_Tributo_CstId",
                        column: x => x.CstId,
                        principalTable: "Tributo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ncm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoServico = table.Column<bool>(type: "boolean", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CodigoNcm = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    CodigoNcmEx = table.Column<int>(type: "integer", nullable: true),
                    PercentualMva = table.Column<double>(type: "double precision", nullable: true),
                    AliquotaNacional = table.Column<double>(type: "double precision", nullable: true),
                    AliquotaImportacao = table.Column<double>(type: "double precision", nullable: true),
                    AliquotaCofins = table.Column<double>(type: "double precision", nullable: true),
                    AliquotaIcmsProduto = table.Column<double>(type: "double precision", nullable: true),
                    AliquotaPis = table.Column<double>(type: "double precision", nullable: true),
                    TributoCstCofinsEntradaId = table.Column<int>(type: "integer", nullable: true),
                    TributoCstCofinsSaidaId = table.Column<int>(type: "integer", nullable: true),
                    TributoCstPisEntradaId = table.Column<int>(type: "integer", nullable: true),
                    TributoCstPisSaidaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ncm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ncm_Tributo_TributoCstCofinsEntradaId",
                        column: x => x.TributoCstCofinsEntradaId,
                        principalTable: "Tributo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ncm_Tributo_TributoCstCofinsSaidaId",
                        column: x => x.TributoCstCofinsSaidaId,
                        principalTable: "Tributo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ncm_Tributo_TributoCstPisEntradaId",
                        column: x => x.TributoCstPisEntradaId,
                        principalTable: "Tributo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ncm_Tributo_TributoCstPisSaidaId",
                        column: x => x.TributoCstPisSaidaId,
                        principalTable: "Tributo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormulaPadrao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ManterDescricao = table.Column<bool>(type: "boolean", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    FormaFarmaceuticaId = table.Column<int>(type: "integer", nullable: false),
                    Validade = table.Column<int>(type: "integer", nullable: true),
                    Volume = table.Column<double>(type: "double precision", nullable: true),
                    UnidadeId = table.Column<int>(type: "integer", nullable: true),
                    QuantidadeFormulaPadrao = table.Column<int>(type: "integer", nullable: true),
                    QuantidadeEmbalagens = table.Column<int>(type: "integer", nullable: true),
                    DosePadrao = table.Column<double>(type: "double precision", nullable: true),
                    UnidadeDosePadraoId = table.Column<int>(type: "integer", nullable: true),
                    ProdutoId = table.Column<int>(type: "integer", nullable: true),
                    DesmembrarFormula = table.Column<bool>(type: "boolean", nullable: false),
                    ValorFormula = table.Column<double>(type: "double precision", nullable: true),
                    EmbalagemId = table.Column<int>(type: "integer", nullable: true),
                    CapsulaId = table.Column<int>(type: "integer", nullable: true),
                    DoseCapsula = table.Column<double>(type: "double precision", nullable: true),
                    PosologiaId = table.Column<int>(type: "integer", nullable: true),
                    ProdutoVeiculoId = table.Column<int>(type: "integer", nullable: true),
                    ExibirRotuloCompleto = table.Column<bool>(type: "boolean", nullable: false),
                    InativarFormula = table.Column<bool>(type: "boolean", nullable: false),
                    EtiquetaId = table.Column<int>(type: "integer", nullable: true),
                    MantemQuantidadeOrdem = table.Column<bool>(type: "boolean", nullable: false),
                    ObservacaoEtiqueta = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Observacao = table.Column<string>(type: "character varying(999)", maxLength: 999, nullable: true),
                    VolumePadrao2 = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    UnidadeDoseId = table.Column<int>(type: "integer", nullable: true),
                    DoseFormula = table.Column<double>(type: "double precision", nullable: true),
                    GrupoProdutoVeiculoId = table.Column<int>(type: "integer", nullable: true),
                    GrupoEmbalagemId = table.Column<int>(type: "integer", nullable: true),
                    GrupoCapsulaId = table.Column<int>(type: "integer", nullable: true),
                    GrupoId = table.Column<int>(type: "integer", nullable: true),
                    QuantidadeCapsulas = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaPadrao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormulaPadrao_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormulaPadrao_Posologia_PosologiaId",
                        column: x => x.PosologiaId,
                        principalTable: "Posologia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormulaPadrao_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormulaPadrao_Unidade_UnidadeDoseId",
                        column: x => x.UnidadeDoseId,
                        principalTable: "Unidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormulaPadrao_Unidade_UnidadeDosePadraoId",
                        column: x => x.UnidadeDosePadraoId,
                        principalTable: "Unidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormulaPadrao_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UnidadeConversao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sigla = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Fator = table.Column<double>(type: "double precision", nullable: true),
                    UnidadeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeConversao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadeConversao_Unidade_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidade",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contabilista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BairroId = table.Column<int>(type: "integer", nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: true),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Crc = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Fax = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contabilista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contabilista_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contabilista_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contabilista_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeFornecedor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    NomeFantasia = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    InscricaoEstadual = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NumeroEndereco = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    BairroId = table.Column<int>(type: "integer", nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: false),
                    Ddd = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Fax = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    HomePage = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    Contato = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TelefoneContato = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    BancoId = table.Column<int>(type: "integer", nullable: true),
                    Agencia = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    ContaCorrenteFornecedor = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    ResponsavelTecnico = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AlvaraSanitario = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    AutorizacaoFuncionamento = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    AutorizacaoEspecial = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    LicencaMapa = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CadastroFarmacia = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PlanoDeContaId = table.Column<int>(type: "integer", nullable: true),
                    ValorMinimoPedido = table.Column<decimal>(type: "numeric", nullable: true),
                    FormaPagamento = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PrevisaoEntrega = table.Column<int>(type: "integer", nullable: true),
                    Frete = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Observacoes = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    UsuarioFornecedor = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    SenhaFornecedor = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    HostFornecedor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedor_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fornecedor_Banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fornecedor_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Fornecedor_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fornecedor_PlanoDeContas_PlanoDeContaId",
                        column: x => x.PlanoDeContaId,
                        principalTable: "PlanoDeContas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transportador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BairroId = table.Column<int>(type: "integer", nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: true),
                    EstadoPlacaId = table.Column<int>(type: "integer", nullable: true),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CpfCnpj = table.Column<string>(type: "text", nullable: false),
                    Ie = table.Column<string>(type: "text", nullable: true),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    DDD = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    CodigoAntt = table.Column<string>(type: "text", nullable: true),
                    Placa = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportador_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transportador_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transportador_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transportador_Estado_EstadoPlacaId",
                        column: x => x.EstadoPlacaId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Genero = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: true),
                    Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    NumeroEndereco = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                    Endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    BairroId = table.Column<int>(type: "integer", nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: true),
                    Ddd = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Comissao = table.Column<double>(type: "double precision", nullable: true),
                    CpfOuCnpj = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LimiteDesconto = table.Column<double>(type: "double precision", nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    NomeAbreviado = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    LoginVendedorFarmaciaPopular = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    SenhaVendedorFarmaciaPopular = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendedor_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vendedor_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vendedor_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vendedor_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    BairroId = table.Column<int>(type: "integer", nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: true),
                    DDD = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: true),
                    Comissao = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitador", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visitador_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visitador_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Visitador_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormaFarmaceutica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descrição = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Inativo = table.Column<bool>(type: "boolean", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    SelecionaQuantidadeSugerida = table.Column<bool>(type: "boolean", nullable: false),
                    MultiplicaComposicao = table.Column<bool>(type: "boolean", nullable: false),
                    HomeopatiaLiquida = table.Column<bool>(type: "boolean", nullable: false),
                    DeduzirQuantidadeVeiculo = table.Column<bool>(type: "boolean", nullable: false),
                    CalculoEmbalagemForma = table.Column<int>(type: "integer", nullable: true),
                    ConverteVolumeEmbalagem = table.Column<bool>(type: "boolean", nullable: false),
                    Uso = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    TipoUso = table.Column<int>(type: "integer", nullable: true),
                    POPForma = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    ImprimirCamposAnalise = table.Column<bool>(type: "boolean", nullable: false),
                    SelecionarVolumeAutomático = table.Column<bool>(type: "boolean", nullable: false),
                    Validade = table.Column<int>(type: "integer", nullable: true),
                    MlGotas = table.Column<double>(type: "double precision", nullable: true),
                    ImprimirUnidadeMedidaNoRotulo = table.Column<bool>(type: "boolean", nullable: false),
                    FatorPerdaProduto = table.Column<double>(type: "double precision", nullable: true),
                    AtivaFatorPerdaQsp = table.Column<bool>(type: "boolean", nullable: false),
                    ManipuladorId = table.Column<int>(type: "integer", nullable: true),
                    QuantidadeFormulasHora = table.Column<int>(type: "integer", nullable: true),
                    DescricaoRotulo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    QuantidadeQspMinimo = table.Column<double>(type: "double precision", nullable: true),
                    ProdutoVeiculoId = table.Column<int>(type: "integer", nullable: true),
                    GrupoVeiculoId = table.Column<int>(type: "integer", nullable: true),
                    AtivaPesagemMonitorada = table.Column<bool>(type: "boolean", nullable: false),
                    CalcularDensidade = table.Column<bool>(type: "boolean", nullable: false),
                    ValorMinimo = table.Column<double>(type: "double precision", nullable: true),
                    CustoAdicional = table.Column<double>(type: "double precision", nullable: true),
                    NcmId = table.Column<int>(type: "integer", nullable: true),
                    CodigoLaboratorioLp = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    CodigoFuncionarioManipulacao = table.Column<int>(type: "integer", nullable: true),
                    CodigoFormaReceituario = table.Column<int>(type: "integer", nullable: true),
                    CodigoFilialProducao = table.Column<int>(type: "integer", nullable: true),
                    AliquotaIva = table.Column<double>(type: "double precision", nullable: true),
                    ImagemByte = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaFarmaceutica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormaFarmaceutica_FuncionarioLaboratorio_ManipuladorId",
                        column: x => x.ManipuladorId,
                        principalTable: "FuncionarioLaboratorio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormaFarmaceutica_Ncm_NcmId",
                        column: x => x.NcmId,
                        principalTable: "Ncm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormaFarmaceutica_Produto_GrupoVeiculoId",
                        column: x => x.GrupoVeiculoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormaFarmaceutica_Produto_ProdutoVeiculoId",
                        column: x => x.ProdutoVeiculoId,
                        principalTable: "Produto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LocalEntrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<double>(type: "double precision", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    TaxaEntrega = table.Column<double>(type: "double precision", nullable: false),
                    NcmId = table.Column<int>(type: "integer", nullable: true),
                    AliquotaIss = table.Column<double>(type: "double precision", nullable: true),
                    CfopId = table.Column<int>(type: "integer", nullable: true),
                    EntregadorId = table.Column<int>(type: "integer", nullable: true),
                    CstId = table.Column<int>(type: "integer", nullable: true),
                    CsosnId = table.Column<int>(type: "integer", nullable: true),
                    CodigoBeneficioFiscalId = table.Column<int>(type: "integer", nullable: true),
                    CodigoNatureza = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalEntrega", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalEntrega_Entregador_EntregadorId",
                        column: x => x.EntregadorId,
                        principalTable: "Entregador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocalEntrega_NaturezaOperacao_CfopId",
                        column: x => x.CfopId,
                        principalTable: "NaturezaOperacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocalEntrega_Ncm_NcmId",
                        column: x => x.NcmId,
                        principalTable: "Ncm",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocalEntrega_Tributo_CodigoBeneficioFiscalId",
                        column: x => x.CodigoBeneficioFiscalId,
                        principalTable: "Tributo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocalEntrega_Tributo_CsosnId",
                        column: x => x.CsosnId,
                        principalTable: "Tributo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LocalEntrega_Tributo_CstId",
                        column: x => x.CstId,
                        principalTable: "Tributo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NcmEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EstadoOrigemId = table.Column<int>(type: "integer", nullable: false),
                    EstadoDestinoId = table.Column<int>(type: "integer", nullable: false),
                    TributoCstId = table.Column<int>(type: "integer", nullable: true),
                    TributoCsosnId = table.Column<int>(type: "integer", nullable: true),
                    AliquotaIcms = table.Column<double>(type: "double precision", nullable: true),
                    AliquotaIcmsInterna = table.Column<double>(type: "double precision", nullable: true),
                    PercentualMva = table.Column<double>(type: "double precision", nullable: true),
                    PercentualFcp = table.Column<double>(type: "double precision", nullable: true),
                    NcmId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NcmEstado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NcmEstado_Ncm_NcmId",
                        column: x => x.NcmId,
                        principalTable: "Ncm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdministradoraCartao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PrazoRecebimento = table.Column<int>(type: "integer", nullable: true),
                    Desconto = table.Column<decimal>(type: "numeric", nullable: false),
                    Gerenciador = table.Column<int>(type: "integer", nullable: false),
                    CieloPremia = table.Column<int>(type: "integer", nullable: true),
                    Modalidade = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    FornecedorId = table.Column<int>(type: "integer", nullable: true),
                    PlanoDeContaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministradoraCartao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdministradoraCartao_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdministradoraCartao_PlanoDeContas_PlanoDeContaId",
                        column: x => x.PlanoDeContaId,
                        principalTable: "PlanoDeContas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<int>(type: "integer", nullable: true),
                    Descricao = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Conciliar = table.Column<bool>(type: "boolean", nullable: false),
                    FornecedorId = table.Column<int>(type: "integer", nullable: true),
                    ClienteId = table.Column<int>(type: "integer", nullable: true),
                    ContaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transacao_PlanoDeContas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "PlanoDeContas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VendedorComissao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VendedorId = table.Column<int>(type: "integer", nullable: true),
                    GrupoId = table.Column<int>(type: "integer", nullable: true),
                    GrupoId1 = table.Column<int>(type: "integer", nullable: true),
                    Comissao = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendedorComissao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendedorComissao_Grupo_GrupoId1",
                        column: x => x.GrupoId1,
                        principalTable: "Grupo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VendedorComissao_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Convenio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Desconto = table.Column<double>(type: "double precision", nullable: true),
                    Acrescimo = table.Column<double>(type: "double precision", nullable: true),
                    Manifesto = table.Column<double>(type: "double precision", nullable: true),
                    DiaRecebimento = table.Column<int>(type: "integer", nullable: true),
                    Endereco = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    NumeroEndereco = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                    BairroId = table.Column<int>(type: "integer", nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: true),
                    IdentificaodrConvenio = table.Column<int>(type: "integer", nullable: false),
                    Ddd = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CadastroFarmacia = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CodigoPerdigao = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    DiasPrimeiroVencimento = table.Column<int>(type: "integer", nullable: true),
                    Ie = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Bloqueado = table.Column<bool>(type: "boolean", nullable: false),
                    PermitirParcelamento = table.Column<bool>(type: "boolean", nullable: false),
                    EnviarEcommerce = table.Column<bool>(type: "boolean", nullable: false),
                    PermitirRateio = table.Column<bool>(type: "boolean", nullable: false),
                    VisitadorId = table.Column<int>(type: "integer", nullable: true),
                    EtiquetaId = table.Column<int>(type: "integer", nullable: true),
                    EnderecoComprovanteVenda = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Convenio_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Convenio_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Convenio_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Convenio_Visitador_VisitadorId",
                        column: x => x.VisitadorId,
                        principalTable: "Visitador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prescritor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BairroId = table.Column<int>(type: "integer", nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: true),
                    EstadoId = table.Column<int>(type: "integer", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    DataNascimento = table.Column<DateTime>(name: "Data_Nascimento", type: "timestamp without time zone", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    CpfCnpj = table.Column<string>(type: "text", nullable: true),
                    DDD = table.Column<string>(type: "text", nullable: true),
                    DDDCelular = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Celular = table.Column<string>(type: "text", nullable: true),
                    Secretaria = table.Column<string>(type: "text", nullable: true),
                    NomeRotulo = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Genero = table.Column<int>(type: "integer", nullable: false),
                    TipoCr = table.Column<int>(type: "integer", nullable: false),
                    CrmNumero = table.Column<string>(type: "text", nullable: false),
                    CrmEstado = table.Column<string>(type: "text", nullable: false),
                    CrmTipo = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Aniversario = table.Column<string>(type: "text", nullable: true),
                    EnderecoRes = table.Column<string>(type: "text", nullable: true),
                    NumeroRes = table.Column<string>(type: "text", nullable: true),
                    CepRes = table.Column<string>(type: "text", nullable: true),
                    DDDRes = table.Column<string>(type: "text", nullable: true),
                    TelefoneRes = table.Column<string>(type: "text", nullable: true),
                    Proximidade = table.Column<string>(type: "text", nullable: true),
                    VisitadorId = table.Column<int>(type: "integer", nullable: true),
                    ObservacaoVenda = table.Column<string>(type: "text", nullable: true),
                    Cedh = table.Column<bool>(type: "boolean", nullable: false),
                    RegistroMapa = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescritor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescritor_Bairro_BairroId",
                        column: x => x.BairroId,
                        principalTable: "Bairro",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prescritor_Cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidade",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prescritor_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prescritor_Visitador_VisitadorId",
                        column: x => x.VisitadorId,
                        principalTable: "Visitador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormaFarmaceuticaEnsaio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FormaFarmaceuticaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaFarmaceuticaEnsaio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormaFarmaceuticaEnsaio_FormaFarmaceutica_FormaFarmaceutica~",
                        column: x => x.FormaFarmaceuticaId,
                        principalTable: "FormaFarmaceutica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormaFarmaceuticaMargem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ValorInicial = table.Column<double>(type: "double precision", nullable: true),
                    ValorFinal = table.Column<double>(type: "double precision", nullable: true),
                    Margem = table.Column<double>(type: "double precision", nullable: false),
                    FormaFarmaceuticaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaFarmaceuticaMargem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormaFarmaceuticaMargem_FormaFarmaceutica_FormaFarmaceutica~",
                        column: x => x.FormaFarmaceuticaId,
                        principalTable: "FormaFarmaceutica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConvenioGrupo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GrupoId = table.Column<int>(type: "integer", nullable: false),
                    Desconto = table.Column<double>(type: "double precision", nullable: false),
                    AplicaDescontoProduto = table.Column<bool>(type: "boolean", nullable: false),
                    AplicaCustoReferencia = table.Column<bool>(type: "boolean", nullable: false),
                    ConvenioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvenioGrupo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConvenioGrupo_Convenio_ConvenioId",
                        column: x => x.ConvenioId,
                        principalTable: "Convenio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConvenioGrupo_Grupo_GrupoId",
                        column: x => x.GrupoId,
                        principalTable: "Grupo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EspecialidadePrescritor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrescritorId = table.Column<int>(type: "integer", nullable: true),
                    EspecialidadeId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadePrescritor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EspecialidadePrescritor_Prescritor_PrescritorId",
                        column: x => x.PrescritorId,
                        principalTable: "Prescritor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministradoraCartao_FornecedorId",
                table: "AdministradoraCartao",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministradoraCartao_PlanoDeContaId",
                table: "AdministradoraCartao",
                column: "PlanoDeContaId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_CategoriaPaiId",
                table: "Categoria",
                column: "CategoriaPaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Cidade_CodigoCfpsId",
                table: "Cidade",
                column: "CodigoCfpsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contabilista_BairroId",
                table: "Contabilista",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Contabilista_CidadeId",
                table: "Contabilista",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Contabilista_EstadoId",
                table: "Contabilista",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Convenio_BairroId",
                table: "Convenio",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Convenio_CidadeId",
                table: "Convenio",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Convenio_EstadoId",
                table: "Convenio",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Convenio_VisitadorId",
                table: "Convenio",
                column: "VisitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvenioGrupo_ConvenioId",
                table: "ConvenioGrupo",
                column: "ConvenioId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvenioGrupo_GrupoId",
                table: "ConvenioGrupo",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensaio_FarmacopeiaId",
                table: "Ensaio",
                column: "FarmacopeiaId");

            migrationBuilder.CreateIndex(
                name: "IX_EntregadorRegiao_EntregadorId",
                table: "EntregadorRegiao",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EntregadorRegiao_RegiaoId",
                table: "EntregadorRegiao",
                column: "RegiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_EspecialidadePrescritor_PrescritorId",
                table: "EspecialidadePrescritor",
                column: "PrescritorId");

            migrationBuilder.CreateIndex(
                name: "IX_Estado_PaisId",
                table: "Estado",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_FidelidadePremios_FidelidadeId",
                table: "FidelidadePremios",
                column: "FidelidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_FidelidadePremios_GrupoId",
                table: "FidelidadePremios",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_FidelidadePremios_ProdutoId",
                table: "FidelidadePremios",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaFarmaceutica_GrupoVeiculoId",
                table: "FormaFarmaceutica",
                column: "GrupoVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaFarmaceutica_ManipuladorId",
                table: "FormaFarmaceutica",
                column: "ManipuladorId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaFarmaceutica_NcmId",
                table: "FormaFarmaceutica",
                column: "NcmId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaFarmaceutica_ProdutoVeiculoId",
                table: "FormaFarmaceutica",
                column: "ProdutoVeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaFarmaceuticaEnsaio_FormaFarmaceuticaId",
                table: "FormaFarmaceuticaEnsaio",
                column: "FormaFarmaceuticaId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaFarmaceuticaMargem_FormaFarmaceuticaId",
                table: "FormaFarmaceuticaMargem",
                column: "FormaFarmaceuticaId");

            migrationBuilder.CreateIndex(
                name: "IX_FormaPagamento_PlanoDeContaId",
                table: "FormaPagamento",
                column: "PlanoDeContaId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaPadrao_GrupoId",
                table: "FormulaPadrao",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaPadrao_PosologiaId",
                table: "FormulaPadrao",
                column: "PosologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaPadrao_ProdutoId",
                table: "FormulaPadrao",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaPadrao_UnidadeDoseId",
                table: "FormulaPadrao",
                column: "UnidadeDoseId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaPadrao_UnidadeDosePadraoId",
                table: "FormulaPadrao",
                column: "UnidadeDosePadraoId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaPadrao_UnidadeId",
                table: "FormulaPadrao",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_BairroId",
                table: "Fornecedor",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_BancoId",
                table: "Fornecedor",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_CidadeId",
                table: "Fornecedor",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_EstadoId",
                table: "Fornecedor",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedor_PlanoDeContaId",
                table: "Fornecedor",
                column: "PlanoDeContaId");

            migrationBuilder.CreateIndex(
                name: "IX_GrupoEnsaio_GrupoId",
                table: "GrupoEnsaio",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalEntrega_CfopId",
                table: "LocalEntrega",
                column: "CfopId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalEntrega_CodigoBeneficioFiscalId",
                table: "LocalEntrega",
                column: "CodigoBeneficioFiscalId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalEntrega_CsosnId",
                table: "LocalEntrega",
                column: "CsosnId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalEntrega_CstId",
                table: "LocalEntrega",
                column: "CstId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalEntrega_EntregadorId",
                table: "LocalEntrega",
                column: "EntregadorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalEntrega_NcmId",
                table: "LocalEntrega",
                column: "NcmId");

            migrationBuilder.CreateIndex(
                name: "IX_MaquinaPos_AdquirentePosId",
                table: "MaquinaPos",
                column: "AdquirentePosId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturezaOperacao_CsosnId",
                table: "NaturezaOperacao",
                column: "CsosnId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturezaOperacao_CstId",
                table: "NaturezaOperacao",
                column: "CstId");

            migrationBuilder.CreateIndex(
                name: "IX_NaturezaOperacao_PlanoDeContaId",
                table: "NaturezaOperacao",
                column: "PlanoDeContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncm_TributoCstCofinsEntradaId",
                table: "Ncm",
                column: "TributoCstCofinsEntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncm_TributoCstCofinsSaidaId",
                table: "Ncm",
                column: "TributoCstCofinsSaidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncm_TributoCstPisEntradaId",
                table: "Ncm",
                column: "TributoCstPisEntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ncm_TributoCstPisSaidaId",
                table: "Ncm",
                column: "TributoCstPisSaidaId");

            migrationBuilder.CreateIndex(
                name: "IX_NcmEstado_NcmId",
                table: "NcmEstado",
                column: "NcmId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescritor_BairroId",
                table: "Prescritor",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescritor_CidadeId",
                table: "Prescritor",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescritor_EstadoId",
                table: "Prescritor",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescritor_VisitadorId",
                table: "Prescritor",
                column: "VisitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCapsula_CapsulaPadraoId",
                table: "TipoCapsula",
                column: "CapsulaPadraoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCapsula_GrupoCapsulasId",
                table: "TipoCapsula",
                column: "GrupoCapsulasId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ContaId",
                table: "Transacao",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_FornecedorId",
                table: "Transacao",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportador_BairroId",
                table: "Transportador",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportador_CidadeId",
                table: "Transportador",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportador_EstadoId",
                table: "Transportador",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportador_EstadoPlacaId",
                table: "Transportador",
                column: "EstadoPlacaId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeConversao_UnidadeId",
                table: "UnidadeConversao",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_GrupoUsuarioId",
                table: "Usuario",
                column: "GrupoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_BairroId",
                table: "Vendedor",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_CidadeId",
                table: "Vendedor",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_EstadoId",
                table: "Vendedor",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_UsuarioId",
                table: "Vendedor",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VendedorComissao_GrupoId1",
                table: "VendedorComissao",
                column: "GrupoId1");

            migrationBuilder.CreateIndex(
                name: "IX_VendedorComissao_VendedorId",
                table: "VendedorComissao",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitador_BairroId",
                table: "Visitador",
                column: "BairroId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitador_CidadeId",
                table: "Visitador",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Visitador_EstadoId",
                table: "Visitador",
                column: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministradoraCartao");

            migrationBuilder.DropTable(
                name: "AliquotaEstado");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Balanca");

            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "Bula");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Contabilista");

            migrationBuilder.DropTable(
                name: "ContaCorrente");

            migrationBuilder.DropTable(
                name: "ConvenioGrupo");

            migrationBuilder.DropTable(
                name: "Dcb");

            migrationBuilder.DropTable(
                name: "Dci");

            migrationBuilder.DropTable(
                name: "DiasHoras");

            migrationBuilder.DropTable(
                name: "Diferimento");

            migrationBuilder.DropTable(
                name: "DOM_RegimeTributario");

            migrationBuilder.DropTable(
                name: "Ecf");

            migrationBuilder.DropTable(
                name: "Ensaio");

            migrationBuilder.DropTable(
                name: "EntregadorRegiao");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "EspecialidadePrescritor");

            migrationBuilder.DropTable(
                name: "EspecificacaoCapsula");

            migrationBuilder.DropTable(
                name: "Etapa");

            migrationBuilder.DropTable(
                name: "Etiqueta");

            migrationBuilder.DropTable(
                name: "FidelidadeFormaPagamento");

            migrationBuilder.DropTable(
                name: "FidelidadePremios");

            migrationBuilder.DropTable(
                name: "FormaFarmaceuticaEnsaio");

            migrationBuilder.DropTable(
                name: "FormaFarmaceuticaFaixa");

            migrationBuilder.DropTable(
                name: "FormaFarmaceuticaMargem");

            migrationBuilder.DropTable(
                name: "FormaPagamento");

            migrationBuilder.DropTable(
                name: "FormulaPadrao");

            migrationBuilder.DropTable(
                name: "GrupoEnsaio");

            migrationBuilder.DropTable(
                name: "Laboratorio");

            migrationBuilder.DropTable(
                name: "ListaControlado");

            migrationBuilder.DropTable(
                name: "LocalEntrega");

            migrationBuilder.DropTable(
                name: "MaquinaPos");

            migrationBuilder.DropTable(
                name: "MensagensPadrao");

            migrationBuilder.DropTable(
                name: "Metodo");

            migrationBuilder.DropTable(
                name: "Moeda");

            migrationBuilder.DropTable(
                name: "Motivo");

            migrationBuilder.DropTable(
                name: "Nbm");

            migrationBuilder.DropTable(
                name: "NcmEstado");

            migrationBuilder.DropTable(
                name: "OperadorCaixa");

            migrationBuilder.DropTable(
                name: "Pbm");

            migrationBuilder.DropTable(
                name: "Portador");

            migrationBuilder.DropTable(
                name: "PrincipioAtivo");

            migrationBuilder.DropTable(
                name: "Setor");

            migrationBuilder.DropTable(
                name: "SetorDiasHoras");

            migrationBuilder.DropTable(
                name: "SetorForma");

            migrationBuilder.DropTable(
                name: "TabelaFloral");

            migrationBuilder.DropTable(
                name: "TabelaHomeopatia");

            migrationBuilder.DropTable(
                name: "TabelaHomeopatiaQuantidade");

            migrationBuilder.DropTable(
                name: "TipoCapsula");

            migrationBuilder.DropTable(
                name: "TipoContato");

            migrationBuilder.DropTable(
                name: "TipoJustificativa");

            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Transportador");

            migrationBuilder.DropTable(
                name: "Turno");

            migrationBuilder.DropTable(
                name: "UnidadeConversao");

            migrationBuilder.DropTable(
                name: "VendedorComissao");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Convenio");

            migrationBuilder.DropTable(
                name: "Farmacopeia");

            migrationBuilder.DropTable(
                name: "Regiao");

            migrationBuilder.DropTable(
                name: "Prescritor");

            migrationBuilder.DropTable(
                name: "Fidelidade");

            migrationBuilder.DropTable(
                name: "FormaFarmaceutica");

            migrationBuilder.DropTable(
                name: "Posologia");

            migrationBuilder.DropTable(
                name: "Entregador");

            migrationBuilder.DropTable(
                name: "NaturezaOperacao");

            migrationBuilder.DropTable(
                name: "PosAdquirente");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Unidade");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "Vendedor");

            migrationBuilder.DropTable(
                name: "Visitador");

            migrationBuilder.DropTable(
                name: "FuncionarioLaboratorio");

            migrationBuilder.DropTable(
                name: "Ncm");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "PlanoDeContas");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Bairro");

            migrationBuilder.DropTable(
                name: "Cidade");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "GrupoUsuario");

            migrationBuilder.DropTable(
                name: "Tributo");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
