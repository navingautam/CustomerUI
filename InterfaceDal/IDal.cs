using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDal
{
    // Design Pattern: Generic Repository Pattern
    public interface IDal<AnyType>
    {
        void Add(AnyType obj); // Inmemory addition
        void Update(AnyType obj); // Inmemory update
        List<AnyType> Search();
        void Save(); // Physical commit
        
    }
}
