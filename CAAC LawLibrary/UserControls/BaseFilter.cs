using CAAC_LawLibrary.BLL;
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CAAC_LawLibrary
{
    public partial class BaseFilter : UserControl
    {
        protected internal QueryParam queryParam = new QueryParam();
        private DbHelper db = new DbHelper();
        private bool bindState = false;
        public LibraryList parentForm;

        public delegate void selectedChanged();
        public event selectedChanged onSelectedChanged;

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
            bindBanwendanwei();
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

        private void bindBanwendanwei()
        {
            cbb_banwendanwei.DataSource = new BindingSource(Global.banwendanwei, null);
            cbb_banwendanwei.DisplayMember = "desc";
            cbb_banwendanwei.ValueMember = "Id";
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
            {
                queryParam.buhao = (cbb_buhao.SelectedItem as Code).Id;
                onSelectedChanged();
            }
        }

        private void cbb_siju_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
            {
                queryParam.siju = (cbb_siju.SelectedItem as Code).Id;
                onSelectedChanged();
            }
        }
        private void cbb_banwendanwei_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
            {
                queryParam.banwendanwei = (cbb_banwendanwei.SelectedItem as Code).Id;
                onSelectedChanged();
            }
        }

        private void cbb_weijie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
            {
                queryParam.weijie = (cbb_weijie.SelectedItem as Code).Id;
                onSelectedChanged();
            }
        }

        private void cbb_yewu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
            {
                queryParam.yewu = (cbb_yewu.SelectedItem as Code).Id;
                onSelectedChanged();
            }
        }

        private void cbb_zidingyi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
            {
                queryParam.zidingyi = (cbb_zidingyi.SelectedItem as Code).Id;
                onSelectedChanged();
            }
        }

        protected void cbb_sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
            {
                queryParam.sort = int.Parse(cbb_sort.SelectedValue.ToString());
                onSelectedChanged();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_keyword.Text.Trim() != string.Empty)
            {
                if (Global.online)
                {
                    List<string> lawIdList = RemoteWorker.getSearch(txt_keyword.Text.Trim());
                    ((LibraryList)parentForm).LoadSearchResultLaw(lawIdList);
                }
                else
                {
                    List<string> lawIdList = db.offLineSearch(queryParam, txt_keyword.Text.Trim());
                    ((LibraryList)parentForm).LoadSearchResultLaw(lawIdList);
                }
            }
            else
            {
                ((LibraryList)parentForm).loadLocalLawList();//如果搜索内容为空，则显示全部法规
            }
        }

    }
}
