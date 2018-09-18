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
    public partial class TagLabel : UserControl
    {
        public string lawId;
        public string nodeId;


        public TagLabel()
        {
            InitializeComponent();
        }

        private void lbl_label_Click(object sender, EventArgs e)
        {

        }

        public void setLblText(string text)
        {
            lbl_label.Text = text.Trim();
        }

        private void lbl_label_TextChanged(object sender, EventArgs e)
        {
            string text = lbl_label.Text.Trim();
            switch (text)
            {
                case "定":
                    lbl_label.BackColor = Color.Yellow;
                    break;
                case "键":
                    lbl_label.BackColor = Color.Orange;
                    break;
                case "类":
                    lbl_label.BackColor = Color.Gray;
                    break;
                case "依":
                    lbl_label.BackColor = Color.Blue;
                    break;
                case "":
                    lbl_label.BackColor = Color.White;
                    break;
                default:
                    break;
            }
        }
    }
}
