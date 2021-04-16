using GestioneOrdini.EntitiesRepo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.RepositoryEF.Context.Configuration
{
    

    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasAlternateKey(c => c.CodiceCliente);

            builder.Property(c=>c.CodiceCliente).HasMaxLength(20); // non specificato se prefissata


            builder.Property(c => c.Nome).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Cognome).HasMaxLength(50).IsRequired();



            builder.HasMany(c => c.Ordini).WithOne(o => o.Cliente);


        }
    }
}
