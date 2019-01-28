using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary.UserControls
{
    public partial class BasePaging : UserControl
    {
        public int currentPage;//当前页数
        public int sumPage;//总页数
        public int countPerPage = 20;//每页显示数量

        public BasePaging()
        {
            InitializeComponent();
        }
    }
}
