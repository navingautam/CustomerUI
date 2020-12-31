using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
namespace MiddleLayer
{

    public class Customer : CustomerBase
    {

        public Customer(IValidation<ICustomer> obj,
                            IDiscount dis,
                            IExtraCharge extra,
                            string _CustType) : base(obj, dis, extra)
        {
            CustomerType = _CustType;
            CustomerName = "";
            PhoneNumber = "";
            BillAmount = 0;
            BillDate = DateTime.Now;
            Address = "";
        }

    }

}
