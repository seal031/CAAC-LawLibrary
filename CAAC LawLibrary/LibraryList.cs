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
        public LibraryList()
        {
            InitializeComponent();
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

        }

        private void loadRemoteLawList()
        {
            //todo读取远程法规库列表，并更新数据库
        }

        private void loadLocalLawList()
        {

        }

        private void loadViewHistoryList()
        {

        }

        private void loadDownLoadList()
        {

        }
    }
}
