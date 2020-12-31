using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceDal;
using System.Data.Entity;
using InterfaceCustomer;
using System.Data.Entity.Infrastructure;

namespace EfDal
{
    // Design pattern :- Adpater pattern ( class Adapter pattern)
    public class EfDalAbstract<AnyType> : IRepository<AnyType>
        where AnyType : class
    {
        DbContext dbcont = null;
        public EfDalAbstract()
        {
            dbcont = new EUow(); // Self contained transaction
        }
        public void Add(AnyType obj)
        {
            dbcont.Set<AnyType>().Add(obj); // in memory committ
        }

        public void Save()
        {
            dbcont.SaveChanges(); //physical committ
        }
        public void Update(AnyType obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AnyType> Search()
        {
            return dbcont.Set<AnyType>().
                     AsQueryable();
        }



        public void SetUnitWork(IUow uow)
        {
            dbcont = ((EUow)uow); // Global transaction UOW
        }


        public IEnumerable<AnyType> GetData()
        {
            throw new NotImplementedException();
        }
    }




    public class EUow : DbContext, IUow
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerBase>()
                       .ToTable("tblCustomer");
        }
        public EUow() : base("name=Conn")
        {

        }
        public void Committ()
        {
            SaveChanges();
        }

        public void RollBack() // Adapter
        {
            Dispose();
        }
    }
}
