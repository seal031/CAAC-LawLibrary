using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.DAL;

namespace CAAC_LawLibrary
{
    public partial class SuggestItem : UserControl
    {
        DbHelper db = new DbHelper();
        public SuggestItem()
        {
            InitializeComponent();
        }

        public void ShowEntity<T>(T entity) where T : Suggest
        {
            Node node = db.getNodeById(entity.nodeId);
            this.lbl_lawNo.Text = node.title;
            this.rtb_remark.Text = entity.remark;
            this.rtb_suggest.Text = entity.suggest_content;
        }
    }
}
