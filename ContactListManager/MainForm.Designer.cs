
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ContactListManager
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private List<Contact> contacts = new List<Contact>();
        /// <summary>
        ///  Clean up any resources being used.
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
        

        private void LoadContactsFromCSV()
        {
            if (!File.Exists("contact.csv"))
            {
                File.WriteAllText("contacts.csv", "Name,Email,PhoneNumber");
            }

            string[] lines = File.ReadAllLines("contacts.csv");
            foreach (string line in lines.Skip(1))
            {
                var parts = line.Split(',');
                contacts.Add(new Contact
                {
                    Name = parts[0],
                    Email = parts[1],
                    PhoneNumber = parts[2]
                });
            }

            UpdateContactGrid();
        }

        private void UpdateContactGrid()
        {
            dgvContacts.DataSource = null;
            dgvContacts.DataSource = contacts;
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvContacts = new System.Windows.Forms.DataGridView();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnEditContact = new System.Windows.Forms.Button();
            this.btnSaveToCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContacts
            // 
            this.dgvContacts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContacts.Location = new System.Drawing.Point(0, 0);
            this.dgvContacts.Name = "dgvContacts";
            this.dgvContacts.RowTemplate.Height = 25;
            this.dgvContacts.Size = new System.Drawing.Size(340, 158);
            this.dgvContacts.TabIndex = 0;
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(10, 186);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(97, 23);
            this.btnAddContact.TabIndex = 1;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // btnEditContact
            // 
            this.btnEditContact.Location = new System.Drawing.Point(129, 186);
            this.btnEditContact.Name = "btnEditContact";
            this.btnEditContact.Size = new System.Drawing.Size(93, 23);
            this.btnEditContact.TabIndex = 2;
            this.btnEditContact.Text = "Edit Contact";
            this.btnEditContact.UseVisualStyleBackColor = true;
            this.btnEditContact.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSaveToCSV
            // 
            this.btnSaveToCSV.Location = new System.Drawing.Point(251, 186);
            this.btnSaveToCSV.Name = "btnSaveToCSV";
            this.btnSaveToCSV.Size = new System.Drawing.Size(89, 23);
            this.btnSaveToCSV.TabIndex = 3;
            this.btnSaveToCSV.Text = "Save to CSV";
            this.btnSaveToCSV.UseVisualStyleBackColor = true;
            this.btnSaveToCSV.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveToCSV);
            this.Controls.Add(this.btnEditContact);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.dgvContacts);
            this.Name = "MainForm";
            this.Text = "Contact List Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContacts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private void SaveContactsToCSV()
        {
            var lines = new List<string> { "Name,Email,PhoneNumber" };
            foreach (var contact in contacts)
            {
                lines.Add($"{contact.Name},{contact.Email},{contact.PhoneNumber}");
            }
            File.WriteAllLines("contacts.csv", lines);
            MessageBox.Show("Contacts saved successfully!");
        }

        private System.Windows.Forms.DataGridView dgvContacts;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnEditContact;
        private System.Windows.Forms.Button btnSaveToCSV;


    }
}

