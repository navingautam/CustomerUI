using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using InterfaceCustomer;
using Unity.Injection;
using InterfaceDal;
using Unity.Resolution;
using AdoDotNetDal;
using EfDal;

namespace FactoryDal
{
    public static class FactoryDal<AnyType> // Design Pattern: Simple Factory pattern
    {
        private static IUnityContainer objectsOfOurProjects = null;

        public static AnyType Create(string Type)
        {
            // Design Pattern: Lazy Loading. Opposite is Eager Loading
            if (objectsOfOurProjects == null)
            {
                objectsOfOurProjects = new UnityContainer();
               
                objectsOfOurProjects.RegisterType<IDal<CustomerBase>, CustomerDAL>("ADODal");
                objectsOfOurProjects.RegisterType<IDal<CustomerBase>, EfCustomerDal>("EFDal");
            }
            // Design Pattern: RIP Replace If with Polymorphism
            return objectsOfOurProjects.Resolve<AnyType>(Type,
                new ResolverOverride[]
                {
                    new ParameterOverride("connectionString",
                    @"Data Source=TAB112336;Initial Catalog=CustomerDB;"+
                    "User ID=sa;Password=Dragonsaren0evil;" +
                    "Integrated Security=True")
                });
        }
    }
}
