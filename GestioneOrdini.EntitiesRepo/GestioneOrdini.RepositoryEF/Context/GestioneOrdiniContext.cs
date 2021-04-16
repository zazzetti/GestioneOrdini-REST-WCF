using GestioneOrdini.EntitiesRepo.Entities;
using GestioneOrdini.RepositoryEF.Context.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.RepositoryEF.Context
{
    public class GestioneOrdiniContext: DbContext
    {

        public GestioneOrdiniContext() : base() { }
        public GestioneOrdiniContext(DbContextOptions<GestioneOrdiniContext> options) : base(options) { }

        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<Cliente> Clienti { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Persist Security Info=False; Integrated Security=True; Initial Catalog= GestioneOrdini; Server=.\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration<Ordine>(new OrdineConfiguration());
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());


        }
    }
}
