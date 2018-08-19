using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAAC_LawLibrary.Utity;
using CAAC_LawLibrary.DAL;

namespace CAAC_LawLibrary
{
    public partial class BaseFilter : UserControl
    {
        protected internal QueryParam queryParam = new QueryParam();
        private DbHelper db = new DbHelper();

        public BaseFilter()
        {
            InitializeComponent();
        }

        private void BaseFilter_Load(object sender, EventArgs e)
        {
            cbb_sort.DataSource = new BindingSource(Global.SortSource, null);
            cbb_sort.DisplayMember = "Value";
            cbb_sort.ValueMember = "Key";

            bindComboBox();
        }

        private void bindComboBox()
        {
            bindYewu();
        }

        private void bindYewu()
        {
            var a = db.getCode("biz");
            cbb_yewu.DataSource = new BindingSource(db.getCode("biz"), null);
            cbb_yewu.DisplayMember = "desc";
            cbb_yewu.ValueMember = "Id";
        }

        private void cbb_buhao_SelectedIndexChanged(object sender, EventArgs e)
        {
            queryParam.buhao = cbb_buhao.SelectedValue.ToString();
        }

        private void cbb_siju_SelectedIndexChanged(object sender, EventArgs e)
        {
            queryParam.siju = cbb_siju.SelectedValue.ToString();
        }

        private void cbb_weijie_SelectedIndexChanged(object sender, EventArgs e)
        {
            queryParam.weijie = cbb_weijie.SelectedValue.ToString();
        }

        private void cbb_yewu_SelectedIndexChanged(object sender, EventArgs e)
        {
            queryParam.yewu = cbb_yewu.SelectedValue.ToString();
        }

        private void cbb_zidingyi_SelectedIndexChanged(object sender, EventArgs e)
        {
            queryParam.zidingyi = cbb_zidingyi.SelectedValue.ToString();
        }
    }
}
