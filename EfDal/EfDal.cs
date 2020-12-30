using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceCustomer;
using InterfaceDal;

namespace EfDal
{
    // Design Pattern: Adapter Pattern (Class Adapter Pattern)
    public class EfDalAbstract<AnyType> : DbContext, IDal<AnyType>
        where AnyType : class
    {
        public EfDalAbstract()
            : base("name=EFContext")
        {

        }
        
        public void Add(AnyType obj)
        {
            Set<AnyType>().Add(obj); // in memory commit
        }

        public void Save()
        {
            SaveChanges(); // Physical commit
        }

        public List<AnyType> Search()
        {
            return Set<AnyType>().
                AsQueryable<AnyType>().
                ToList<AnyType>();
        }

        public void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }
    }

    public class EfCustomerDal : EfDalAbstract<CustomerBase>
    {
        // mapping
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Mapping code
            modelBuilder.Entity<CustomerBase>()
                .ToTable("tblCustomer");
        }
    }
}
