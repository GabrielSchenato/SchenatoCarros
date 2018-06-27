using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Schenato.Carros.Dominio.Entidades;

namespace Schenato.Carros.Infraestrutura.Configuracoes
{
    public class AluguelConfiguracao : EntityTypeConfiguration<Aluguel>
    {
        public AluguelConfiguracao()
        {
            ToTable("TBAluguel");

            HasKey(o => o.Id);

            HasRequired(a => a.Cliente)
                  .WithMany()
                  .WillCascadeOnDelete(true);

            Property(o => o.ValorTotal)
                .IsRequired();

            HasRequired(a => a.Automovel)
                  .WithMany()
                  .WillCascadeOnDelete(true);

            Property(o => o.DataInicio)
                .HasColumnType("datetime")
                .IsRequired();

            Property(o => o.DataFim)
                .HasColumnType("datetime")
                .IsRequired();
        }
    }
}
