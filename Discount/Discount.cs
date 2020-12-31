using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
namespace Discount
{
    public class DiscountBillAmount : IDiscount
    {
        public decimal Calculate(ICustomer obj)
        {
            if (obj.BillAmount > 10000)
            {
                return (obj.BillAmount *
                    Convert.ToDecimal(0.02));
            }
            else
            {
                return (obj.BillAmount *
                Convert.ToDecimal(0.01));
            }

        }
    }
    public class DiscountSatSun : IDiscount
    {
        public decimal Calculate(ICustomer obj)
        {
            if ((obj.BillDate.DayOfWeek == DayOfWeek.Sunday) ||
                (obj.BillDate.DayOfWeek == DayOfWeek.Saturday))
            {
                return (obj.BillAmount *
                    Convert.ToDecimal(0.01));
            }
            else
            {
                return (obj.BillAmount *
                Convert.ToDecimal(0.05));
            }

        }
    }
    public class DiscountNull : IDiscount
    {
        public decimal Calculate(ICustomer obj)
        {
            return 0;
        }
    }
    public class ExtraChargeNull : IExtraCharge
    {
        public decimal Calculate(ICustomer obj)
        {
            return 0;
        }
    }
}
