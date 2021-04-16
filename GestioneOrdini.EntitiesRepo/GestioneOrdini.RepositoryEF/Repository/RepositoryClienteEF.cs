using GestioneOrdini.EntitiesRepo.Entities;
using GestioneOrdini.EntitiesRepo.Repository;
using GestioneOrdini.RepositoryEF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneOrdini.RepositoryEF.Repository
{
    public class RepositoryClienteEF : IRepositoryCliente
    {

        private readonly GestioneOrdiniContext ctx;
        public RepositoryClienteEF() : this(new GestioneOrdiniContext()) { }
        public RepositoryClienteEF(GestioneOrdiniContext ctx) { this.ctx = ctx; }

        public bool Create(Cliente item)
        {
            try
            {
                ctx.Clienti.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(Cliente item)
        {

            try
            {
                ctx.Clienti.Remove(item);


                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                return ctx.Clienti.ToList();
            }
            catch (Exception)
            {

                return default;
            }
        }

        public Cliente GetByCode(string code)
        {
            try
            {
                return ctx.Clienti.FirstOrDefault(c=>c.CodiceCliente==code);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Cliente GetById(int id)
        {
            try
            {
                return ctx.Clienti.Find(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Update(Cliente item)
        {
            try
            {
                ctx.Clienti.Update(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
