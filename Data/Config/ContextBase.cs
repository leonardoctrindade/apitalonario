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


        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Pbm> Pbm { get; set; }

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
            
            string strCon = "User ID=mastersoftbr; Password=legiao22; Host=pgsql.mastersoftbr.com.br; Port=5432; Database=mastersoftbr; Pooling=true;"; //"Data Source=mssql.mastersoftbr.com.br;Initial Catalog=mastersoftbr12;Integrated Security=False;User ID=mastersoftbr12;Password=legiao22;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;";


            return strCon;
        }
    }
}
