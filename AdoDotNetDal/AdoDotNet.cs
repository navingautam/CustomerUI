using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDAL;
using InterfaceDal;
using System.Data;
using System.Data.SqlClient;
using InterfaceCustomer;
using FactoryCustomer;
using System.Configuration;
namespace AdoDotnetDAL
{
    public abstract class TemplateADO<AnyType> : AbstractDal<AnyType>
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;
        IUow uowobj = null;
        public override void SetUnitWork(IUow uow)
        {
            uowobj = uow;
            objConn = ((AdoUow)uow).Connection;
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
            objCommand.Transaction = ((AdoUow)uow).Transaction;
        }

        private void Open()
        {
            if (objConn == null)
            {
                objConn = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["Conn"].ConnectionString);
                objConn.Open();
                objCommand = new SqlCommand();
                objCommand.Connection = objConn;
            }

        }
        protected abstract void ExecuteCommand(AnyType obj); // Child classes 
        protected abstract List<AnyType> ExecuteCommand(); // Child classes 
        private void Close()
        {
            if (uowobj == null)
            {
                objConn.Close();
            }
        }
        // Design pattern :- Template pattern
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
    public class CustomerDAL : TemplateADO<CustomerBase>, IRepository<CustomerBase>
    {

        protected override List<CustomerBase> ExecuteCommand()
        {
            objCommand.CommandText = "select * from tblCustomer";
            SqlDataReader dr = null;
            dr = objCommand.ExecuteReader();
            List<CustomerBase> custs = new List<CustomerBase>();
            while (dr.Read())
            {
                CustomerBase icust = Factory<CustomerBase>.Create("Customer");
                icust.Id = Convert.ToInt16(dr["Id"]);
                icust.CustomerType = dr["CustomerType"].ToString();
                icust.CustomerName = dr["CustomerName"].ToString();
                icust.BillDate = Convert.ToDateTime(dr["BillDate"]);
                icust.BillAmount = Convert.ToDecimal(dr["BillAmount"]);
                icust.PhoneNumber = dr["PhoneNumber"].ToString();
                icust.Address = dr["Address"].ToString();
                custs.Add(icust);
            }
            return custs;
        }
        protected override void ExecuteCommand(CustomerBase obj)
        {
            objCommand.CommandText = "insert into tblCustomer(" +
                                            "CustomerName," +
                                            "BillAmount,BillDate," +
                                            "PhoneNumber,Address,CustomerType)" +
                                            "values('" + obj.CustomerName + "'," +
                                            obj.BillAmount + ",'" +
                                            obj.BillDate + "','" +
                                            obj.PhoneNumber + "','" +
                                            obj.Address + "','" + obj.CustomerType + "')";
            objCommand.ExecuteNonQuery();
        }
    }

    public class AdoUow : IUow
    {
        public SqlConnection Connection { get; set; }
        public SqlTransaction Transaction { get; set; }
        public AdoUow()
        {
            Connection = new SqlConnection(ConfigurationManager.
                        ConnectionStrings["Conn"].ConnectionString);
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }
        public void Committ()
        {
            Transaction.Commit();
            Connection.Close();
        }

        public void RollBack() // Design pattern :- object Adapter pattern
        {
            Transaction.Dispose();
            Connection.Close();
        }
    }

}
