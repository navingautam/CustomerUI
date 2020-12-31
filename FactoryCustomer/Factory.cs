using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MiddleLayer;
using InterfaceCustomer;
using ValidationAlgorithms;
using InterfaceDal;
using ExtraCharge;
using Discount;
using Unity;

namespace FactoryCustomer
{
    public static class FactoryCustomerLookup // Design pattern :- Simple factory pattern / factory pattern
    {
        private static IUnityContainer ObjectsofOurProjects = null;


        public static CustomerBase Create(string Type)
        {
            // Design pattern :- Lazy loading. Eager loading
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();

                ObjectsofOurProjects.RegisterType<FactoryCustomerBase, FactoryLead>("Lead");
                ObjectsofOurProjects.RegisterType<FactoryCustomerBase, FactorySelfService>("SelfService");
                ObjectsofOurProjects.RegisterType<FactoryCustomerBase, FactoryHomeDelivery>("HomeDelivery");
                ObjectsofOurProjects.RegisterType<FactoryCustomerBase, FactoryCustomer>("Customer");

            }
            //Design pattern :-  RIP Replace If with Poly
            FactoryCustomerBase factorybase = ObjectsofOurProjects.Resolve<FactoryCustomerBase>(Type);
            return factorybase.CreateCustomer();
        }

    }

    // Customer object = Validation + Discount + Extra
    //Design pattern :- Factory Method The Factory Method defines an interface for creating objects, 
    //but lets subclasses decide which classes to instantiate.
    public class FactoryCustomerBase
    {
        protected string _CustomerType = "";

        public virtual IValidation<ICustomer> CreateValidation()
        {
            return new CustomerBasicValidation();
        }
        public virtual IDiscount CreateDiscount()
        {
            return new DiscountBillAmount();
        }
        public virtual IExtraCharge CreateExtra()
        {
            return new ExtrachargeSatSun();
        }
        public CustomerBase CreateCustomer()
        {
            return new Customer(CreateValidation(),
                                CreateDiscount(),
                                CreateExtra(), _CustomerType);
        }
    }

    public class FactoryLead : FactoryCustomerBase
    {
        public FactoryLead()
        {
            _CustomerType = "Lead";
        }
        public override IDiscount CreateDiscount()
        {
            return new DiscountNull();
        }
        public override IExtraCharge CreateExtra()
        {
            return new ExtraChargeNull();
        }
        public override IValidation<ICustomer> CreateValidation()
        {
            return new CustomeBillAmountZeroValidation(
                new PhoneValidation(
                    new CustomerBasicValidation()));
        }
    }

    public class FactorySelfService : FactoryCustomerBase
    {
        public FactorySelfService()
        {
            _CustomerType = "SelfService";
        }
        public override IExtraCharge CreateExtra()
        {
            return null;
        }
    }

    public class FactoryHomeDelivery : FactoryCustomerBase
    {
        public FactoryHomeDelivery()
        {
            _CustomerType = "HomeDelivery";
        }
        public override IValidation<ICustomer> CreateValidation()
        {
            return new CustomerAddressValidation(
               new CustomerBasicValidation());
        }
    }

    public class FactoryCustomer : FactoryCustomerBase
    {
        public FactoryCustomer()
        {
            _CustomerType = "Customer";
        }
        public override IValidation<ICustomer> CreateValidation()
        {
            return new PhoneValidation(
                   new CustomerBillValidation(
                   new CustomerAddressValidation(
                   new CustomerBasicValidation())));
        }
    }

}
