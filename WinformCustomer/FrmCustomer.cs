using FactoryCustomer;
using FactoryDal;
using InterfaceCustomer;
using InterfaceDal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformCustomer
{
    public partial class FrmCustomer : Form
    {
        private ICustomer cust = null;
        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cust = FactoryCustomer<ICustomer>.Create(cmbCustomerType.Text);
        }

        private void SetCustomer()
        {
            cust.CustomerName = txtCustomerName.Text;
            cust.PhoneNumber = txtPhoneNumber.Text;
            cust.BillDate = Convert.ToDateTime(txtBillDate.Text);
            cust.BillAmount = Convert.ToDecimal(txtBillAmount.Text);
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

                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetCustomer();
            IDal<ICustomer> dal = FactoryDal<IDal<ICustomer>>.Create("ADODal");
            dal.Add(cust); // In memory
            dal.Save(); // Physical commit
        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            cmbDalLayer.Items.Add("ADODal");
            cmbDalLayer.Items.Add("EFDal");
            LoadGrid();
        }
        private void LoadGrid()
        {
            IDal<ICustomer> dal = FactoryDal<IDal<ICustomer>>.Create("ADODal");
            List<ICustomer> custs = dal.Search();
            dtgGridCustomer.DataSource = custs;
        }
    }
}
