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
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Utity;

namespace CAAC_LawLibrary
{
    public partial class ViewHistoryListItem : BaseListItem
    {
        public ViewHistory viewHistory;
        public Form parentForm;
        public DbHelper db = new DbHelper();

        public ViewHistoryListItem()
        {
            InitializeComponent();
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {
            openLaw();
        }

        private void openLaw()
        {
            LawView lv = new CAAC_LawLibrary.LawView();
            lv.law = law;
            lv.parentForm = parentForm;
            lv.Show(this);
            parentForm.Hide();
        }

        public void fillViewHistory()
        {
            if (viewHistory != null)
            {
                List<Law> laws = db.getLaws(new Utity.QueryParam() { lawId = viewHistory.LawID });
                if (laws.Count > 0)
                {
                    law = laws[0];
                    lbl_title.Text = law.title; ;
                    toolTip1.SetToolTip(lbl_title, lbl_title.Text);
                    lbl_state.Text = DateTime.Parse(law.expiryDate) > DateTime.Now ? "有效" : "失效";
                    lbl_name.Text = law.digest;
                    lbl_businessType.Text = Global.GetCodeValueById(law.yewu);
                    lbl_effectiveDate.Text = DateTime.Parse(law.effectiveDate).ToString("yyyy-MM-dd") + "至" + DateTime.Parse(law.expiryDate).ToString("yyyy-MM-dd");
                    //lbl_expiryDate.Text = law.expiryDate;
                    lbl_organization.Text = Global.GetCodeValueById(law.siju);
                    if (law.isLocal == "1")
                    {
                        lbl_downloadState.Text = "移除";
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
                    lbl_version.Text = law.version;
                }
            }
        }

        private void lbl_downloadState_Click(object sender, EventArgs e)
        {
            if (lbl_downloadState.Text == "下载")
            {
                ((LibraryList)parentForm).downloadSelectedLawToLocal(law);
                if (Global.online)
                {
                    lbl_downloadState.Text = "下载中……";
                }
            }
            if (lbl_downloadState.Text == "移除")
            {
                ((LibraryList)parentForm).removeSelectedLocalLaw(law);
                lbl_downloadState.Text = "下载";
            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            openLaw();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            openLaw();
        }

        private void lbl_businessType_Click(object sender, EventArgs e)
        {
            openLaw();
        }

        private void lable1_Click(object sender, EventArgs e)
        {
            openLaw();
        }

        private void lbl_name_Click(object sender, EventArgs e)
        {
            openLaw();
        }
    }
}
