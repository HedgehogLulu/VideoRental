using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Admin : Form
    {
        private AdminPanel adminPanel;
        public Admin(AdminPanel admin)
        {
            InitializeComponent();
            this.adminPanel = admin;
            this.FormClosing += Admin_FormClosing;
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            adminPanel.Show();
        }
    }
}
