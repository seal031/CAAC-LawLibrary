using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAAC_LawLibrary.Entity;

namespace CAAC_LawLibrary
{
    public partial class LawView : Form
    {
        public string lawId = string.Empty;
        public Law law;

        public LawView()
        {
            InitializeComponent();
        }

        private void LawView_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
