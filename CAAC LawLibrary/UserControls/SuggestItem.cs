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

namespace CAAC_LawLibrary
{
    public partial class SuggestItem : UserControl
    {
        public SuggestItem()
        {
            InitializeComponent();
        }

        public void ShowEntity<T>(T entity) where T : Suggest
        {
            this.lbl_lawNo.Text = entity.lawId;
            this.rtb_remark.Text = entity.remark;
            this.rtb_suggest.Text = entity.suggest_content;
        }
    }
}
