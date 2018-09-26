using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;
using DevComponents.DotNetBar;
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
    public partial class LibraryList : Form
    {
        DbHelper db = new DbHelper();


        public LibraryList()
        {
            InitializeComponent();
            lawFilter.parentForm = this;
            setFlpTopDownOnly(flp_libraryList);
            setFlpTopDownOnly(flp_viewHistory);
            setFlpTopDownOnly(flp_downloadTask);
            lawFilter.onSelectedChanged += loadLocalLawList;
            viewHistoryFilter.onSelectedChanged += loadViewHistoryList;
            downloadFilter.onSelectedChanged += loadDownLoadList;
        }
        

        /// <summary>
        /// 设置flowLayoutPanel只能上下滚动
        /// </summary>
        private void setFlpTopDownOnly(FlowLayoutPanel flp)
        {
            flp.AutoScroll = false;
            flp.WrapContents = false;
            flp.HorizontalScroll.Maximum = 0;
            flp.AutoScroll = true;
        }

        /// <summary>
        /// 窗体关闭时退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LibraryList_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void LibraryList_Load(object sender, EventArgs e)
        {
            if (Global.online) { this.Text = "联网模式"; }
            else { this.Text = "离线模式"; }
            loadLocalLawList();
            loadViewHistoryList();
            loadDownLoadList();
        }

        #region 加载3个列表
        private void loadLocalLawList()
        {
            removeFromFlp(flp_libraryList);
            List<Law> list = db.getLaws(lawFilter.queryParam);
            List<string> addedLastVersion = new List<string>();//已经添加过的法规id
            foreach (Law law in list)
            {
                if (addedLastVersion.Contains(law.lastversion.ToString())) { continue; }
                else
                {
                    addedLastVersion.Add(law.lastversion.ToString());
                    LawListItem item = new LawListItem();
                    //查找同一部法规的全部版本（包括本身）
                    var allVersionList = list.Where(l => l.lastversion == law.lastversion).OrderByDescending(l => l.Id);
                    if (allVersionList.Count() > 1)
                    {
                        item.law = allVersionList.Last();//如果有多个版本，取最新版本
                    }
                    else
                    {
                        item.law = law;
                    }
                    item.laws = allVersionList.ToList();
                    item.parentForm = this;
                    item.addVerionDropDown();
                    flp_libraryList.Controls.Add(item); 
                }
            }
        }

        private void loadViewHistoryList()
        {
            removeFromFlp(flp_viewHistory);
            List<ViewHistory> list = db.getViewHistory(viewHistoryFilter.queryParam);
            foreach (ViewHistory vh in list)
            {
                ViewHistoryListItem item = new ViewHistoryListItem();
                item.viewHistory = vh;
                item.fillViewHistory();
                item.parentForm = this;
                flp_viewHistory.Controls.Add(item);
            }
        }

        private void loadDownLoadList()
        {
            removeFromFlp(flp_downloadTask);
            List<Law> list = db.getLaws(downloadFilter.queryParam).Where(l=>l.downloadPercent!=null).ToList();
            foreach (Law law in list)
            {
                DownloadListItem item = new DownloadListItem();
                item.law = law;
                flp_downloadTask.Controls.Add(item);
            }
        }

        private void removeFromFlp(FlowLayoutPanel flp)
        {
            int controlsCount = flp.Controls.Count;
            for (int i = controlsCount - 1; i >= 1; i--)
            {
                flp.Controls.RemoveAt(i);
            }
        }
        #endregion
        /// <summary>
        /// 下载到本地库
        /// </summary>
        public void downloadSelectedLawToLocal()
        {

        }
        /// <summary>
        /// 从本地库移除
        /// </summary>
        public void removeSelectedLocalLaw()
        {

        }
        /// <summary>
        /// 清空本地库
        /// </summary>
        public void clearLocal()
        {
            db.clearHistory();
        }

        /// <summary>
        /// 将阅读历史主动加到阅读历史列表中，避免再次查库。加入时，如果列表中没有相同的法规，则新增，如果有，则将其提至第一条
        /// </summary>
        /// <param name="history"></param>
        public void addHistory(ViewHistory history)
        {
            bool found = false;
            for (int i = 1; i < flp_viewHistory.Controls.Count; i++)
            {
                var tempVh = flp_viewHistory.Controls[i] as ViewHistoryListItem;
                if (tempVh.viewHistory.LawID == history.LawID)
                {
                    flp_viewHistory.Controls.SetChildIndex(tempVh, 1);
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                ViewHistoryListItem item = new ViewHistoryListItem();
                item.parentForm = this;
                item.viewHistory = history;
                item.fillViewHistory();
                flp_viewHistory.Controls.Add(item);
                flp_viewHistory.Controls.SetChildIndex(item, 1);
            }
        }

        public void lawCheckBoxChange()
        {
            foreach (var item in flp_libraryList.Controls)
            {
                var lawItem = item as LawListItem;
                if (lawItem == null) continue;
                lawItem.checkChange();
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            logout();
        }

        public void logout()
        {
            if (MessageBoxEx.Show("确认退出？", "退出", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
