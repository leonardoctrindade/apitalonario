using System;
using System.Linq;
using Data.Config;
using WebAPI.Token;
using Data.Entidades;
using Data.Interfaces;
using Data.Repositorio;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            services.AddDbContext<ContextBase>(options =>
              options.UseNpgsql(
                  Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ContextBase>();

            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));  
            services.AddSingleton<IAdministradoraCartao, RepositoryAdministradoraCartao>();
            services.AddSingleton<IAliquotaEstado, RepositoryAliquotaEstado>();
            services.AddSingleton<IBairro, RepositoryBairro>();
            services.AddSingleton<IBalanca, RepositoryBalanca>();
            services.AddSingleton<IBanco, RepositoryBanco>();
            services.AddSingleton<IBanner, RepositoryBanner>();
            services.AddSingleton<IBula, RepositoryBula>();
            services.AddSingleton<ICategoria, RepositoryCategoria>();
            services.AddSingleton<ICidade, RepositoryCidade>();
            services.AddSingleton<IClasse, RepositoryClasse>();
            services.AddSingleton<IContabilista, RepositoryContabilista>();
            services.AddSingleton<IContaCorrente, RepositoryContaCorrente>();
            services.AddSingleton<IConvenio, RepositoryConvenio>();
            services.AddSingleton<IConvenioGrupo, RepositoryConvenioGrupo>();
            services.AddSingleton<IDcb, RepositoryDcb>();
            services.AddSingleton<IDci, RepositoryDci>();
            services.AddSingleton<IDiasHoras, RepositoryDiasHoras>();
            services.AddSingleton<IDiferimento, RepositoryDiferimento>();
            services.AddSingleton<IDOM_RegimeTributario, RepositoryDOM_RegimeTributario>();
            services.AddSingleton<IEnsaio, RepositoryEnsaio>();
            services.AddSingleton<IEntregador, RepositoryEntregador>();
            services.AddSingleton<IEntregadorRegiao, RepositoryEntregadorRegiao>();
            services.AddSingleton<IEspecialidade, RepositoryEspecialidade>();
            services.AddSingleton<IEspecialidadePrescritor, RepositoryEspecialidadePrescritor>();
            services.AddSingleton<IEspecificacaoCapsula, RepositoryEspecificacaoCapsula>();
            services.AddSingleton<IEstado, RepositoryEstado>();
            services.AddSingleton<IEtapa, RepositoryEtapa>();
            services.AddSingleton<IEtiqueta, RepositoryEtiqueta>();
            services.AddSingleton<IFarmacopeia, RepositoryFarmacopeia>();
            services.AddSingleton<IFidelidade, RepositoryFidelidade>();
            services.AddSingleton<IFidelidadeFormaPagamento, RepositoryFidelidadeFormaPagamento>();
            services.AddSingleton<IFidelidadePremios, RepositoryFidelidadePremios>();
            services.AddSingleton<IFormaFarmaceutica, RepositoryFormaFarmaceutica>();
            services.AddSingleton<IFormaFarmaceuticaEnsaio, RepositoryFormaFarmaceuticaEnsaio>();
            services.AddSingleton<IFormaFarmaceuticaFaixa, RepositoryFormaFarmaceuticaFaixa>();
            services.AddSingleton<IFormaFarmaceuticaMargem, RepositoryFormaFarmaceuticaMargem>();
            services.AddSingleton<IFormaPagamento, RepositoryFormaPagamento>();
            services.AddSingleton<IFormulaPadrao, RepositoryFormulaPadrao>();
            services.AddSingleton<IFornecedor, RepositoryFornecedor>();
            services.AddSingleton<IFuncionarioLaboratorio, RepositoryFuncionarioLaboratorio>();
            services.AddSingleton<IGrupo, RepositoryGrupo>();
            services.AddSingleton<IGrupoUsuario, RepositoryGrupoUsuario>();
            services.AddSingleton<ILaboratorio, RepositoryLaboratorio>();
            services.AddSingleton<IListaControlado, RepositoryListaControlado>();
            services.AddSingleton<ILocalEntrega, RepositoryLocalEntrega>();
            services.AddSingleton<IMaquinaPos, RepositoryMaquinaPos>();
            services.AddSingleton<IMensagensPadrao, RepositoryMensagensPadrao>();
            services.AddSingleton<IMetodo, RepositoryMetodo>();
            services.AddSingleton<IMoeda, RepositoryMoeda>();
            services.AddSingleton<IMotivo, RepositoryMotivo>();
            services.AddSingleton<INaturezaOperacao, RepositoryNaturezaOperacao>();
            services.AddSingleton<INbm, RepositoryNbm>();
            services.AddSingleton<INcm, RepositoryNcm>();
            services.AddSingleton<INcmEstado, RepositoryNcmEstado>();
            services.AddSingleton<IOperadorCaixa, RepositoryOperadorCaixa>();
            services.AddSingleton<IPais, RepositoryPais>();
            services.AddSingleton<IPbm, RepositoryPbm>();
            services.AddSingleton<IPlanoDeContas, RepositoryPlanoDeContas>();
            services.AddSingleton<IPortador, RepositoryPortador>();
            services.AddSingleton<IPosAdquirente, RepositoryPosAdquirente>();
            services.AddSingleton<IPosologia, RepositoryPosologia>();
            services.AddSingleton<IPrescritor, RepositoryPrescritor>();
            services.AddSingleton<IPrincipioAtivo, RepositoryPrincipioAtivo>();
            services.AddSingleton<IProduto, RepositoryProduto>();
            services.AddSingleton<IRegiao, RepositoryRegiao>();
            services.AddSingleton<ISetor, RepositorySetor>();
            services.AddSingleton<ISetorDiasHoras, RepositorySetorDiasHoras>();
            services.AddSingleton<ISetorForma, RepositorySetorForma>();
            services.AddSingleton<ITabelaFloral, RepositoryTabelaFloral>();
            services.AddSingleton<ITabelaHomeopatia, RepositoryTabelaHomeopatia>();
            services.AddSingleton<ITabelaHomeopatiaQuantidade, RepositoryTabelaHomeopatiaQuantidade>();
            services.AddSingleton<ITipoCapsula, RepositoryTipoCapsula>();
            services.AddSingleton<ITipoContato, RepositoryTipoContato>();
            services.AddSingleton<ITipoJustificativa, RepositoryTipoJustificativa>();
            services.AddSingleton<ITransacao, RepositoryTransacao>();
            services.AddSingleton<ITransportador, RepositoryTransportador>();
            services.AddSingleton<ITributo, RepositoryTributo>();
            services.AddSingleton<ITurno, RepositoryTurno>();
            services.AddSingleton<IUnidade, RepositoryUnidade>();
            services.AddSingleton<IUnidadeConversao, RepositoryUnidadeConversao>();
            services.AddSingleton<IUsuario, RepositoryUsuario>();
            services.AddSingleton<IVendedor, RepositoryVendedor>();
            services.AddSingleton<IVendedorComissao, RepositoryVendedorComissao>();
            services.AddSingleton<IVisitador, RepositoryVisitador>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(option =>
           {
               option.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,

                   ValidIssuer = "Teste.Securiry.Bearer",
                   ValidAudience = "Teste.Securiry.Bearer",
                   IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
               };

               option.Events = new JwtBearerEvents
               {
                   OnAuthenticationFailed = context =>
                   {
                       Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                       return Task.CompletedTask;
                   },
                   OnTokenValidated = context =>
                   {
                       Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                       return Task.CompletedTask;
                   }
               };
           });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
