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
using CAAC_LawLibrary.BLL;
using CAAC_LawLibrary.DAL;

namespace CAAC_LawLibrary
{
    public partial class DownloadListItem : BaseListItem
    {
        public string downloadUrl;
        private int downLoadValue = 0;
        public Form parentForm;
        DbHelper db = new DbHelper();

        public bool isChecked
        {
            get { return ckb.Checked; }
            set
            {
                ckb.Checked = value;
            }
        }

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
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += Bgw_DoWork;
            bgw.ProgressChanged += Bgw_ProgressChanged;
            lbl_downloadState.Click += Lbl_downloadState_Click;
        }

        private void Bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string text = string.Empty;
            if (downLoadValue >= 100)
            {
                text = "下载完成";
            }
            else
            {
                text = "下载进度 " + downLoadValue.ToString() + "%";
            }
            setDownloadState(text);
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            downloadWork();
        }

        /// <summary>
        /// 点击下载按钮的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lbl_downloadState_Click(object sender, EventArgs e)
        {
            if (bgw.IsBusy)
            {
                stopWork();
            }
            else
            {
                continueWork(); 
            }
        }

        public void stopWork()
        {
            if (bgw.IsBusy)
            {
                lbl_downloadState.Text = "下载暂停 " + downLoadValue.ToString() + "%";
                bgw.CancelAsync();
            }
        }
        public void continueWork()
        {
                if (bgw.IsBusy == false)
                {
                    bgw.RunWorkerAsync();
                }
        }

        private void downloadWork()
        {
            List<Node> nodes = RemoteWorker.getBookContent(law.lawId);
            int startIndex = law.downloadNodeCount.HasValue ? (int)law.downloadNodeCount+1 : 1;
            for (int i = startIndex; i <= nodes.Count; i++)
            {
                if (bgw.CancellationPending)
                {
                    //暂停时记录已下载的章节数量，用于下次登录程序后继续下载；记录下载进度，用于下次登录后显示进度
                    law.downloadNodeCount = i - 1;
                    law.downloadPercent= (int)(Math.Round(((float)law.downloadNodeCount / (float)nodes.Count), 2) * 100);
                    db.saveLaw(law);
                    return;
                }
                else
                {
                    bgw.ReportProgress(i);
                    downLoadValue = (int)(Math.Round(((float)i / (float)nodes.Count), 2) * 100);
                    RemoteWorker.getNodeDetail(nodes[i - 1].Id);
                }
            }
            bgw.ReportProgress(100);
            //下载完成后，改变law的islocal状态为1，并将下载进度设置为100
            law.downloadPercent = 100;
            law.downloadNodeCount = nodes.Count;
            law.isLocal = "1";
            db.saveLaw(law);
            //下载完成后，法规列表、阅读历史列表显示为“从本地库移除”
            ((LibraryList)parentForm).setLawStateText(typeof(LawListItem), law, "移除");
            ((LibraryList)parentForm).setLawStateText(typeof(ViewHistoryListItem), law, "移除");
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
                lbl_title.Text = law.title + "  " + law.version;
                toolTip1.SetToolTip(lbl_title, lbl_title.Text);
                lbl_state.Text = DateTime.Parse(law.expiryDate)>DateTime.Now ? "有效" : "失效";
                lbl_name.Text = law.digest;
                lbl_businessType.Text = Global.GetCodeValueById(law.yewu);
                lbl_effectiveDate.Text = law.effectiveDate + "至" + law.expiryDate;
                lbl_expiryDate.Text = law.expiryDate;
                lbl_organization.Text = Global.GetCodeValueById(law.siju);
                lbl_state.Text = "下载日期："+law.downloadDate;
                if (law.isLocal == "1")
                {
                    lbl_downloadState.Text = "下载完成";
                }
                else
                {
                    lbl_downloadState.Text = law.downloadPercent.HasValue ? "下载暂停 " + law.downloadPercent.ToString() + "%" : "下载暂停 0%";
                }
                if (law.downloadPercent.HasValue)
                {
                    downLoadValue = (int)law.downloadPercent;
                }
                //ccb_version.Items.Add(law.version);
                //if (ccb_version.Items.Count > 0)
                //{ ccb_version.SelectedIndex = 0; }
            }
        }

        /// <summary>
        /// 删除任务，即将downloadPercent设为null，islocal保留
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_delete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            law.downloadPercent = null;
            ((LibraryList)parentForm).updateLaw(law);
            ((LibraryList)parentForm).setLawStateText(typeof(LawListItem), law, "下载");
            ((LibraryList)parentForm).setLawStateText(typeof(ViewHistoryListItem), law, "下载");
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

        private void lbl_title_Click(object sender, EventArgs e)
        {
            openLaw();
        }

        private void lbl_name_Click(object sender, EventArgs e)
        {
            openLaw();
        }

        private void lable1_Click(object sender, EventArgs e)
        {
            openLaw();
        }

        private void lbl_businessType_Click(object sender, EventArgs e)
        {
            openLaw();
        }

        private void lbl_organization_Click(object sender, EventArgs e)
        {
            openLaw();
        }
    }
}
