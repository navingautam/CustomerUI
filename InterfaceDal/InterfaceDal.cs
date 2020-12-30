using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceDal
{
    // Design pattern :- Generic Repository pattern
    public interface IRepository<AnyType>
    {
        void SetUnitWork(IUow uow);
        void Add(AnyType obj); // Inmemory addition
        void Update(AnyType obj);  // Inmemory updation
        List<AnyType> Search();
        void Save(); // Physical committ
    }
    // Design pattern :- Unit of Work pattern
    public interface IUow
    {
        void Committ();
        void RollBack();
    }
}
