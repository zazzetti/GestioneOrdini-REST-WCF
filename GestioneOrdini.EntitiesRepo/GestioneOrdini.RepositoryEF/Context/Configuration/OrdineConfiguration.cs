using GestioneOrdini.EntitiesRepo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.RepositoryEF.Context.Configuration
{
    

    public class OrdineConfiguration : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasAlternateKey(o => o.CodiceOrdine);

            builder.Property(o => o.CodiceOrdine).HasMaxLength(20); // non specificato se prefissata
            builder.Property(o => o.CodiceProdotto).HasMaxLength(20); // non specificato se prefissata

            builder.Property(o => o.Importo).IsRequired();
            builder.Property(o => o.CodiceProdotto).IsRequired();
            builder.Property(o => o.Importo).HasColumnType("decimal").IsRequired();
            builder.Property(o => o.DataOrdine).HasColumnType("datetime2").IsRequired();

            builder.HasOne(o => o.Cliente).WithMany(c => c.Ordini).IsRequired();


        }
    }
}
