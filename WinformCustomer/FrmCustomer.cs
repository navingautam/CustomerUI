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

namespace WinformCustomer
{
    public partial class FrmCustomer : Form
    {
        // Design pattern :- Mediator Pattern
        private UICustomerMediator customerMediator = new UICustomerMediator();
        private CustomerBase cust = null;
        private IRepository<CustomerBase> Idal;
        public FrmCustomer()
        {
            InitializeComponent();
            customerMediator.Register(cust);
            customerMediator.Register(Idal);
            customerMediator.Register(dtgGridCustomer);
            foreach (TextBox t in this.Controls.OfType<TextBox>())
            {
                customerMediator.Register(t);
            }
            foreach (ComboBox t in this.Controls.OfType<ComboBox>())
            {
                customerMediator.Register(t);
            }

        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            customerMediator.Load();
        }
        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                customerMediator.Validate();
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
                customerMediator.Add();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DalLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerMediator.DalLayerChange();

        }

        private void btnUOW_Click(object sender, EventArgs e)
        {
            customerMediator.Uow();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            customerMediator.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customerMediator.Click();
        }

        private void dtgGridCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            customerMediator.RowEnter(e.RowIndex);
        }
        private void LoadCustomeronUI()
        {
            customerMediator.ObjecttoUI();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            customerMediator.Cancel();

        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            customerMediator.Check();
        }

        private void cmbCustomerType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            customerMediator.ClearCustomer();
        }


    }

}
