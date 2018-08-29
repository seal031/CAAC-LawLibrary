using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
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
            loadRemoteLawList();
            loadLocalLawList();
            loadViewHistoryList();
            loadDownLoadList();
        }

        #region 加载3个列表
        private void loadRemoteLawList()
        {
            //todo读取远程法规库列表，并更新数据库
        }

        private void loadLocalLawList()
        {
            List<Law> list = db.getLaws(lawFilter.queryParam);
            foreach (Law law in list)
            {
                LawListItem item = new LawListItem();
                item.law = law;
                item.parentForm = this;
                flp_libraryList.Controls.Add(item);
            }
        }

        private void loadViewHistoryList()
        {
            List<ViewHistory> list = db.getViewHistory(viewHistoryFilter.queryParam);
            foreach (ViewHistory vh in list)
            {
                ViewHistoryListItem item = new ViewHistoryListItem();
                item.viewHistory = vh;
                flp_viewHistory.Controls.Add(item);
            }
        }

        private void loadDownLoadList()
        {
            List<Law> list = db.getLaws(downloadFilter.queryParam).Where(l=>l.downloadPercent!=null).ToList();
            foreach (Law law in list)
            {
                DownloadListItem item = new DownloadListItem();
                item.law = law;
                flp_downloadTask.Controls.Add(item);
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

        }
    }
}
