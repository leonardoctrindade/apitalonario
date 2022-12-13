using Data.Config;
using Data.Entidades;
using Data.Interfaces;
using Data.Repositorio;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Token;

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
            services.AddDbContext<ContextBase>(options =>
              options.UseNpgsql(
                  Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ContextBase>();

            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGenerics<>));
            services.AddSingleton<IProduto, RepositoryProduto>();
            services.AddSingleton<IFarmacopeia, RepositoryFarmacopeia>();
            services.AddSingleton<IEnsaio, RepositoryEnsaio>();
            services.AddSingleton<IBairro, RepositoryBairro>();
            services.AddSingleton<ICidade, RepositoryCidade>();
            services.AddSingleton<IEstado, RepositoryEstado>();
            services.AddSingleton<ITributo, RepositoryTributo>();
            services.AddSingleton<INcm, RepositoryNcm>();
            services.AddSingleton<IDOM_RegimeTributario, RepositoryDOM_RegimeTributario>();
            services.AddSingleton<IPais, RepositoryPais>();
            services.AddSingleton<IClasse, RepositoryClasse>();
            services.AddSingleton<IContaCorrente, RepositoryContaCorrente>();
            services.AddSingleton<IDcb, RepositoryDcb>();
            services.AddSingleton<INbm, RepositoryNbm>();
            services.AddSingleton<IPrincipioAtivo, RepositoryPrincipioAtivo>();
            services.AddSingleton<IUnidade, RepositoryUnidade>();
            services.AddSingleton<IMoeda, RepositoryMoeda>();
            services.AddSingleton<IPbm, RepositoryPbm>();
            services.AddSingleton<IPortador, RepositoryPortador>();
            services.AddSingleton<IBanco, RepositoryBanco>();
            services.AddSingleton<ITransportador, RepositoryTransportador>();
            services.AddSingleton<IPosAdquirente, RepositoryPosAdquirente>();
            services.AddSingleton<IMaquinaPos, RepositoryMaquinaPos>();
            services.AddSingleton<IEspecialidade, RepositoryEspecialidade>();
            services.AddSingleton<ITipoContato, RepositoryTipoContato>();
            services.AddSingleton<IFormaPagamento, RepositoryFormaPagamento>();
            services.AddSingleton<IPosologia, RepositoryPosologia>();
            services.AddSingleton<IAdministradoraCartao, RepositoryAdministradoraCartao>();
            services.AddSingleton<IMetodo, RepositoryMetodo>();
            services.AddSingleton<IMensagensPadrao, RepositoryMensagensPadrao>();
            services.AddSingleton<IEspecificacaoCapsula, RepositoryEspecificacaoCapsula>();
            services.AddSingleton<IFuncionarioLaboratorio, RepositoryFuncionarioLaboratorio>();
            services.AddSingleton<IListaControlado, RepositoryListaControlado>();
            services.AddSingleton<INaturezaOperacao, RepositoryNaturezaOperacao>();
            services.AddSingleton<IFornecedor, RepositoryFornecedor>();
            services.AddSingleton<ITurno, RepositoryTurno>();
            services.AddSingleton<ITabelaFloral, RepositoryTabelaFloral>();
            services.AddSingleton<IBula, RepositoryBula>();
            services.AddSingleton<ITransacao, RepositoryTransacao>();
            services.AddSingleton<ILocalEntrega, RepositoryLocalEntrega>();

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
