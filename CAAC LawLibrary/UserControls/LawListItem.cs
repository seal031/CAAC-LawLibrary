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
using System.Collections;

namespace CAAC_LawLibrary
{
    public partial class LawListItem : BaseListItem
    {
        public string lawId { get; set; }
        public Law law { get; set; }
        public List<Law> laws { get; set; }
        public Form parentForm;
        public bool isChecked = false;
        private bool bindState = false;

        public LawListItem()
        {
            InitializeComponent();
            laws = new List<Law>();
        }

        public void checkChange()
        {
            isChecked = !isChecked;
            if (isChecked)
            {
                ckb.Checked = true;
            }
            else
            {
                ckb.Checked = false;
            }
        }

        private void showInfo()
        {
            if (law != null)
            {
                lbl_title.Text = law.digest; ;
                lbl_state.Text = law.status == 1 ? "有效" : "失效";
                lbl_name.Text = law.title;
                lbl_businessType.Text = Global.GetCodeValueById(law.yewu);
                lbl_effectiveDate.Text = law.effectiveDate;
                lbl_expiryDate.Text = law.expiryDate;
                lbl_organization.Text = Global.GetCodeValueById(law.siju);
                if (law.isLocal == "1")
                {
                    lbl_downloadState.Text = "从本地库移除";
                }
                else
                {
                    if (law.downloadPercent.HasValue == false)
                    {
                        lbl_downloadState.Text = "下载";
                    }
                    else
                    {
                        lbl_downloadState.Text = "下载中……";
                    }
                }
                //ccb_version.Items.Add(law.version);
                //if (ccb_version.Items.Count > 0)
                //{ ccb_version.SelectedIndex = 0; }
            }
        }
       

        private void LawListItem_Load(object sender, EventArgs e)
        {
            showInfo();
        }

        private void ccb_version_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
            {
                DictionaryEntry selectedItem;
                try
                {
                    selectedItem = (DictionaryEntry)ccb_version.SelectedItem;
                }
                catch (Exception)
                {
                    MessageBox.Show("所选版本无效");
                    return;
                }
                Law selectedLaw = laws.FirstOrDefault(l => l.Id == selectedItem.Key.ToString());
                if (selectedLaw != null)
                {
                    openLaw(selectedLaw);
                }
            }
        }

        private void LawListItem_Click(object sender, EventArgs e)
        {
            openLaw(law);
        }
        private void panel2_Click(object sender, EventArgs e)
        {
            openLaw(law);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            openLaw(law);
        }

        private void openLaw(Law law)
        {
            LawView lv = new CAAC_LawLibrary.LawView();
            lv.law = law;
            lv.parentForm = parentForm;
            lv.Show(this);
            parentForm.Hide();
        }

        public void addVerionDropDown()
        {
            foreach (Law law in laws)
            {
                ccb_version.Items.Add(new DictionaryEntry { Value = law.version, Key = law.Id });
            }
            ccb_version.SelectedIndex = 0;
            ccb_version.DisplayMember = "Value";
            ccb_version.ValueMember = "Key";
            bindState = true;
        }

        private void ckb_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb.Checked) { isChecked = true; }
            else { isChecked = false; }
        }
    }
}
