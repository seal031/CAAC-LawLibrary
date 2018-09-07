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
using CAAC_LawLibrary.Entity;

namespace CAAC_LawLibrary
{
    public partial class BaseFilter : UserControl
    {
        protected internal QueryParam queryParam = new QueryParam();
        private DbHelper db = new DbHelper();
        private bool bindState = false;

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
            bindSiju();
            bindBuhao();
            bindWeijie();
            bindZidingyi();
            bindState = true;
        }

        private void bindBuhao()
        {
            cbb_buhao.DataSource = new BindingSource(Global.buhao, null);
            cbb_buhao.DisplayMember = "desc";
            cbb_buhao.ValueMember = "Id";
        }

        private void bindYewu()
        {
            cbb_yewu.DataSource = new BindingSource(Global.yewu, null);
            cbb_yewu.DisplayMember = "desc";
            cbb_yewu.ValueMember = "Id";
        }

        private void bindSiju()
        {
            cbb_siju.DataSource = new BindingSource(Global.siju, null);
            cbb_siju.DisplayMember = "desc";
            cbb_siju.ValueMember = "Id";
        }

        private void bindWeijie()
        {
            cbb_weijie.DataSource = new BindingSource(Global.weijie, null);
            cbb_weijie.DisplayMember = "desc";
            cbb_weijie.ValueMember = "Id";
        }

        private void bindZidingyi()
        {
            cbb_zidingyi.DataSource = new BindingSource(Global.zidingyi, null);
            cbb_zidingyi.DisplayMember = "desc";
            cbb_zidingyi.ValueMember = "Id";
        }

        private void cbb_buhao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
                queryParam.buhao = (cbb_buhao.SelectedValue as Code).Id;
        }

        private void cbb_siju_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
                queryParam.siju = (cbb_siju.SelectedItem as Code).Id;
        }

        private void cbb_weijie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
                queryParam.weijie = (cbb_weijie.SelectedItem as Code).Id;
        }

        private void cbb_yewu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
                queryParam.yewu = (cbb_yewu.SelectedItem as Code).Id;
        }

        private void cbb_zidingyi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
                queryParam.zidingyi = (cbb_zidingyi.SelectedItem as  Code).Id;
        }
    }
}
