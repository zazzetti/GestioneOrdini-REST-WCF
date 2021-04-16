using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GestioneOrdini.EntitiesRepo.Entities
{
    [DataContract]
    public class Cliente : IEntity
    {
        public int Id { get; set; }
        [DataMember]
        public string CodiceCliente { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Cognome { get; set; }



        public ICollection<Ordine> Ordini { get; set; } = new List<Ordine>();

        public override string ToString()
        {
            return $"Codice cliente {CodiceCliente}, Nome: {Nome}, Cogonme: {Cognome}";
        }

    }
}
