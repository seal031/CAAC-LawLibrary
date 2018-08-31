using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAAC_LawLibrary.BLL;
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;

namespace CAAC_LawLibrary
{
    public partial class LawView : Form
    {
        public string lawId = string.Empty;
        public Law law;
        private List<Node> nodes;
        private DbHelper db = new DbHelper();
        public Form parentForm;

        public LawView()
        {
            InitializeComponent();
        }

        private void LawView_FormClosed(object sender, FormClosedEventArgs e)
        {
            //System.Environment.Exit(0);
        }

        private void LawView_Load(object sender, EventArgs e)
        {
            lawInfo1.law = law;
            if (law != null)
            {
                nodes = db.getNodeByLawId(law.Id);
                wb.DocumentText = NodeWorker.buildFromNodeContext(nodes);
            }
        }


        private void bindingTree()
        {

        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.Show();
                this.Close();
            }
        }
    }
}
