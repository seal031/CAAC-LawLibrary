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

namespace CAAC_LawLibrary
{
    public partial class DownloadListItem : BaseListItem
    {
        public Law law;
        public string downloadUrl;
        private int downLoadValue = 0;

        delegate void setLableTextDelegate();
        setLableTextDelegate setLabelTextEvent;

        public DownloadListItem()
        {
            InitializeComponent();
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
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(500);
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
                lbl_downloadState.Text = downLoadValue.ToString();
            }
        }
    }
}
