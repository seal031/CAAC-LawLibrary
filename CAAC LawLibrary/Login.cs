using CAAC_LawLibrary.Utity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Global.user = new Entity.User() { Id = "02954944-57ab-4571-9b1e-0062ef04fef2" };
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            LibraryList listForm = new LibraryList();
            listForm.Show();
            this.Hide();
        }
    }
}
