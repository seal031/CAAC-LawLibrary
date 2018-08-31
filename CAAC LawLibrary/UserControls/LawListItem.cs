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

namespace CAAC_LawLibrary
{
    public partial class LawListItem : BaseListItem
    {
        public string lawId { get; set; }
        public Law law { get; set; }
        public Form parentForm;

        public LawListItem()
        {
            InitializeComponent();
            
        }

        private void showInfo()
        {
            if (law != null)
            {
                lbl_title.Text = law.title;
                lbl_state.Text = law.status == 1 ? "有效" : "失效";
                lbl_name.Text = law.name;
                lbl_businessType.Text = Global.GetCodeValueById(law.yewu);
                lbl_effectiveDate.Text = law.effectiveDate;
                lbl_expiryDate.Text = law.expiryDate;
                lbl_organization.Text = Global.GetCodeValueById(law.siju);
                if (law.isLocal == "1")
                {
                    lbl_downloadState.Text = "从本地库移除";
                }
                else
                {
                    if (law.downloadPercent.HasValue == false)
                    {
                        lbl_downloadState.Text = "下载";
                    }
                    else
                    {
                        lbl_downloadState.Text = "下载中……";
                    }
                }
                ccb_version.Items.Add(law.version);//tood 多个version
                if (ccb_version.Items.Count > 0)
                { ccb_version.SelectedIndex = 0; }
            }
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {
            LawView lv = new CAAC_LawLibrary.LawView();
            lv.parentForm = parentForm;
            lv.Show(this);
            parentForm.Hide();
        }

        private void LawListItem_Load(object sender, EventArgs e)
        {
            showInfo();
        }
    }
}
