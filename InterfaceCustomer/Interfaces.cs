using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace InterfaceCustomer
{
    public interface ICustomer
    {
        int Id { get; set; }
        string CustomerType { get; set; }
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        decimal BillAmount { get; set; }
        DateTime BillDate { get; set; }
        string Address { get; set; }
        void Validate();
        void Clone(); // Create a copy of the object
        void Revert(); // Revert back to the old copy
    }
    public class CustomerBase : ICustomer
    {
        private IValidation<ICustomer> validation = null;

        // Design pattern :- memento pattern ( Revert old state)
        private ICustomer _OldCopy = null;

        public CustomerBase(IValidation<ICustomer> obj)
        {
            validation = obj;
        }
        [Key]
        public int Id { get; set; }
        public string CustomerType { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public decimal BillAmount { get; set; }
        public DateTime BillDate { get; set; }
        public string Address { get; set; }
        public CustomerBase()
        {
            CustomerName = "";
            PhoneNumber = "";
            BillAmount = 0;
            BillDate = DateTime.Now;
            Address = "";
        }
        public virtual void Validate()
        {
            validation.Validate(this);
        }


        public void Clone()
        {
            if (_OldCopy == null)
            {
                // Design pattern :- Prototype pattern (Clone)
                _OldCopy = (ICustomer)this.MemberwiseClone();
            }
        }

        // Design pattern :- memento pattern ( Revert old state)
        public void Revert()
        {
            this.CustomerName = _OldCopy.CustomerName;
            this.Address = _OldCopy.Address;
            this.BillDate = _OldCopy.BillDate;
            this.BillAmount = _OldCopy.BillAmount;
            this.CustomerType = _OldCopy.CustomerType;
            this.PhoneNumber = _OldCopy.PhoneNumber;
        }


    }
    // Design pattern :- Stratergy pattern helps to choose 
    // algorithms dynamically
    public interface IValidation<AnyType>
    {
        void Validate(AnyType obj);
    }
}
