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
    public partial class DownloadFilter : BaseFilter
    {
        public DownloadFilter()
        {
            InitializeComponent();
        }

        private void btn_manageTask_Click(object sender, EventArgs e)
        {
            menu.Show(btn_manageTask, 0, 20);
        }
    }
}
