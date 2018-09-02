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
using CAAC_LawLibrary.Utity;

namespace CAAC_LawLibrary.UserControls
{
    public partial class LawInfo : UserControl
    {
        public Law law;

        public LawInfo()
        {
            InitializeComponent();
        }

        private void LawInfo_Load(object sender, EventArgs e)
        {
            
        }

        public void fillLawInfo()
        {
            if (law != null)
            {
                lbl_name.Text = law.name;
                lbl_guanlijigou.Text = Global.GetCodeValueById(law.siju);
                lbl_banben.Text = law.version;
                lbl_banwendanwei.Text = Global.GetCodeValueById(law.siju);
                lbl_buhao.Text = law.buhao;
                lbl_guanjianzi.Text = law.keyword;
                lbl_leixing.Text = Global.GetCodeValueById(law.yewu);
                lbl_linghao.Text = law.linghao;
                lbl_xiudingling.Text = law.xiudingling;
                lbl_yewufenlei.Text = Global.GetCodeValueById(law.yewu);
                lbl_yilai.Text = law.yilai;
                lbl_zefa.Text = law.zefa;
                rtb_zhaiyao.Text = law.digest;
            }
        }
    }
}
