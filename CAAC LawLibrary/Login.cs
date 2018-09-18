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
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (cb_remindPwd.Checked)
            {
                string userId = cbb_user.Text.Trim();
                string password = txt_password.Text.Trim();
                ConfigWorker.SetConfigValue(userId, password);
            }
            LibraryList listForm = new LibraryList();
            listForm.Show();
            this.Hide();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void cbb_user_Leave(object sender, EventArgs e)
        {
                string userId = cbb_user.Text.Trim();
                string password = ConfigWorker.GetConfigValue(userId);
                txt_password.Text = password;
            if (string.IsNullOrEmpty(password))
            {
                cb_remindPwd.Checked = false;
            }
            else
            {
                cb_remindPwd.Checked = true;
            }
        }
    }
}
