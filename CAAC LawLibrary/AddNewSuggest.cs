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
    public partial class AddNewSuggest : Form
    {
        public string lawId;
        public string nodeId;
        private DbHelper db=new DbHelper();
        Suggest suggest;

        public AddNewSuggest()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (suggest == null)
            {
                suggest = new Entity.Suggest();
                suggest.Id = Guid.NewGuid().ToString();
                suggest.isLocal = "1";
                suggest.lawId = lawId;
                suggest.nodeId = nodeId;
                suggest.suggest_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                suggest.userId = Global.user.Id;
            }
            suggest.remark = rtb_remark.Text.Trim();
            suggest.suggest_content = rtb_suggest.Text.Trim();
            bool commitResult;
            if (Global.online)//联网状态下直接提交，提交失败时保存在本地数据库
            {
                commitResult=saveSuggestLocal(suggest);//todo 待确认
            }
            else//断网状态下直接保存在本地数据库
            {
                commitResult=saveSuggestLocal(suggest);
            }
            if (commitResult)
            {
                MessageBox.Show("提交成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("提交失败");
            }
        }

        private bool saveSuggestLocal(Suggest suggest)
        {
            return db.saveSuggest(suggest);
        }

        private void AddNewSuggest_Load(object sender, EventArgs e)
        {
            suggest = db.getLocalSuggest(lawId, nodeId);
            if (suggest != null)
            {
                rtb_suggest.Text = suggest.suggest_content;
                rtb_remark.Text = suggest.remark;
            }
        }
    }
}
