using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceCustomer;
using FactoryCustomer;
using InterfaceDal;
using FactoryDal;
using Mediator;

namespace Mediator
{
    public class UICustomerMediator
    {
        private CustomerBase cust = null;
        private IRepository<CustomerBase> Idal;

        private DataGridView dtgGridCustomer = null;
        private Dictionary<string, Control> UIControls = new
                        Dictionary<string, Control>();
        public void Register(CustomerBase _cust)
        {
            cust = _cust;
        }
        public void Register(IRepository<CustomerBase> _dal)
        {
            Idal = _dal;
        }
        public void Register(TextBox txt)
        {
            UIControls.Add(txt.Name, txt);
        }
        public void Register(ComboBox cmb)
        {
            UIControls.Add(cmb.Name, cmb);
        }
        public void Register(DataGridView grid)
        {
            dtgGridCustomer = grid;
        }

        public void Load()
        {
            ComboBox comb = (ComboBox)UIControls["DalLayer"];
            comb.Items.Add("ADODal");
            comb.Items.Add("EFDal");
            comb.SelectedIndex = 0;
            Idal = FactoryDalLayer<IRepository<CustomerBase>>.Create(comb.Text);
            LoadGrid();
            ClearCustomer();
        }
        public void LoadGridInMemory()
        {
            dtgGridCustomer.DataSource = null;
            IEnumerable<CustomerBase> custs = Idal.GetData(); //inmemory
            dtgGridCustomer.DataSource = custs;

        }
        public void LoadGrid()
        {
            dtgGridCustomer.DataSource = null;
            IEnumerable<CustomerBase> custs = Idal.Search(); // physically
            dtgGridCustomer.DataSource = custs;
        }
        public void SetCustomer()
        {
            cust = FactoryCustomerLookup.Create(UIControls["cmbCustomerType"].Text);
            cust.CustomerName = UIControls["txtCustomerName"].Text;
            cust.PhoneNumber = UIControls["txtPhoneNumber"].Text;
            cust.BillDate = Convert.ToDateTime(UIControls["txtBillingDate"].Text);
            cust.BillAmount = Convert.ToDecimal(UIControls["txtBillingAmount"].Text);
            cust.Address = UIControls["txtAddress"].Text;
        }
        public void Validate()
        {
            SetCustomer();
            cust.Validate();
        }
        public void DalLayerChange()
        {
            Idal = FactoryDalLayer<IRepository<CustomerBase>>.
                        Create(UIControls["DalLayer"].Text);
            LoadGrid();
        }
        public void Uow()
        {
            IUow uow = FactoryDalLayer<IUow>.Create("EfUOW");
            try
            {
                CustomerBase cust1 = new CustomerBase();
                cust1.CustomerType = "Lead";
                cust1.CustomerName = "Cust1";

                // Unit of work

                Idal.SetUnitWork(uow);
                Idal.Add(cust1); // In memory


                cust1 = new CustomerBase();
                cust1.CustomerType = "Lead";
                cust1.CustomerName = "Cust2";
                cust1.Address = "dzxcczxcxzcxzcsdhksjahdkjsahkdjhsakjdh kjashdkjahsd kjahskjdh kajsdhasd";
                IRepository<CustomerBase> dal1 = FactoryDalLayer<IRepository<CustomerBase>>
                                     .Create(UIControls["DalLayer"].Text); // Unit
                dal1.SetUnitWork(uow);
                dal1.Add(cust1); // In memory

                uow.Committ();
            }
            catch (Exception ex)
            {
                uow.RollBack();
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void Check()
        {
            try
            {
                SetCustomer();
                cust.Validate();
                MessageBox.Show(cust.ActualCost().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void Cancel()
        {
            cust.Revert();
            ClearCustomer();
            LoadGridInMemory();
        }
        public void Save()
        {
            Idal.Save();
            ClearCustomer();
            LoadGrid();
        }
        public void Add()
        {
            SetCustomer();
            Idal.Add(cust); // In memory + validate
            LoadGridInMemory();
            ClearCustomer();
        }
        public void ClearCustomer()
        {
            UIControls["txtCustomerName"].Text = "";
            UIControls["txtPhoneNumber"].Text = "";
            UIControls["txtBillingDate"].Text = DateTime.Now.Date.ToString();
            UIControls["txtBillingAmount"].Text = "";
            UIControls["txtAddress"].Text = "";
            cust = FactoryCustomerLookup.
                        Create(
                            UIControls["cmbCustomerType"].Text);
        }
        public void RowEnter(int rowIndex)
        {
            cust = Idal.GetData(rowIndex);
            cust.Clone();
            ObjecttoUI();
        }
        public void ObjecttoUI()
        {
            UIControls["txtCustomerName"].Text = cust.CustomerName;
            UIControls["txtPhoneNumber"].Text = cust.PhoneNumber;
            UIControls["txtBillingDate"].Text = cust.BillDate.ToString();
            UIControls["txtBillingAmount"].Text = cust.BillAmount.ToString();
            UIControls["txtAddress"].Text = cust.Address;
            UIControls["cmbCustomerType"].Text = cust.CustomerType;
        }
        public void Click()
        {
            IEnumerable<CustomerBase> custs = Idal.GetData(); // physically
        }
    }
}
