using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary
{
    public partial class LawFilter : BaseFilter
    {
        public Form parentForm;

        public LawFilter()
        {
            InitializeComponent();
        }

        private void btn_manageLocal_Click(object sender, EventArgs e)
        {
            menu.Show(btn_manageLocal, 0,20);
        }

        private void ckb_showDownloaded_CheckedChanged(object sender, EventArgs e)
        {
            queryParam.downloaded = ckb_showDownloaded.Checked ? "1" : "0";
            ((LibraryList)parentForm).loadLocalLawList();
        }

        private void 下载已选项到本地库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((LibraryList)parentForm).downloadSelectedLawToLocal();
        }

        private void 从本地库移除已选项ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((LibraryList)parentForm).removeSelectedLocalLaw();
        }

        private void 清空本地库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((LibraryList)parentForm).clearLocal();
        }

        private void ckb_selectAll_CheckedChanged(object sender, EventArgs e)
        {
            ((LibraryList)parentForm).lawCheckBoxChange(ckb_selectAll.Checked);
        }
    }
}
