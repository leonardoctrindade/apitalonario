using System;
using System.Text;
using Data.Entidades;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Data.Config
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //Compras
        public DbSet<Agente> Agente { get; set; }
        public DbSet<AcompanhamentoPessoal> AcompanhamentoPessoal { get; set; }
        public DbSet<AdministradoraCartao> AdministradoraCartao { get; set; }
        public DbSet<AliquotaEstado> AliquotaEstado { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Balanca> Balanca { get; set; }
        public DbSet<Banco> Banco { get; set; }
        public DbSet<Banner> Banner { get; set; }
        public DbSet<Bula> Bula { get; set; }
        public DbSet<CartoesTEF> CartoesTEF { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ConfiguracoesPrismafive> ConfiguracoesPrismafive { get; set; }
        public DbSet<Contabilista> Contabilista { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Convenio> Convenio { get; set; }
        public DbSet<ConvenioCliente> ConvenioCliente { get; set; }
        public DbSet<ConvenioGrupo> ConvenioGrupo { get; set; }
        public DbSet<ConvenioParametro> ConvenioParametro { get; set; }
        public DbSet<CupomFiscal> CupomFiscal { get; set; }
        public DbSet<Dcb> Dcb { get; set; }
        public DbSet<Dci> Dci { get; set; }
        public DbSet<DiasHoras> DiasHoras { get; set; }
        public DbSet<Diferimento> Diferimento { get; set; }
        public DbSet<DOM_RegimeTributario> DOM_RegimeTributario { get; set; }
        public DbSet<DrogariaAcabado> DrogariaAcabado { get; set; }
        public DbSet<Ecf> Ecf { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<EnderecoEntregaCliente> EnderecoEntregaCliente { get; set; }
        public DbSet<Ensaio> Ensaio { get; set; }
        public DbSet<Entregador> Entregador { get; set; }
        public DbSet<EntregadorRegiao> EntregadorRegiao { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<EspecialidadePrescritor> EspecialidadePrescritor { get; set; }
        public DbSet<EspecificacaoCapsula> EspecificacaoCapsula { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Etapa> Etapa { get; set; }
        public DbSet<Etiqueta> Etiqueta { get; set; }
        public DbSet<Farmaceutico> Farmaceutico { get; set; }
        public DbSet<Farmacia> Farmacia { get; set; }
        public DbSet<Farmacopeia> Farmacopeia { get; set; }
        public DbSet<Fidelidade> Fidelidade { get; set; }
        public DbSet<FidelidadeFormaPagamento> FidelidadeFormaPagamento { get; set; }
        public DbSet<FidelidadePremios> FidelidadePremios { get; set; }
        public DbSet<FormaFarmaceutica> FormaFarmaceutica { get; set; }
        public DbSet<FormaFarmaceuticaEnsaio> FormaFarmaceuticaEnsaio { get; set; }
        public DbSet<FormaFarmaceuticaFaixa> FormaFarmaceuticaFaixa { get; set; }
        public DbSet<FormaFarmaceuticaMargem> FormaFarmaceuticaMargem { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<FormulaPadrao> FormulaPadrao { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<FuncionarioLaboratorio> FuncionarioLaboratorio { get; set; }
        public DbSet<GeralFarmacia> GeralFarmacia { get; set; }
        public DbSet<GeralManipulacao> GeralManipulacao { get; set; }
        public DbSet<GestaoEntrega> GestaoEntrega { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<GrupoEnsaio> GrupoEnsaio { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuario { get; set; }
        public DbSet<HabitosCliente> HabitosCliente { get; set; }
        public DbSet<Impressao> Impressao { get; set; }
        public DbSet<ImpressaoManipulacao> ImpressaoManipulacao { get; set; }
        public DbSet<IntervaloDinamizacaoHomeopatia> IntervaloDinamizacaoHomeopatia { get; set; }
        public DbSet<Laboratorio> Laboratorio { get; set; }
        public DbSet<LimiteDeCompraCliente> LimiteDeCompraCliente { get; set; }
        public DbSet<ListaControlado> ListaControlado { get; set; }
        public DbSet<LocalEntrega> LocalEntrega { get; set; }
        public DbSet<MaquinaPos> MaquinaPos { get; set; }
        public DbSet<MensagensPadrao> MensagensPadrao { get; set; }
        public DbSet<Metodo> Metodo { get; set; }
        public DbSet<Moeda> Moeda { get; set; }
        public DbSet<Motivo> Motivo { get; set; }
        public DbSet<NaturezaOperacao> NaturezaOperacao { get; set; }
        public DbSet<Nbm> Nbm { get; set; }
        public DbSet<Ncm> Ncm { get; set; }
        public DbSet<NcmEstado> NcmEstado { get; set; }
        public DbSet<Nfe> Nfe { get; set; }
        public DbSet<NfeExpedicaoCliente> NfeExpedicaoCliente { get; set; }
        public DbSet<NfeSped> NfeSped { get; set; }
        public DbSet<ObservacoesCliente> ObservacoesCliente { get; set; }
        public DbSet<OpcoesManipulacao> OpcoesManipulacao { get; set; }
        public DbSet<OperadorCaixa> OperadorCaixa { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Parametro> Parametro { get; set; }
        public DbSet<Pbm> Pbm { get; set; }
        public DbSet<PlanoDeContas> PlanoDeContas { get; set; }
        public DbSet<Portador> Portador { get; set; }
        public DbSet<PosAdquirente> PosAdquirente { get; set; }
        public DbSet<Posologia> Posologia { get; set; }
        public DbSet<Prescritor> Prescritor { get; set; }
        public DbSet<PrincipioAtivo> PrincipioAtivo { get; set; }
        public DbSet<PrismaSync> PrismaSync { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<QuantidadeXValorHomeopatia> QuantidadeXValorHomeopatia { get; set; }
        public DbSet<ReacoesAdversas> ReacoesAdversas { get; set; }
        public DbSet<Regiao> Regiao { get; set; }
        public DbSet<RestricaoDeUso> RestricaoDeUso { get; set; } 
        public DbSet<Setor> Setor { get; set; }
        public DbSet<SetorDiasHoras> SetorDiasHoras { get; set; }
        public DbSet<SetorForma> SetorForma { get; set; }
        public DbSet<Sipro> Sipro { get; set; }
        public DbSet<TabelaFloral> TabelaFloral { get; set; }
        public DbSet<TabelaHomeopatia> TabelaHomeopatia { get; set; }
        public DbSet<TipoCapsula> TipoCapsula { get; set; }
        public DbSet<TipoContato> TipoContato { get; set; }
        public DbSet<TipoJustificativa> TipoJustificativa { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Transportador> Transportador { get; set; }
        public DbSet<Tributo> Tributo { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<UnidadeConversao> UnidadeConversao { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<VendedorComissao> VendedorComissao { get; set; }
        public DbSet<Visitador> Visitador { get; set; }
        public DbSet<VolumeXValorHomeopatia> VolumeXValorHomeopatia { get; set; }
        public DbSet<ManutencaoCompras> ManutencaoCompras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
          
           // builder.ForNpgsqlUseIdentityColumns();
            base.OnModelCreating(builder);
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=mssql.mastersoftbr.com.br;Initial Catalog=mastersoftbr12;Integrated Security=False;User ID=mastersoftbr14;Password=legiao22;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;";

            return strCon;
        }
    }
}
