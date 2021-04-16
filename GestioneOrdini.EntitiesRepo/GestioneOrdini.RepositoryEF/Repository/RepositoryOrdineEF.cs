using GestioneOrdini.EntitiesRepo.Entities;
using GestioneOrdini.EntitiesRepo.Repository;
using GestioneOrdini.RepositoryEF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestioneOrdini.RepositoryEF.Repository
{
    public class RepositoryOrdineEF : IRepositoryOrdine
    {
        private readonly GestioneOrdiniContext ctx;
        public RepositoryOrdineEF() : this(new GestioneOrdiniContext()) { }
        public RepositoryOrdineEF(GestioneOrdiniContext ctx) { this.ctx = ctx; }

        public bool Create(Ordine item)
        {
            try
            {
                var cliente = ctx.Clienti.FirstOrDefault(c => c.CodiceCliente == item.Cliente.CodiceCliente);
                if (cliente == null) return false;

                item.Cliente = cliente;
                ctx.Ordini.Add(item);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

      

        public bool Delete(Ordine item)
        {
            try
            {
                ctx.Ordini.Remove(item);


                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Ordine> GetAll()
        {
            try
            {
                return ctx.Ordini.ToList();
            }
            catch (Exception)
            {

                return default;
            }
        }

        public Ordine GetByCode(string code)
        {
            try
            {
                return ctx.Ordini.FirstOrDefault(c => c.CodiceOrdine == code);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Ordine GetById(int id)
        {
            try
            {
                return ctx.Ordini.Find(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool Update(Ordine item)
        {
            try
            {
                var ordine = ctx.Ordini.Include(c=>c.Cliente).FirstOrDefault(o => o.CodiceOrdine==item.CodiceOrdine);
                var cliente = ctx.Clienti.FirstOrDefault(c => c.CodiceCliente == item.Cliente.CodiceCliente);
                if (ordine==null || cliente == null) return false;

                ordine.Cliente = cliente;
                ordine.DataOrdine = item.DataOrdine;
                ordine.CodiceProdotto = item.CodiceProdotto;

                ctx.Ordini.Update(ordine);
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
