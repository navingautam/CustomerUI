using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
namespace MiddleLayer
{

    public class Customer : CustomerBase
    {
        public Customer(IValidation<ICustomer> obj, string _custType) : base(obj)
        {
            CustomerType = _custType;
        }

    }
    
}
