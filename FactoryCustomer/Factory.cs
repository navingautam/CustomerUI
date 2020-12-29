using MiddleLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCustomer
{
    public static class Factory // Design Pattern: Simple Factory pattern
    {
        private static Dictionary<string, CustomerBase> custs =
            new Dictionary<string, CustomerBase>();

        // Using Lazy keyword
        //private static Lazy<Dictionary<string, CustomerBase>> custs 
        //    = new Lazy<Dictionary<string, CustomerBase>>(() => LoadCustomer());

        //public static Dictionary<string, CustomerBase> LoadCustomer()
        //{
        //    Dictionary<string, CustomerBase> temp = new Dictionary<string, CustomerBase>();
        //    temp.Add("Customer", new Customer());
        //    temp.Add("Lead", new Lead());
        //    return temp;
        //}

        public static CustomerBase Create(string TypeCust)
        {
            // Design Pattern: Lazy Loading. Opposite is Eager Loading
            if (custs.Count == 0)
            {
                custs.Add("Customer", new Customer());
                custs.Add("Lead", new Lead());
            }
            // Design Pattern: RIP Replace If with Polymorphism
            return custs[TypeCust];

            // Using Lazy Keyword
            //return custs.Value[TypeCust];
        }
    }
}
