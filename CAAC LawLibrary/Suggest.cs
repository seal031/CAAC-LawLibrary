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

        public SuggestForm()
        {
            InitializeComponent();
        }

        private void SuggestForm_Load(object sender, EventArgs e)
        {
            List<Suggest> list = db.getSuggests(LawId, Global.user.Id);
            foreach (Suggest suggest in list)
            {
                SuggestItem si = new CAAC_LawLibrary.SuggestItem();
                si.ShowEntity(suggest);
                flp.Controls.Add(si);
            }
        }

        
    }
}
