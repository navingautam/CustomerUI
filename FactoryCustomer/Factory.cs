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
    public static class Factory // Design Pattern: Simple Factory pattern
    {
        private static IUnityContainer custs = null;
       
        public static ICustomer Create(string TypeCust)
        {
            // Design Pattern: Lazy Loading. Opposite is Eager Loading
            if (custs == null)
            {
                custs = new UnityContainer();
                custs.RegisterType<ICustomer, Customer>
                    ("Customer", new InjectionConstructor(new CustomerValidationAll()));
                custs.RegisterType<ICustomer, Lead>
                    ("Lead", new InjectionConstructor(new LeadValidation()));
            }
            // Design Pattern: RIP Replace If with Polymorphism
            return custs.Resolve<ICustomer>(TypeCust);

         
        }
    }
}
