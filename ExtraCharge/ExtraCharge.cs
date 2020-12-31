using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceCustomer;
namespace ExtraCharge
{
    public class ExtrachargeSatSun : IExtraCharge
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
                return 0;
            }
        }
    }
}
