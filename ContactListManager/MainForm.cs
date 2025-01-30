using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ContactListManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvContacts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a Contact to Edit.");
                return;
            }

            var SelectedContact = (Contact)dgvContacts.SelectedRows[0].DataBoundItem;
            ContactPopup popup = new ContactPopup();
            popup.Contact = SelectedContact;
            popup.PopulateField();

            if (popup.ShowDialog() == DialogResult.OK)
            {
                UpdateContactGrid();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveContactsToCSV();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            ContactPopup popup = new ContactPopup();
            if (popup.ShowDialog() == DialogResult.OK)
            {
                contacts.Add(popup.Contact);
                UpdateContactGrid();
            }
        }
    }
}
