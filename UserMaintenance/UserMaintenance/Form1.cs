using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();
            lblLastName.Text = Resource1.FullName; 
            
            btnAdd.Text = Resource1.Add;
            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = txtLastName.Text,
                
            };
            users.Add(u);
        }

        private void btnwrite_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName, true, Encoding.UTF8))
                {
                    foreach (var s in users)
                    {
                        sw.Write(s.ID);
                        sw.Write(";");
                        sw.Write(s.FullName);
                        sw.WriteLine();
  
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int v = Convert.ToInt32(listUsers.SelectedIndex);
            users.RemoveAt(v);
        }
    }
    
}
