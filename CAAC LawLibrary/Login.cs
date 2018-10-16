using CAAC_LawLibrary.BLL;
using CAAC_LawLibrary.BLL.Entity;
using CAAC_LawLibrary.DAL;
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
        DbHelper db = new DbHelper();

        public Login()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (cbb_user.Text.Trim() == string.Empty || txt_password.Text.Trim() == string.Empty)
            {
                MessageBox.Show("用户名密码不能为空");
                return;
            }
            if (login(cbb_user.Text.Trim(), txt_password.Text.Trim()))
            {
                Global.user.Name = cbb_user.Text.Trim();
                Global.user.Password = txt_password.Text.Trim();
                if (Global.online)//如果登陆成功且联网状态，获取用户信息、远程法规列表、设置列表
                {
                    RemoteWorker.getUserInfo();
                    RemoteWorker.getSetResponse();
                    RemoteWorker.getLawResponse();
                }
                if (cb_remindPwd.Checked)
                {
                    string userId = cbb_user.Text.Trim();
                    string password = txt_password.Text.Trim();
                    ConfigWorker.SetConfigValue(userId, password);
                }
                db.saveUser(Global.user);
                LibraryList listForm = new LibraryList();
                listForm.Show();
                this.Hide();
            }
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

        public bool login(string username, string password)
        {
            return RemoteWorker.getloginResponse(username, password);
        }
    }
}
