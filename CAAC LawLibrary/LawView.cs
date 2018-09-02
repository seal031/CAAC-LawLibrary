using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAAC_LawLibrary.BLL;
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.UserControls;
using CAAC_LawLibrary.Utity;

namespace CAAC_LawLibrary
{
    public partial class LawView : Form
    {
        public string lawId = string.Empty;
        public Law law;
        private List<Node> nodes;
        private DbHelper db = new DbHelper();
        public Form parentForm;

        public LawView()
        {
            InitializeComponent();
            setFlpTopDownOnly(flp_comment);
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

        private void LawView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.Show();
            }
            //System.Environment.Exit(0);
        }

        private void LawView_Load(object sender, EventArgs e)
        {
            if (law != null)
            {
                //绑定树结构
                nodes = db.getNodeByLawId(law.Id);
                wb.DocumentText = NodeWorker.buildFromNodeContext(nodes);
                //远程获取评论
                RemoteWorker.getOpinionList(law.Id);
                //加载评论
                loadComment();
                //加载文档信息
                lawInfo1.law = law;
                lawInfo1.fillLawInfo();
                //写入阅读历史
                ViewHistory history = new ViewHistory()
                {
                    Id = law.Id,
                    LawID = law.Id,
                    UserID = Global.user.Id,
                    ViewDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                if (db.saveHistory(history))
                {
                    ((LibraryList)parentForm).addHistory(history);
                }
            }
        }

        private void loadComment()
        {
            List<Comment> commentList = db.getComment(new Utity.QueryParam() { lawId = law.Id });
            foreach (Comment comment in commentList)
            {
                CommentItem ci = new UserControls.CommentItem();
                ci.comment = comment;
                ci.fillContent();
                flp_comment.Controls.Add(ci);
            }
        }


        private void bindingTree()
        {

        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.Show();
                this.Close();
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            ((LibraryList)parentForm).logout();
        }
    }
}
