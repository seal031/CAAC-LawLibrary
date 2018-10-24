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
    public partial class BaseListItem : UserControl
    {
        public Law law;

        public delegate void setLableTextDelegate(string text);
        public setLableTextDelegate setLabelTextEvent;

        public BaseListItem()
        {
            InitializeComponent();
            setLabelTextEvent = new setLableTextDelegate(setDownloadState);
        }


        /// <summary>
        /// 设置下载状态文字
        /// </summary>
        /// <param name="text"></param>
        public void setDownloadState(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(setLabelTextEvent,new object[] { text});
            }
            else
            {
                lbl_downloadState.Text = text;
            }
        }
    }
}
