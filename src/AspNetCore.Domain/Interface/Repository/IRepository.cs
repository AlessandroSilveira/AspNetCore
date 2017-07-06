using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.Domain.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T Entitie);

        void Update(T Entitie);

        void Delete(Guid Id);

        List<T> List();

        T GetForId(Guid id);
    }
}
