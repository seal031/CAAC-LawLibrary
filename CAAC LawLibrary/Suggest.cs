using CAAC_LawLibrary.BLL;
using CAAC_LawLibrary.BLL.Entity;
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;
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
    public partial class SuggestForm : Form
    {
        public string LawId { get; set; }
        DbHelper db = new DbHelper();
        List<Suggest> list = new List<Suggest>();

        public SuggestForm()
        {
            InitializeComponent();
        }

        private void SuggestForm_Load(object sender, EventArgs e)
        {
            list = db.getSuggests(LawId, Global.user.Id);
            foreach (Suggest suggest in list)
            {
                SuggestItem si = new CAAC_LawLibrary.SuggestItem();
                si.ShowEntity(suggest);
                flp.Controls.Add(si);
            }
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            ConsultRequest consultRequest = new ConsultRequest();
            consultRequest.ConvertFromSuggests(list);
            RemoteWorker.postCommit(consultRequest);
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
