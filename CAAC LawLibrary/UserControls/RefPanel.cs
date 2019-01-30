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
using CAAC_LawLibrary.BLL;
using System.Diagnostics;
using CAAC_LawLibrary.Utity;

namespace CAAC_LawLibrary.UserControls
{
    public partial class RefPanel : UserControl
    {
        const int lblWidth = 280;
        const int lblHeight = 20;
        const int linklblHeight = 40;
        List<Label> labels = new List<Label>();

        DbHelper db;
        LawView form;

        public RefPanel()
        {
            InitializeComponent();
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
            foreach (Label l in labels)
            {
                this.panel_main.Controls.Remove(l);
            }
            this.Height = 85;
        }

        //public void setText(string nodeRef)
        //{
        //    clearText();
        //    List<string> typeList=nodeRef.Split(new char[] { '|' },StringSplitOptions.RemoveEmptyEntries).ToList();
        //    for (int i = 0; i < typeList.Count; i++)
        //    {
        //        string typeS = typeList[i];
        //        List<string> list = typeS.Split(new char[] { ';' }).ToList();
        //        for (int j = 0; j < list.Count; j++)
        //        {
        //            string s = list[j];
        //            if (s.Contains("@"))//法规@章节
        //            {
        //                List<string> sList = s.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries).ToList();
        //                string lawId = sList[0];
        //                string nodeId = sList[1];
        //                Law law = db.getLawById(lawId);
        //                Node node = db.getNodeById(nodeId);
        //                if (law != null) lls[i,j].Text += law.title;
        //                if (node != null) lls[i,j].Text += node.title;
        //                lls[i, j].Tag = law;
        //            }
        //            else//只有法规
        //            {
        //                string lawId = s;
        //                Law law = db.getLawById(lawId);
        //                if (law != null) lls[i,j].Text += law.title;
        //                lls[i, j].Tag = law;
        //            }
        //        }
        //    }
        //}

        private void openNewLawView(LinkLabel ll)
        {
            LawView lv = new LawView();
            lv.law = ll.Tag as Law;
            lv.lawId = (ll.Tag as Law).lawId;
            lv.parentForm = form.parentForm;
            lv.Show();
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void setSelectedText(string text)
        {
            label2.Text = "选中文字：" + text;
        }

        public void buildLabels(string refStr)
        {
            clearText();
            NodeContentTag nct = new NodeContentTag();
            nct = nct.strToNodeContentTag(refStr);
            int locationX = 4, locationY = 60, index = 0;
            foreach (NodeContentTag.InnerRef inRef in nct.innerRefList)
            {
                this.Height += lblHeight + linklblHeight;
                Label lblTitle;
                LinkLabel lblContent = buildInnerLabel(inRef, out lblTitle);
                lblTitle.Location = new Point(locationX, locationY + index * (lblHeight + linklblHeight));
                lblContent.Location = new Point(locationX,locationY+index*(lblHeight + linklblHeight)+lblHeight);
                //lblContent.BackColor = Color.Yellow;
                //lblTitle.BackColor = Color.Green;
                lblContent.AutoSize = false;
                lblContent.Width = lblWidth;
                lblContent.Height = linklblHeight;
                lblContent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lblTitle.AutoSize = false;
                lblTitle.Height = lblHeight;
                lblTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.panel_main.Controls.Add(lblTitle);
                this.panel_main.Controls.Add(lblContent);
                index++;
            }
            foreach (NodeContentTag.OutterRef outRef in nct.outterRefList)
            {
                this.Height += lblHeight + linklblHeight;
                Label lblTitle;
                LinkLabel lblContent = buildOutterLabel(outRef, out lblTitle);
                this.panel_main.Controls.Add(lblTitle);
                this.panel_main.Controls.Add(lblContent);
                lblTitle.Location = new Point(locationX, locationY + index * (lblHeight + linklblHeight));
                lblContent.Location = new Point(locationX, locationY + index * (lblHeight + linklblHeight) + lblHeight);
                //lblContent.BackColor = Color.Yellow;
                //lblTitle.BackColor = Color.Green;
                lblContent.AutoSize = false;
                lblContent.Width = lblWidth;
                lblContent.Height = linklblHeight;
                lblContent.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                lblTitle.AutoSize = false;
                lblTitle.Height = lblHeight;
                lblTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                this.panel_main.Controls.Add(lblTitle);
                this.panel_main.Controls.Add(lblContent);
                index++;
            }
        }

        private LinkLabel buildOutterLabel(NodeContentTag.OutterRef outRef, out Label lblTitle)
        {
            LinkLabel lbl = new LinkLabel();
            lblTitle = new Label();
            switch (outRef.refType)
            {
                case "refRELATED":
                    lblTitle.Text = "依赖：";
                    break;
                case "refPUNISH":
                    lblTitle.Text = "罚则：";
                    break;
                case "refCHUFA":
                    lblTitle.Text = "行政处罚：";
                    break;
                case "refCHUFEN":
                    lblTitle.Text = "行政处分：";
                    break;
                case "refXINGZHENG":
                    lblTitle.Text = "行政手段：";
                    break;
                case "refZEREN":
                    lblTitle.Text = "其他法律责任：";
                    break;
                case "refXINGYONG":
                    lblTitle.Text = "信用手段：";
                    break;
                case "refXUKE":
                    lblTitle.Text = "许可手段：";
                    break;
                case "refQIANGZHI":
                    lblTitle.Text = "行政强制：";
                    break;
                default:
                    break;
            }
            lbl.Text =Base64.DecodeBase64(Encoding.Unicode,outRef.title);
            lbl.Tag = Base64.DecodeBase64(outRef.url);
            lbl.Click += OutterLbl_Click;
            return lbl;
        }

        private void OutterLbl_Click(object sender, EventArgs e)
        {
            string url = (sender as LinkLabel).Tag.ToString();
            if (string.IsNullOrEmpty(url)) return;
            Process.Start(url);
        }

        private LinkLabel buildInnerLabel(NodeContentTag.InnerRef inRef,out Label lblTitle)
        {
            LinkLabel lbl = new LinkLabel();
            lblTitle = new Label();
            switch (inRef.refType)
            {
                case "refRELATED":
                    lblTitle.Text = "依赖：";
                    break;
                case "refPUNISH":
                    lblTitle.Text = "罚则：";
                    break;
                case "refCHUFA":
                    lblTitle.Text = "行政处罚：";
                    break;
                case "refCHUFEN":
                    lblTitle.Text = "行政处分：";
                    break;
                case "refXINGZHENG":
                    lblTitle.Text = "行政手段：";
                    break;
                case "refZEREN":
                    lblTitle.Text = "其他法律责任：";
                    break;
                case "refXINGYONG":
                    lblTitle.Text = "信用手段：";
                    break;
                case "refXUKE":
                    lblTitle.Text = "许可手段：";
                    break;
                case "refQIANGZHI":
                    lblTitle.Text = "行政强制：";
                    break;
                default:
                    break;
            }

            Law law = db.getLawById(inRef.bookId);
            if (law != null)
            {
                lbl.Text = law.title;
                if (string.IsNullOrEmpty(law.buhao) == false)
                {
                    lbl.Text += "(" + law.buhao + ")";
                }
            }
            if (string.IsNullOrEmpty(inRef.nodeId) == false)
            {
                Node node = db.getNodeById(inRef.nodeId);
                if (node != null)
                {
                    if (string.IsNullOrEmpty(node.nodeNumber) == false)
                    {
                        lbl.Text += "-" + node.nodeNumber;
                    }
                }
            }
            lbl.Tag = law;
            lbl.Click += InnerLbl_Click;

            return lbl;
        }

        private void InnerLbl_Click(object sender, EventArgs e)
        {
            openNewLawView(sender as LinkLabel);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
