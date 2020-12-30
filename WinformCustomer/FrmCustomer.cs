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

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            DalLayer.Items.Add("ADODal");
            DalLayer.Items.Add("EFDal");
            DalLayer.SelectedIndex = 0;
            LoadGrid();
        }
        private void LoadGrid()
        {
            IRepository<CustomerBase> Idal = FactoryDalLayer<IRepository<CustomerBase>>.Create(DalLayer.Text);
            List<CustomerBase> custs = Idal.Search();
            dtgGridCustomer.DataSource = custs;

        }
        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cust = Factory<CustomerBase>.Create(cmbCustomerType.Text);
            LoadGrid();
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
            SetCustomer();
            IRepository<CustomerBase> dal = FactoryDalLayer<IRepository<CustomerBase>>
                                 .Create(DalLayer.Text);
            dal.Add(cust); // In memory
            dal.Save(); // Physical committ
            ClearCustomer();
            LoadGrid();
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
            LoadGrid();
        }

        private void btnUOW_Click(object sender, EventArgs e)
        {
            string uowType = null;
            if (DalLayer.Text == "ADODal")
                uowType = "AdoUOW";
            else
                uowType = "EfUOW";

            IUow uow = FactoryDalLayer<IUow>.Create(uowType);
            try
            {
                CustomerBase cust1 = new CustomerBase();
                cust1.CustomerType = "Lead";
                cust1.CustomerName = "Cust1";

                // Unit of work
                IRepository<CustomerBase> dal = FactoryDalLayer<IRepository<CustomerBase>>
                                     .Create(DalLayer.Text); // Unit
                dal.SetUnitWork(uow);
                dal.Add(cust1); // In memory


                cust1 = new CustomerBase();
                cust1.CustomerType = "Lead";
                cust1.CustomerName = "Cust2";
                cust1.Address = "aaa aSDAs sS Ss SAsAS asdadas da dasdadasd adsadadadadadas dadsadasdasda  d adasdasd dad ada ssdasdadassda dad aad a dad ";
                IRepository<CustomerBase> dal1 = FactoryDalLayer<IRepository<CustomerBase>>
                                     .Create(DalLayer.Text); // Unit
                dal1.SetUnitWork(uow);
                dal1.Add(cust1); // In memory

                uow.Committ();
                LoadGrid();
            }
            catch (Exception ex)
            {
                uow.RollBack();
                MessageBox.Show(ex.Message.ToString());
                LoadGrid();
            }
        }


    }
}
