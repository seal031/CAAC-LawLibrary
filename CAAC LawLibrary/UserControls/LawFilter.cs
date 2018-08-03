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
        }
    }
}
