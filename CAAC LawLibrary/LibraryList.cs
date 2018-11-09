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
            viewHistoryFilter.parentForm = this;
            downloadFilter.parentForm = this;
            setFlpTopDownOnly(flp_lawLibrary);
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

        private void LibraryList_Load(object sender, EventArgs e)
        {
            if (Global.online) { this.Text = "联网模式"; }
            else { this.Text = "离线模式"; }
            lbl_welcome.Text += Global.user.Xm;
            loadLocalLawList();
            loadViewHistoryList();
            loadDownLoadList();
            loadUpdateHistoryList();
        }

        public void LoadSearchResultLaw(List<string> lawIdList)
        {
            //tbc.SelectedIndex = 0;
            tbc.SelectedTabIndex = 0;
            removeFromFlp(flp_lawLibrary);
            List<Law> list = new List<Law>();
            foreach (string lawId in lawIdList)
            {
                Law law = db.getLawById(lawId);
                if (law != null)
                {
                    list.Add(law);
                }
            }
            List<string> addedLastVersion = new List<string>();//已经添加过的法规id
            foreach (Law law in list)
            {
                if (addedLastVersion.Contains(law.lastversion.ToString())) { continue; }
                else
                {
                    addedLastVersion.Add(law.lastversion.ToString());
                    LawListItem item = new LawListItem();
                    //查找同一部法规的全部版本（包括本身）
                    var allVersionList = list.Where(l => l.lastversion == law.lastversion).OrderByDescending(l => l.version);
                    item.law = law;
                    item.laws = allVersionList.ToList();
                    item.parentForm = this;
                    item.addVerionDropDown();
                    flp_lawLibrary.Controls.Add(item);
                }
            }
        }

        #region 加载4个列表
        /// <summary>
        /// 加载法规列表
        /// </summary>
        public void loadLocalLawList()
        {
            removeFromFlp(flp_lawLibrary);
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
                    var allVersionList = list.Where(l => l.lastversion == law.lastversion).OrderByDescending(l => l.version);
                    if (allVersionList.Count() > 1)
                    {
                        item.law = allVersionList.First();//如果有多个版本，取最新版本
                    }
                    else
                    {
                        item.law = law;
                    }
                    item.laws = allVersionList.ToList();
                    item.parentForm = this;
                    item.addVerionDropDown();
                    flp_lawLibrary.Controls.Add(item); 
                }
            }
        }
        /// <summary>
        /// 加载阅读历史列表
        /// </summary>
        public void loadViewHistoryList()
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
        /// <summary>
        /// 加载下载列表
        /// </summary>
        public void loadDownLoadList()
        {
            removeFromFlp(flp_downloadTask);
            List<Law> list = db.getLaws(downloadFilter.queryParam).Where(l=>l.downloadPercent!=null).ToList();
            foreach (Law law in list)
            {
                DownloadListItem item = new DownloadListItem();
                item.law = law;
                item.parentForm = this;
                flp_downloadTask.Controls.Add(item);
            }
        }
        /// <summary>
        /// 加载自动更新列表
        /// </summary>
        public void loadUpdateHistoryList()
        {
            dgv_updateHistory.Rows.Clear();
            List<UpdateHistory> list = db.getUpdateHistorys();
            dgv_updateHistory.DataSource = list;
            //foreach (UpdateHistory updateHistory in list)
            //{
            //    DataGridViewRow dgvr = 
            //}
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

        #region 法规列表使用
        /// <summary>
        /// 下载选中项到本地库
        /// </summary>
        public void downloadSelectedLawToLocal()
        {
            if (Global.online)
            {
                List<Law> laws = new List<Law>();
                //修改数据库的law状态，使其在刷新下载列表时可以被显示
                for (int i = 1; i < flp_lawLibrary.Controls.Count; i++)
                {
                    var lawItem = flp_lawLibrary.Controls[i] as LawListItem;
                    if (lawItem.isChecked)
                    {
                        lawItem.lbl_downloadState.Text = "下载中……";
                        foreach (Law l in lawItem.laws)
                        {
                            l.downloadPercent = 0;
                            l.downloadDate = DateTime.Now.ToString("yyyy-MM-dd");
                            db.saveLaw(l);
                        }
                        laws.AddRange(lawItem.laws);
                    }
                }
                //刷新下载列表
                reloadDownloadList();
                //调用选中项在下载列表中对应项的下载方法
                startDownloadLaw(laws);
            }
            else
            {
                MessageBox.Show("离线状态下无法进行下载操作");
            }
        }
        /// <summary>
        /// 下载单项到本地库（法规列表使用）
        /// </summary>
        /// <param name="law"></param>
        public void downloadSelectedLawToLocal(List<Law> laws)
        {
            if (Global.online)
            {
                foreach (Law law in laws)
                {
                    //修改数据库的law状态，使其在刷新下载列表时可以被显示
                    law.downloadPercent = 0;
                    law.downloadDate = DateTime.Now.ToString("yyyy-MM-dd");
                    if (db.saveLaw(law))
                    {
                    }
                }
                //刷新下载列表
                reloadDownloadList();
                //调用选中项在下载列表中对应项的下载方法
                startDownloadLaw(laws);
            }
            else
            {
                MessageBox.Show("离线状态下无法进行下载操作");
            }
        }
        /// <summary>
        /// 从本地库移除选中项
        /// </summary>
        public void removeSelectedLocalLaw()
        {
            if (MessageBox.Show("确认移除选中项？", "从本地库移除后将无法离线浏览", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                for (int i = 1; i < flp_lawLibrary.Controls.Count; i++)
                {
                    var lawItem = flp_lawLibrary.Controls[i] as LawListItem;
                    if (lawItem.isChecked)
                        lawItem.lbl_downloadState.Text = "下载";
                    {
                        db.removeLawFromLocal(lawItem.law);
                    }
                }
            }
        }
        /// <summary>
        /// 从本地库移除单项
        /// </summary>
        /// <param name="law"></param>
        public void removeSelectedLocalLaw(Law law)
        {
            if (MessageBox.Show("确认移除此项？", "从本地库移除后将无法离线浏览", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.removeLawFromLocal(law);
            }
        }
        /// <summary>
        /// 清空本地库
        /// </summary>
        public void clearLocal()
        {
            if (MessageBox.Show("确认清空本地库？", "从本地库移除后将无法离线浏览", MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                db.clearLocal();
                loadLocalLawList();
            }
        }
        public void lawCheckBoxChange(bool value)
        {
            foreach (var item in flp_lawLibrary.Controls)
            {
                var lawItem = item as LawListItem;
                if (lawItem == null) continue;
                lawItem.checkChange(value);
            }
        }
        /// <summary>
        /// 设置列表项下载状态文字（法规、阅读历史、下载共用）
        /// </summary>
        /// <param name="law"></param>
        /// <param name="text"></param>
        public void setLawStateText(Type type, Law law, string text)
        {
            if (Global.online)
            {
                var controlsHost = new Control();
                if (type == typeof(LawListItem))
                {
                    controlsHost = flp_lawLibrary;
                }
                else if (type == typeof(ViewHistoryListItem))
                {
                    controlsHost = flp_viewHistory;
                }
                else if (type == typeof(DownloadListItem))
                {
                    controlsHost = flp_downloadTask;
                }
                foreach (Control c in controlsHost.Controls)
                {
                    if (c is BaseListItem)
                    {
                        var item = c as BaseListItem;
                        if (item.law.Id == law.Id)
                        {
                            item.setDownloadState(text);
                            return;
                        }
                    }
                }
            }
        }
        #endregion

        #region 下载列表使用
        public void downloadCheckBoxChange(bool value)
        {
            foreach (var item in flp_downloadTask.Controls)
            {
                var downloadListItem = item as DownloadListItem;
                if (downloadListItem == null) continue;
                downloadListItem.checkChange(value);
            }
        }
        public void updateLaw(Law law)
        {
            if(db.saveLaw(law))
            {
                reloadDownloadList();
                reloadLawList();
            }
        }
        /// <summary>
        /// 筛选全部任务、下载中、已完成
        /// </summary>
        /// <param name="state"></param>
        public void downloadPicker(string state)
        {
            if (state == "0")
            {
                foreach (Control item in flp_downloadTask.Controls)
                {
                    item.Show();
                }
            }
            else
            {
                foreach (Control item in flp_downloadTask.Controls)
                {
                    if (item is DownloadListItem)
                    {
                        if (((DownloadListItem)item).downloadState == state)
                        {
                            item.Show();
                        }
                        else
                        {
                            item.Hide();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 停止已选任务
        /// </summary>
        public void stopSelectedTask()
        {
            foreach (Control c in flp_downloadTask.Controls)
            {
                if (c is DownloadListItem)
                {
                    DownloadListItem item = c as DownloadListItem;
                    if (item.isChecked)
                    {
                        item.stopWork();
                    }
                }
            }
        }
        /// <summary>
        /// 恢复已选任务
        /// </summary>
        public void resumeSelectedTask()
        {
            foreach (Control c in flp_downloadTask.Controls)
            {
                if (c is DownloadListItem)
                {
                    DownloadListItem item = c as DownloadListItem;
                    if (item.isChecked)
                    {
                        item.continueWork();
                    }
                }
            }
        }
        /// <summary>
        /// 删除已选任务
        /// </summary>
        public void deleteSelectedTask()
        {
            bool hasChecked = false;
            foreach (Control c in flp_downloadTask.Controls)
            {
                if (c is DownloadListItem)
                {
                    DownloadListItem item = c as DownloadListItem;
                    if (item.isChecked)
                    {
                        hasChecked = true;
                        Law law = item.law;
                        if (law.isLocal == "1")
                        {
                            law.downloadPercent = null;
                            law.downloadNodeCount = null;
                        }
                        else
                        {
                            law.isLocal = "0";
                            law.downloadPercent = null;
                            law.downloadNodeCount = null;
                        }
                        db.saveLaw(law);
                    }
                }
                if (hasChecked)
                {
                    reloadDownloadList();
                    reloadLawList();
                }
            }
        }
        /// <summary>
        /// 清除已完成任务
        /// </summary>
        public void clearDownloadedTask()
        {
            bool hasDownloaded = false;
            foreach (Control c in flp_downloadTask.Controls)
            {
                if (c is DownloadListItem)
                {
                    DownloadListItem item = c as DownloadListItem;
                    Law law = item.law;
                    if (law.isLocal == "1" && law.downloadPercent == 100)
                    {
                        hasDownloaded = true;
                        law.downloadPercent = null;
                        db.saveLaw(law);
                    }
                }
            }
            if (hasDownloaded)
            {
                reloadDownloadList();
                reloadLawList();
            }
        }
        /// <summary>
        /// 供法规、阅读历史列表点击下载后，调用下载列表中相应对象的下载方法，通过law去下载列表中进行查找
        /// </summary>
        /// <param name="laws"></param>
        public void startDownloadLaw(List<Law> laws)
        {
            foreach (Control c in flp_downloadTask.Controls)
            {
                if (c is DownloadListItem)
                {
                    var item = c as DownloadListItem;
                    if (laws.FirstOrDefault(l => l.Id == item.law.Id)!=null)
                    {
                        item.continueWork();
                    }
                }
            }
        }
        #endregion

        #region 阅读历史列表使用
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
        /// <summary>
        /// 清空阅读历史
        /// </summary>
        public void clearHistory()
        {
            if (MessageBoxEx.Show("确认清空？", "清空阅读历史记录", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.clearHistory();
                loadViewHistoryList();
            }
        }
        /// <summary>
        /// 下载单项到本地库（阅读历史列表使用）
        /// </summary>
        /// <param name="law"></param>
        public void downloadSelectedLawToLocal(Law law)
        {
            if (Global.online)
            {
                //修改数据库的law状态，使其在刷新下载列表时可以被显示
                law.downloadPercent = 0;
                law.downloadDate = DateTime.Now.ToString("yyyy-MM-dd");
                if (db.saveLaw(law))
                {
                    //刷新下载列表
                    reloadDownloadList();
                    //调用选中项在下载列表中对应项的下载方法
                    startDownloadLaw(new List<Law>() { law });
                }
            }
            else
            {
                MessageBox.Show("离线状态下无法进行下载操作");
            }
        }
        #endregion

        #region 自动更新历史列表使用
        public void getUpdateHistoryList()
        {

        }
        #endregion

        /// <summary>
        /// 刷新（法规列表+筛选条件）
        /// </summary>
        private void reloadLawList()
        {
            loadLocalLawList();
            lawCheckBoxChange(lawFilter.ckb_selectAll.Checked); 
        }
        private void reloadHistoryList()
        {
            loadViewHistoryList();
        }
        /// <summary>
        /// 刷新(下载列表+筛选条件)
        /// </summary>
        private void reloadDownloadList()
        {
            loadDownLoadList();
            downloadCheckBoxChange(downloadFilter.ckb_selectAll.Checked);
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
        /// <summary>
        /// 窗体关闭时退出程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LibraryList_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                System.Environment.Exit(0);
            }
            catch { }
        }
    }
}
