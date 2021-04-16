using GestioneOrdini.EntitiesRepo.Entities;
using GestioneOrdini.EntitiesRepo.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.EntitiesRepo.BusinessLayer
{
    public class GestioneOrdiniBL: IGestioneOrdiniBL
    {

        private readonly IRepositoryCliente clienteRepository;
        private readonly IRepositoryOrdine ordineRepository;


        public GestioneOrdiniBL(IRepositoryCliente clienteRepository, IRepositoryOrdine ordineRepository)
        {
            this.clienteRepository = clienteRepository;
            this.ordineRepository = ordineRepository;


        }

        public bool CreateCliente(Cliente newCliente)
        {
            return clienteRepository.Create(newCliente); 
        }

        public bool DeleteCliente(Cliente clienteToDelete)
        {
            return clienteRepository.Delete(clienteToDelete);
        }
        public bool EditCliente(Cliente clienteToEdit)
        {
            return clienteRepository.Update(clienteToEdit);
        }
        public IEnumerable<Cliente> FetchClienti()
        {
            return clienteRepository.GetAll();
        }
        public Cliente GetClienteByCode(string codeCliente)
        {
            return clienteRepository.GetByCode(codeCliente);
        }

        public bool CreateOrdine(Ordine newOrdine)
        {
            return ordineRepository.Create(newOrdine);
        }



        public bool DeleteOrdine(Ordine ordineToDelete)
        {
            return ordineRepository.Delete(ordineToDelete);
        }

 

        public bool EditOrdine(Ordine ordineToEdit)
        {
            return ordineRepository.Update(ordineToEdit);
        }



        public IEnumerable<Ordine> FetchOrdini()
        {
            return ordineRepository.GetAll();
        }



        public Ordine GetOrdineByCode(string codeOrdine)
        {
            return ordineRepository.GetByCode(codeOrdine);
        }


    }
}
