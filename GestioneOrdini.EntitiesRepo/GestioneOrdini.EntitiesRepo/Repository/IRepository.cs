using GestioneOrdini.EntitiesRepo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneOrdini.EntitiesRepo.Repository
{
    public interface IRepository<T> where T : IEntity
    {

        bool Create(T item);
        bool Delete(T item);
        T GetById(int id);
        T GetByCode(string code);
        IEnumerable<T> GetAll();

        bool Update(T item);
    }
}
