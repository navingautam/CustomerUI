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
namespace WinformCustomer
{
    public partial class FrmCustomer : Form
    {
        private CustomerBase cust = null;
        private IRepository<CustomerBase> Idal;
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            DalLayer.Items.Add("ADODal");
            DalLayer.Items.Add("EFDal");
            DalLayer.SelectedIndex = 0;
            Idal = FactoryDalLayer<IRepository<CustomerBase>>.Create(DalLayer.Text);
            LoadGrid();
        }
        private void LoadGridInMemory()
        {
            dtgGridCustomer.DataSource = null;

            IEnumerable<CustomerBase> custs = Idal.GetData(); //inmemory

            dtgGridCustomer.DataSource = custs;

        }
        private void LoadGrid()
        {

            dtgGridCustomer.DataSource = null;
            IEnumerable<CustomerBase> custs = Idal.Search(); // physically

            dtgGridCustomer.DataSource = custs;

        }
        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cust = Factory<CustomerBase>.Create(cmbCustomerType.Text);
        }
        private void SetCustomer()
        {

            cust.CustomerName = txtCustomerName.Text;
            cust.PhoneNumber = txtPhoneNumber.Text;
            cust.BillDate = Convert.ToDateTime(txtBillingDate.Text);
            cust.BillAmount = Convert.ToDecimal(txtBillingAmount.Text);
            cust.Address = txtAddress.Text;
        }
        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                SetCustomer();
                cust.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SetCustomer();

                Idal.Add(cust); // In memory + validate

                LoadGridInMemory();
                ClearCustomer();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void ClearCustomer()
        {
            txtCustomerName.Text = "";
            txtPhoneNumber.Text = "";
            txtBillingDate.Text = DateTime.Now.Date.ToString();
            txtBillingAmount.Text = "";
            txtAddress.Text = "";
        }
        private void DalLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Idal = FactoryDalLayer<IRepository<CustomerBase>>.Create(DalLayer.Text);
            LoadGrid();
        }

        private void btnUOW_Click(object sender, EventArgs e)
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
                                     .Create(DalLayer.Text); // Unit
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            Idal.Save();
            ClearCustomer();
            LoadGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IEnumerable<CustomerBase> custs = Idal.GetData(); // physically

        }


    }
}
