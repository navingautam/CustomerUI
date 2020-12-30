namespace WinformCustomer
{
    partial class FrmCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.cmbCustomerType = new System.Windows.Forms.ComboBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblBillAmount = new System.Windows.Forms.Label();
            this.txtBillAmount = new System.Windows.Forms.TextBox();
            this.lblBillDate = new System.Windows.Forms.Label();
            this.txtBillDate = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnValidate = new System.Windows.Forms.Button();
            this.dtgGridCustomer = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbDalLayer = new System.Windows.Forms.ComboBox();
            this.lblDal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGridCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Location = new System.Drawing.Point(28, 26);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(104, 17);
            this.lblCustomerType.TabIndex = 0;
            this.lblCustomerType.Text = "Customer Type";
            // 
            // cmbCustomerType
            // 
            this.cmbCustomerType.FormattingEnabled = true;
            this.cmbCustomerType.Items.AddRange(new object[] {
            "Customer",
            "Lead"});
            this.cmbCustomerType.Location = new System.Drawing.Point(147, 26);
            this.cmbCustomerType.Name = "cmbCustomerType";
            this.cmbCustomerType.Size = new System.Drawing.Size(187, 24);
            this.cmbCustomerType.TabIndex = 1;
            this.cmbCustomerType.SelectedIndexChanged += new System.EventHandler(this.cmbCustomerType_SelectedIndexChanged);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(28, 81);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(105, 17);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "CustomerName";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(147, 81);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(292, 22);
            this.txtCustomerName.TabIndex = 3;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(28, 145);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(103, 17);
            this.lblPhoneNumber.TabIndex = 4;
            this.lblPhoneNumber.Text = "Phone Number";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(147, 145);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(226, 22);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // lblBillAmount
            // 
            this.lblBillAmount.AutoSize = true;
            this.lblBillAmount.Location = new System.Drawing.Point(534, 26);
            this.lblBillAmount.Name = "lblBillAmount";
            this.lblBillAmount.Size = new System.Drawing.Size(78, 17);
            this.lblBillAmount.TabIndex = 6;
            this.lblBillAmount.Text = "Bill Amount";
            // 
            // txtBillAmount
            // 
            this.txtBillAmount.Location = new System.Drawing.Point(618, 28);
            this.txtBillAmount.Name = "txtBillAmount";
            this.txtBillAmount.Size = new System.Drawing.Size(192, 22);
            this.txtBillAmount.TabIndex = 7;
            this.txtBillAmount.Text = "0";
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.Location = new System.Drawing.Point(534, 81);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(60, 17);
            this.lblBillDate.TabIndex = 8;
            this.lblBillDate.Text = "Bill Date";
            // 
            // txtBillDate
            // 
            this.txtBillDate.Location = new System.Drawing.Point(618, 81);
            this.txtBillDate.Name = "txtBillDate";
            this.txtBillDate.Size = new System.Drawing.Size(212, 22);
            this.txtBillDate.TabIndex = 9;
            this.txtBillDate.Text = "1/1/2020";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(534, 145);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(60, 17);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(618, 145);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(424, 130);
            this.txtAddress.TabIndex = 11;
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(31, 230);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(158, 45);
            this.btnValidate.TabIndex = 12;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // dtgGridCustomer
            // 
            this.dtgGridCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgGridCustomer.Location = new System.Drawing.Point(12, 313);
            this.dtgGridCustomer.Name = "dtgGridCustomer";
            this.dtgGridCustomer.RowTemplate.Height = 24;
            this.dtgGridCustomer.Size = new System.Drawing.Size(1370, 368);
            this.dtgGridCustomer.TabIndex = 13;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(217, 230);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(130, 45);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbDalLayer
            // 
            this.cmbDalLayer.FormattingEnabled = true;
            this.cmbDalLayer.Location = new System.Drawing.Point(921, 28);
            this.cmbDalLayer.Name = "cmbDalLayer";
            this.cmbDalLayer.Size = new System.Drawing.Size(121, 24);
            this.cmbDalLayer.TabIndex = 15;
            this.cmbDalLayer.SelectedIndexChanged += new System.EventHandler(this.cmbDalLayer_SelectedIndexChanged);
            // 
            // lblDal
            // 
            this.lblDal.AutoSize = true;
            this.lblDal.Location = new System.Drawing.Point(880, 31);
            this.lblDal.Name = "lblDal";
            this.lblDal.Size = new System.Drawing.Size(35, 17);
            this.lblDal.TabIndex = 16;
            this.lblDal.Text = "DAL";
            // 
            // FrmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 693);
            this.Controls.Add(this.lblDal);
            this.Controls.Add(this.cmbDalLayer);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dtgGridCustomer);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtBillDate);
            this.Controls.Add(this.lblBillDate);
            this.Controls.Add(this.txtBillAmount);
            this.Controls.Add(this.lblBillAmount);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.cmbCustomerType);
            this.Controls.Add(this.lblCustomerType);
            this.Name = "FrmCustomer";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGridCustomer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.ComboBox cmbCustomerType;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblBillAmount;
        private System.Windows.Forms.TextBox txtBillAmount;
        private System.Windows.Forms.Label lblBillDate;
        private System.Windows.Forms.TextBox txtBillDate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.DataGridView dtgGridCustomer;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbDalLayer;
        private System.Windows.Forms.Label lblDal;
    }
}

