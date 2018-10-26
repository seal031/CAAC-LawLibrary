using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;

namespace CAAC_LawLibrary.UserControls
{
    public partial class RefPanel : UserControl
    {
        DbHelper db;
        LawView form;
        LinkLabel[,] lls = new LinkLabel[2,5];

        public RefPanel()
        {
            InitializeComponent();
            lls[0, 0] = ll_yilai;
            lls[0, 1] = ll_zefa;
        }

        public void setDb(DbHelper _db)
        {
            db = _db;
        }
        public void setParentForm(LawView _form)
        {
            form = _form;
        }

        private void clearText()
        {
            ll_yilai.Text = "";
            ll_zefa.Text = "";
        }

        public void setText(string nodeRef)
        {
            clearText();
            List<string> typeList=nodeRef.Split(new char[] { '|' },StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < typeList.Count; i++)
            {
                string typeS = typeList[i];
                List<string> list = typeS.Split(new char[] { ';' }).ToList();
                for (int j = 0; j < list.Count; j++)
                {
                    string s = list[j];
                    if (s.Contains("@"))//法规@章节
                    {
                        List<string> sList = s.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        string lawId = sList[0];
                        string nodeId = sList[1];
                        Law law = db.getLawById(lawId);
                        Node node = db.getNodeById(nodeId);
                        if (law != null) lls[i,j].Text += law.title;
                        if (node != null) lls[i,j].Text += node.title;
                        lls[i, j].Tag = law;
                    }
                    else//只有法规
                    {
                        string lawId = s;
                        Law law = db.getLawById(lawId);
                        if (law != null) lls[i,j].Text += law.title;
                        lls[i, j].Tag = law;
                    }
                }
            }
        }

        private void openNewLawView(LinkLabel ll)
        {
            LawView lv = new LawView();
            lv.law = ll.Tag as Law;
            lv.lawId = (ll.Tag as Law).Id;
            lv.parentForm = form.parentForm;
            lv.Show();
        }

        private void ll_yilai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openNewLawView(sender as LinkLabel);
        }

        private void ll_zefa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openNewLawView(sender as LinkLabel);
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
