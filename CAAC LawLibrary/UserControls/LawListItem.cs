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

        public LawListItem()
        {
            InitializeComponent();
        }

        private void showInfo()
        {
            if (law != null)
            {
                lbl_title.Text = law.title;
                lbl_state.Text = "下载日期："+law.downloadDate;
                lbl_name.Text = law.name;
                lbl_businessType.Text = law.yewu;
                lbl_effectiveDate.Text = law.effectiveDate;
                lbl_expiryDate.Text = law.expiryDate;
                lbl_organization.Text = Global.GetCodeValueById(law.siju);
                lbl_downloadState.Text = law.isLocal;
            }
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {
            LawView lv = new CAAC_LawLibrary.LawView();
            lv.Show(this);
            this.Hide();
        }

        private void LawListItem_Load(object sender, EventArgs e)
        {
            showInfo();
        }
    }
}
