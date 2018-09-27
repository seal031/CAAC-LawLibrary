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
    public partial class ViewHistoryFilter : BaseFilter
    {
        public Form parentForm;
        public ViewHistoryFilter()
        {
            InitializeComponent();
        }

        private void ckb_showDownloaded_CheckedChanged(object sender, EventArgs e)
        {
            queryParam.downloaded = ckb_showDownloaded.Checked ? "1" : "0";
            ((LibraryList)parentForm).loadViewHistoryList();
        }

        private void btn_clearHistory_Click(object sender, EventArgs e)
        {
            ((LibraryList)parentForm).clearHistory();
        }
    }
}
