using System;
using System.Text;
using Data.Entidades;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Data.Config
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Agente> Agente { get; set; }
        public DbSet<Multas> Multas { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<ValoresMultas> ValoresMultas { get; set; }
        public DbSet<TotalMultas> TotalMultas { get; set; }


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
            builder.Entity<TotalMultas>().HasNoKey();
            // builder.ForNpgsqlUseIdentityColumns();
            base.OnModelCreating(builder);
        }

        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=mssql.mastersoftbr.com.br;Database=mastersoftbr15;Initial Catalog=mastersoftbr15;Integrated Security=False;User ID=mastersoftbr15;Password=legiao22;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;";

            return strCon;
        }
    }
}
