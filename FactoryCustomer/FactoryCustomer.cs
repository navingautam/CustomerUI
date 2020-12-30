using MiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using InterfaceCustomer;
using ValidationAlgorithms;
using Unity.Injection;


namespace FactoryCustomer
{
    public static class FactoryCustomer<AnyType> // Design Pattern: Simple Factory pattern
    {
        private static IUnityContainer objectsOfOurProjects = null;
       
        public static AnyType Create(string Type)
        {
            // Design Pattern: Lazy Loading. Opposite is Eager Loading
            if (objectsOfOurProjects == null)
            {
                objectsOfOurProjects = new UnityContainer();
                objectsOfOurProjects.RegisterType<CustomerBase, Customer>
                    ("Customer", new InjectionConstructor(new CustomerValidationAll()));
                objectsOfOurProjects.RegisterType<CustomerBase, Lead>
                    ("Lead", new InjectionConstructor(new LeadValidation()));
            }
            // Design Pattern: RIP Replace If with Polymorphism
            return objectsOfOurProjects.Resolve<AnyType>(Type);
        }
    }
}
