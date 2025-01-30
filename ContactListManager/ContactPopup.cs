using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ContactListManager
{
    public partial class ContactPopup : Form
    {
        public ContactPopup()
        {
            InitializeComponent();
            if (Contact == null)
            {
                Contact = new Contact();
            }
        }

        public void PopulateField()
        {

            this.txtName.Text = Contact.Name;
            this.txtEmail.Text = Contact.Email;
            this.txtPhoneNumber.Text = Contact.PhoneNumber;
        }

        internal Contact Contact { get; set; }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Contact.Name = txtName.Text;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close(); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            Contact.Email = txtEmail.Text;
        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            Contact.PhoneNumber = txtPhoneNumber.Text;
        }

        private void ContactPopup_Load(object sender, EventArgs e)
        {

        }
    }
}
 

