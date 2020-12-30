using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
using AdoDotnetDAL;
using CommonDAL;
using InterfaceDal;
using EfDal;
using Unity;

namespace FactoryDal
{
    public static class FactoryDalLayer<AnyType> // Design pattern :- Simple factory pattern
    {
        private static IUnityContainer ObjectsofOurProjects = null;


        public static AnyType Create(string Type)
        {
            // Design pattern :- Lazy loading. Eager loading
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();

                ObjectsofOurProjects.RegisterType<IRepository<CustomerBase>,
                    CustomerDAL>("ADODal");
                ObjectsofOurProjects.RegisterType<IRepository<CustomerBase>,
                    EfDalAbstract<CustomerBase>>("EFDal");
                ObjectsofOurProjects.RegisterType<IUow, AdoUow>("AdoUOW");
                ObjectsofOurProjects.RegisterType<IUow, EUow>("EfUOW");

            }
            //Design pattern :-  RIP Replace If with Poly
            return ObjectsofOurProjects.Resolve<AnyType>(Type);
        }
    }
}
