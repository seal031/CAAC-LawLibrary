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
    public partial class RefPanel : UserControl
    {
        public RefPanel()
        {
            InitializeComponent();
        }

        public void setText(string nodeRef)
        {
            List<string> list = nodeRef.Split(new char[] { ';' }).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                string s = list[i];
                if (s.Contains("@"))//法规@章节
                {
                    List<string> sList = s.Split(new string[] {"@" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    string lawId = sList[0];
                    string nodeId = sList[1];
                }
                else//只有法规
                {
                    string lawId = s;
                }
            }
        }

        private void ll_yilai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void ll_zefa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
