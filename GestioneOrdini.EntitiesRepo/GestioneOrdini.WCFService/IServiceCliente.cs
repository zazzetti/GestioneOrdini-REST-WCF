using GestioneOrdini.EntitiesRepo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GestioneOrdini.WCFService
{
    [ServiceContract]
    public interface IServiceCliente
    {

        [OperationContract]
        bool CreateCliente(Cliente newCliente);

        [OperationContract]
        bool DeleteCliente(string codeCliente);



        [OperationContract]
        Cliente GetClienteByCode(string codeCliente);


        [OperationContract]
        bool EditCliente(Cliente clienteToEdit);

        [OperationContract]
        IEnumerable<Cliente> FetchClienti();

    }

}
