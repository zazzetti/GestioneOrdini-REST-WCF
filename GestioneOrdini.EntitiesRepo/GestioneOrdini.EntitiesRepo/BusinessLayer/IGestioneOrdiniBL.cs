using GestioneOrdini.EntitiesRepo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.EntitiesRepo.BusinessLayer
{
    public interface IGestioneOrdiniBL
    {

       

        bool CreateCliente(Cliente newCliente);

        bool DeleteCliente(Cliente clienteToDelete);

    
        Cliente GetClienteByCode(string codeCliente);


        bool EditCliente(Cliente clienteToEdit);

        IEnumerable<Cliente> FetchClienti();


        bool CreateOrdine(Ordine newOrdine);

        bool DeleteOrdine(Ordine ordineToDelete);


        Ordine GetOrdineByCode(string codeOrdine);


        bool EditOrdine(Ordine ordineToEdit);

        IEnumerable<Ordine> FetchOrdini();
    }
}
