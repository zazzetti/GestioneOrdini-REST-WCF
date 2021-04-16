using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GestioneOrdini.EntitiesRepo.Entities
{
    [DataContract]
    public class Ordine: IEntity
    {
        public int Id { get; set; }
        [DataMember]
        public string CodiceOrdine { get; set; }
        [DataMember]
        public string CodiceProdotto { get; set; }
        [DataMember]
        public decimal Importo { get; set; }

        public Cliente Cliente { get; set; }

        public DateTime DataOrdine { get; set; } = DateTime.Now;
    }
}
