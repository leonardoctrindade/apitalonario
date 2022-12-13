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

        public DbSet<Produto> Produto { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Pbm> Pbm { get; set; }
        public DbSet<Farmacopeia> Farmacopeia { get; set; }
        public DbSet<Ensaio> Ensaio { get; set; }
        public DbSet<Bairro> Bairro { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Tributo> Tributo { get; set; }
        public DbSet<Ncm> Ncm { get; set; }
        public DbSet<DOM_RegimeTributario> DOM_RegimeTributario { get; set; }
        public DbSet<Classe> Classe { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Dcb> Dcb { get; set; }
        public DbSet<Dci> Dci { get; set; }
        public DbSet<Laboratorio> Laboratorio { get; set; }
        public DbSet<Nbm> Nbm { get; set; }
        public DbSet<PrincipioAtivo> PrincipioAtivo { get; set; }
        public DbSet<Unidade> Unidade { get; set; }
        public DbSet<Moeda> Moeda { get; set; }
        public DbSet<Portador> Portador { get; set; }
        public DbSet<Banco> Banco { get; set; }
        public DbSet<Transportador> Transportador { get; set; }
        public DbSet<PosAdquirente> PosAdquirente { get; set; }
        public DbSet<MaquinaPos> MaquinaPos { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<TipoContato> TipoContato { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }
        public DbSet<Posologia> Posologia { get; set; }
        public DbSet<AdministradoraCartao> AdministradoraCartao { get; set; }
        public DbSet<Metodo> Metodo { get; set; }
        public DbSet<MensagensPadrao> MensagensPadrao { get; set; }
        public DbSet<EspecificacaoCapsula> EspecificacaoCapsula { get; set; }
        public DbSet<FuncionarioLaboratorio> FuncionarioLaboratorio { get; set; }
        public DbSet<ListaControlado> ListaControlado { get; set; }
        public DbSet<NaturezaOperacao> NaturezaOperacao { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<TabelaFloral> TabelaFloral { get; set; }
        public DbSet<Bula> Bula { get; set; }
        public DbSet<Transacao> Transacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(GetStringConectionConfig()
               ,options => options.SetPostgresVersion(new Version(9, 6)));
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
            string strCon = "User ID=mastersoftbr; Password=legiao22; Host=pgsql.mastersoftbr.com.br; Port=5432; Database=mastersoftbr; Pooling=true;";

            return strCon;
        }
    }
}
