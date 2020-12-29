using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDal;
using InterfaceDal;
using System.Data;
using System.Data.SqlClient;
using InterfaceCustomer;
using FactoryCustomer;

namespace AdoDotNetDal
{
    public abstract class TemplateADO<AnyType> : AbstractDal<AnyType>
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;
        public TemplateADO(string connectionString) : base(connectionString)
        {

        }
        private void Open()
        {
            objConn = new SqlConnection(_connectionString);
            objConn.Open();
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
        }
        protected abstract void ExecuteCommand(AnyType obj); // Child classes
        protected abstract List<AnyType> ExecuteCommand(); // Child classes
       
        private void Close()
        {
            objConn.Close();
        }
        // Design Pattern: Template pattern
        public void Execute(AnyType obj) // Fixed Sequence Insert
        {
            Open();
            ExecuteCommand(obj);
            Close();
        }

        public List<AnyType> Execute() // Fixed Sequence select
        {
            List<AnyType> objTypes = null;
            Open();
            objTypes = ExecuteCommand();
            Close();
            return objTypes;
        }

        public override void Save()
        {
            foreach (AnyType o in AnyTypes)
            {
                Execute(o);
            }
        }
        public override List<AnyType> Search()
        {
            return Execute();
        }
    }

    public class CustomerDAL : TemplateADO<ICustomer>, IDal<ICustomer>
    {
        public CustomerDAL(string connectionString)
            : base(connectionString)
        {

        }
        protected override List<ICustomer> ExecuteCommand()
        {
            objCommand.CommandText = "SELECT * FROM tblCustomer";
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            List<ICustomer> custs = new List<ICustomer>();
            while (dr.Read())
            {
                ICustomer iCust = FactoryCustomer<ICustomer>.Create("Customer");
                iCust.CustomerName = dr["CustomerName"].ToString();
                iCust.BillDate = Convert.ToDateTime(dr["BillDate"]);
                iCust.BillAmount = Convert.ToDecimal(dr["BillAmount"]);
                iCust.PhoneNumber = dr["PhoneNumber"].ToString();
                iCust.Address = dr["Address"].ToString();
                custs.Add(iCust);
            }
            return custs;
        }
        protected override void ExecuteCommand(ICustomer obj)
        {
            objCommand.CommandText = "INSERT INTO tblCustomer(" +
                "CustomerName, BillAmount, BillDate, PhoneNumber, Address) " +
                "VALUES('" + obj.CustomerName + "', '" +
                obj.BillAmount + "', '" +
                obj.BillDate + "', '" +
                obj.PhoneNumber + "', '" +
                obj.Address + "')";
            objCommand.ExecuteNonQuery();
        }
    }
}
