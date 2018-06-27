using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Schenato.Carros.Infraestrutura.Configuracoes;
using Schenato.Carros.Dominio.Entidades;

namespace Schenato.Carros.Infraestrutura.Contexto
{
    public class CarrosContexto : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Fisica> Fisicas { get; set; }
        public DbSet<Juridico> Juridicos { get; set; }
        public DbSet<Automovel> Automoveis { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }

        public CarrosContexto() : base("CarrosDB")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>()
               .ToTable("TBPessoa");

            modelBuilder.Entity<Automovel>()
                .ToTable("TBAutomovel");

            modelBuilder.Configurations.Add(new AluguelConfiguracao());
        }
    }
}
