using CAAC_LawLibrary.BLL;
using CAAC_LawLibrary.BLL.Entity;
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
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
    public partial class SuggestForm : Form
    {
        public string LawId { get; set; }
        DbHelper db = new DbHelper();
        List<Suggest> list = new List<Suggest>();

        public SuggestForm()
        {
            InitializeComponent();
        }

        private void SuggestForm_Load(object sender, EventArgs e)
        {
            fillLawInfo();
            fillUserInfo();
            list = db.getLocalSuggests(LawId, Global.user.Id);
            foreach (Suggest suggest in list)
            {
                SuggestItem si = new CAAC_LawLibrary.SuggestItem();
                si.ShowEntity(suggest);
                flp.Controls.Add(si);
            }
        }

        public void fillLawInfo()
        {
            lbl_title.Text = "意见征询表"+Environment.NewLine+"---------------------------------------------------------------------------------------------------------------------------------";
            Law law = db.getLawById(LawId);
            if (law != null)
            {
                lbl_title.Text += law.title + " | " + law.version + " | " + law.effectiveDate.Replace(" 00:00:00","") + " | " + law.expiryDate.Replace(" 00:00:00", "");
                if (DateTime.Parse(law.effectiveDate) > DateTime.Now)
                {
                    lbl_title.Text += " | 征询中";
                    btn_submit.Enabled = true;
                }
                else
                {
                    lbl_title.Text += " | 征询已结束";
                    btn_submit.Enabled = false;
                }
            }
        }

        private void fillUserInfo()
        {
            txt_department.Text = Global.user.Department;
            txt_user.Text = Global.user.Name;
            txt_phone.Text = Global.user.Phone;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            ConsultRequest consultRequest = new ConsultRequest();
            consultRequest.ConvertFromSuggests(list);
            string reslut= RemoteWorker.postCommit(consultRequest);
            CommonResponse response = TranslationWorker.ConvertStringToEntity<CommonResponse>(reslut);
            if (response != null)
            {
                if (response.status.ToString() == "200")
                {
                    if (MessageBox.Show("提交征询意见成功") == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("提交征询意见失败。原因："+response.errmsg);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
