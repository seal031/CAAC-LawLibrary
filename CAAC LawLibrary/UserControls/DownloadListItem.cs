using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;

namespace CAAC_LawLibrary
{
    public partial class DownloadListItem : BaseListItem
    {
        public Law law;
        public string downloadUrl;
        private int downLoadValue = 0;
        public Form parentForm;
        public bool isChecked
        {
            get { return ckb.Checked; }
            set
            {
                ckb.Checked = value;
            }
        }

        delegate void setLableTextDelegate();
        setLableTextDelegate setLabelTextEvent;

        public string downloadState
        {
            get
            {
                if (law.downloadPercent == 100) return "2";
                else return "1";
            }
        }

        public DownloadListItem()
        {
            InitializeComponent();
            isChecked = false;
            bgw.WorkerSupportsCancellation = true;
            bgw.DoWork += Bgw_DoWork;
            lbl_downloadState.Click += Lbl_downloadState_Click;
            setLabelTextEvent = new setLableTextDelegate(setDownloadState) ;
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            downloadWork();
        }

        private void Lbl_downloadState_Click(object sender, EventArgs e)
        {
            if (bgw.IsBusy)
            {
                bgw.CancelAsync();
            }
            else
            {
                bgw.RunWorkerAsync();
            }
        }

        private void downloadWork()
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(50);
                downLoadValue = i;
                setDownloadState();
            }
        }

        private void setDownloadState()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(setLabelTextEvent);
            }
            else
            {
                lbl_downloadState.Text = downLoadValue.ToString()+"%";
            }
        }

        public void checkChange(bool value)
        {
            ckb.Checked = value;
        }

        private void ckb_CheckedChanged(object sender, EventArgs e)
        {
            //if (ckb.Checked) { isChecked = true; }
            //else { isChecked = false; }
        }

        private void DownloadListItem_Load(object sender, EventArgs e)
        {
            showInfo();
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
                lbl_state.Text = "下载日期："+law.downloadDate;
                if (law.isLocal == "1")
                {
                    lbl_downloadState.Text = "下载完成";
                }
                else
                {
                    lbl_downloadState.Text = "暂停("+law.downloadPercent.ToString()+"%)";
                }
                //ccb_version.Items.Add(law.version);
                //if (ccb_version.Items.Count > 0)
                //{ ccb_version.SelectedIndex = 0; }
            }
        }

        /// <summary>
        /// 删除任务，即将downloadPercent设为null
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_delete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            law.downloadPercent = null;
            ((LibraryList)parentForm).updateLaw(law);
        }

        private void openLaw()
        {
            LawView lv = new CAAC_LawLibrary.LawView();
            lv.law = law;
            lv.parentForm = parentForm;
            lv.Show(this);
            parentForm.Hide();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            openLaw();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            openLaw();
        }
    }
}
