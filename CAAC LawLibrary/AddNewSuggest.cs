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
            Suggest suggest = new Entity.Suggest();
            suggest.Id = Guid.NewGuid().ToString();
            suggest.isLocal = "1";
            suggest.lawId = lawId;
            suggest.nodeId = nodeId;
            suggest.remark = rtb_remark.Text.Trim();
            suggest.suggest_content = rtb_suggest.Text.Trim();
            suggest.suggest_date = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            suggest.userId = Global.user.Id;
            if (Global.online)//联网状态下直接提交，提交失败时保存在本地数据库
            {
                saveSuggestLocal(suggest);//todo 待确认
            }
            else//断网状态下直接保存在本地数据库
            {
                saveSuggestLocal(suggest);
            }
        }

        private void saveSuggestLocal(Suggest suggest)
        {
            db.saveSuggest(suggest);
        }
    }
}
