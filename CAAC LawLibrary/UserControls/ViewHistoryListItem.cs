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
        public Law law;
        public Form parentForm;
        public DbHelper db = new DbHelper();

        public ViewHistoryListItem()
        {
            InitializeComponent();
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {
            LawView lv = new CAAC_LawLibrary.LawView();
            lv.Show();
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
                    lbl_title.Text = law.digest; ;
                    lbl_state.Text = law.status == 1 ? "有效" : "失效";
                    lbl_name.Text = law.title;
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
                    lbl_version.Text = law.version;
                }
            }
        }
    }
}
