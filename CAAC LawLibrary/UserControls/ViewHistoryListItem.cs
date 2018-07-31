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
    public partial class ViewHistoryListItem : BaseListItem
    {
        public ViewHistoryListItem()
        {
            InitializeComponent();
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {
            LawView lv = new CAAC_LawLibrary.LawView();
            lv.Show();
            this.Hide();
        }
    }
}
