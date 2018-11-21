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
using System.Collections;

namespace CAAC_LawLibrary.UserControls
{
    public partial class LawInfo : UserControl
    {
        public Law law;
        List<Law> laws;
        public Form parentForm;
        DbHelper db = new DbHelper();
        public bool bindState = false;

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
                ccb_banben.Text = law.version;
                lbl_banwendanwei.Text = law.banwendanwei;
                lbl_buhao.Text = law.buhao;
                lbl_guanjianzi.Text = law.keyword;
                lbl_leixing.Text = Global.GetCodeValueById(law.yewu);
                lbl_linghao.Text = law.linghao;
                lbl_xiudingling.Text = law.xiudingling;
                lbl_yewufenlei.Text = Global.GetCodeValueById(law.yewu);
                lbl_guanjianzi.Text = Global.GetCodeValueById(law.userLabel);
                rtb_yilai.Text = getTitle(law.yilai);
                rtb_yilai.Tag = law.yilai;
                rtb_zefa.Text = getTitle(law.zefa);
                rtb_zefa.Tag = law.zefa;
                rtb_zhaiyao.Text = law.digest;
            }
        }

        public void fillLawVersion(List<Law> _laws)
        {
            laws = _laws;
            if (_laws != null)
            {
                foreach (Law law in _laws)
                {
                    ccb_banben.Items.Add(new DictionaryEntry { Value = law.version, Key = law.lawId });
                }
            }
            else
            {
                ccb_banben.Items.Add(new DictionaryEntry { Value=law.version,Key=law.lawId });
            }
            ccb_banben.SelectedIndex = 0;
            ccb_banben.DisplayMember = "Value";
            ccb_banben.ValueMember = "Key";
        }

        private string getTitle(string id)
        {
            List<string> list = new List<string>();
            foreach (string s in id.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                if (s.Contains("@"))//如果含@，是法规@章节，显示章节标题
                {
                    Node node = db.getNodeById(s.Substring(s.IndexOf("@")+1));
                    if (node != null)
                    {
                        if (!string.IsNullOrEmpty(node.Id))
                        {
                            list.Add(node.title);
                        }
                    }
                }
                else//如果不含@，是法规，显示法规标题
                {
                    Law law = db.getLawById(s);
                    if (law != null)
                    {
                        if (!string.IsNullOrEmpty(law.lawId))
                        {
                            list.Add(law.title);
                        }
                    }
                }
            }
            return string.Join(Environment.NewLine, list);
        }

        private void ccb_banben_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
            {
                DictionaryEntry selectedItem;
                try
                {
                    selectedItem = (DictionaryEntry)ccb_banben.SelectedItem;
                }
                catch (Exception)
                {
                    MessageBox.Show("所选版本无效");
                    return;
                }
                Law selectedLaw = db.getLawById(selectedItem.Key.ToString());
                if (selectedLaw != null)
                {
                    openLaw(selectedLaw,laws);
                }
            }
        }

        private void openLaw(Law law,List<Law> laws)
        {
            LawView lv = new CAAC_LawLibrary.LawView();
            lv.law = law;
            lv.laws = laws;
            lv.parentForm =  parentForm;
            lv.Show();
        }

        private void rtb_zefa_Click(object sender, EventArgs e)
        {
            if (rtb_zefa.Tag.ToString() != string.Empty)
            {
                string zefa = rtb_zefa.Tag.ToString();
                List<string> list = zefa.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string lawId = list[0];
                if (list.Count > 1)//如果是法规id@章节id
                {
                    string nodeId = list[1];
                }
                Law law = db.getLawById(lawId);
                List<Law> laws = new List<Law>();
                if (law != null)
                {
                    laws = db.getLaws(new QueryParam() { }).Where(l => l.lastversion == law.lastversion).OrderByDescending(l => l.version).ToList();
                }
                openLaw(law, laws);
            }
        }

        private void rtb_yilai_Click(object sender, EventArgs e)
        {
            if (rtb_yilai.Tag.ToString() != string.Empty)
            {
                string yilai = rtb_yilai.Tag.ToString();
                List<string> list = yilai.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string lawId = list[0];
                if (list.Count > 1)//如果是法规id@章节id
                {
                    string nodeId = list[1];
                }
                Law law = db.getLawById(lawId);
                List<Law> laws = new List<Law>();
                if (law != null)
                {
                    laws = db.getLaws(new QueryParam() { }).Where(l => l.lastversion == law.lastversion).OrderByDescending(l => l.version).ToList();
                }
                openLaw(law, laws);
            }
        }
    }
}
