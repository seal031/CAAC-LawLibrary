using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;
using CAAC_LawLibrary.DAL;

namespace CAAC_LawLibrary.UserControls
{
    public partial class LawInfo : UserControl
    {
        public Law law;
        DbHelper db = new DbHelper();

        public LawInfo()
        {
            InitializeComponent();
        }

        private void LawInfo_Load(object sender, EventArgs e)
        {
            
        }

        public void fillLawInfo()
        {
            if (law != null)
            {
                lbl_name.Text = law.name;
                lbl_guanlijigou.Text = Global.GetCodeValueById(law.siju);
                lbl_banben.Text = law.version;
                lbl_banwendanwei.Text = law.banwendanwei;
                lbl_buhao.Text = law.buhao;
                lbl_guanjianzi.Text = law.keyword;
                lbl_leixing.Text = Global.GetCodeValueById(law.yewu);
                lbl_linghao.Text = law.linghao;
                lbl_xiudingling.Text = law.xiudingling;
                lbl_yewufenlei.Text = Global.GetCodeValueById(law.yewu);
                lbl_guanjianzi.Text = Global.GetCodeValueById(law.userLabel);
                rtb_yilai.Text = getTitle(law.yilai);
                rtb_zefa.Text = getTitle(law.zefa);
                rtb_zhaiyao.Text = law.digest;
            }
        }

        private string getTitle(string id)
        {
            List<string> list = new List<string>();
            foreach (string s in id.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (s.Contains("@"))//如果含@，是法规@章节，显示章节标题
                {
                    Node node = db.getNodeById(s.Substring(s.IndexOf("@")));
                    if (!string.IsNullOrEmpty(node.Id))
                    {
                        list.Add(node.title);
                    }
                }
                else//如果不含@，是法规，显示法规标题
                {
                    Law law = db.getLawById(s);
                    if (!string.IsNullOrEmpty(law.Id))
                    {
                        list.Add(law.title);
                    }
                }
            }
            return string.Join(Environment.NewLine, list);
        }
    }
}
