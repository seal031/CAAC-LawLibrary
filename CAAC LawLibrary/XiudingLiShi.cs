using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary
{
    public partial class XiudingLiShi : Form
    {
        public XiudingLiShi()
        {
            InitializeComponent();
        }

        public void setRtbText(string text)
        {
            rtb.Text = text;
            rtb.SelectAll();
            rtb.SelectionAlignment = HorizontalAlignment.Center;
            rtb_title.SelectAll();
            rtb_title.SelectionAlignment = HorizontalAlignment.Center;
        }
    }
}
