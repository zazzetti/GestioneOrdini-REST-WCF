using GestioneOrdini.EntitiesRepo.Entities;
using GestioneOrdini.EntitiesRepo.Repository;
using GestioneOrdini.RepositoryEF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestioneOrdini.WCFService
{
    public class ServiceCliente : IServiceCliente
    {
        private readonly IRepositoryCliente clienteRepository= new RepositoryClienteEF();

        public bool CreateCliente(Cliente newCliente)
        {
            return clienteRepository.Create(newCliente);
        }

        public bool DeleteCliente(string codeCliente)
        {
            var item = clienteRepository.GetByCode(codeCliente);
            return clienteRepository.Delete(item);

        }

        public bool EditCliente(Cliente clienteToEdit)
        {
            var item = clienteRepository.GetByCode(clienteToEdit.CodiceCliente);
            if (!clienteRepository.Delete(item) || !clienteRepository.Create(clienteToEdit)) return false;

           

            return true;
        }

        public IEnumerable<Cliente> FetchClienti()
        {
            return clienteRepository.GetAll();
        }



        public Cliente GetClienteByCode(string codeCliente)
        {
            var cliente = clienteRepository.GetByCode(codeCliente);
            return cliente;
        }
    }
}
