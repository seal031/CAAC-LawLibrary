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
        private List<Comment> commentList;
        private DbHelper db = new DbHelper();
        public Form parentForm;
        private int commentShownCount = 0;

        public LawView()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;//打开时最大化
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
        }

        private void LawView_Load(object sender, EventArgs e)
        {
            if (law != null)
            {
                //如果在线，且未下载到本地，则从远程获取章节信息，并入库
                if (Global.online&&string.IsNullOrEmpty(law.isLocal))
                {
                    RemoteWorker.getBookContent(law.Id);
                }
                //绑定树结构
                nodes = db.getNodeByLawId(law.Id);
                string content = NodeWorker.buildFromNodeContext(NodeTree,nodes);
                //绑定法规内容
                wb.DocumentText = content+"<button id='button' value='button' title='button' onclick='function(){alert('a')}'><button/>";
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

        //private void loadRemoteNodes()
        //{
        //    Tuple<List<Node>,List<Node>> tupleNodes = RemoteWorker.getBookContent(law.Id);
        //    List<Node> nodes = tupleNodes.Item1;
        //    List<Node> details = tupleNodes.Item2;
        //    foreach (Node node in nodes)
        //    {
        //        DevComponents.AdvTree.Node treeNode = new DevComponents.AdvTree.Node();
        //        treeNode.Text = node.title;
        //        treeNode.Tag = node;
        //        treeNode.Image = global::CAAC_LawLibrary.Properties.Resources.Folder;
        //        NodeTree.Nodes.Add(treeNode);
        //        var detail = details.FirstOrDefault(d => d.Id == node.Id);
        //        if (detail != null)
        //        {

        //        }
        //    }
        //}

        private void loadComment()
        {
            if (commentList == null)
            {
                commentList = db.getComment(new Utity.QueryParam() { lawId = law.Id });
            }
            int remainCommentCount = commentList.Count - commentShownCount;
            List<Comment> currentCommentList=null;
            if (remainCommentCount >= 5)
            {
                currentCommentList = commentList.GetRange(commentShownCount, 5);
            }
            else
            {
                currentCommentList = commentList.GetRange(commentShownCount, remainCommentCount);
            }
            commentShownCount += currentCommentList.Count;
            if (currentCommentList.Count < 5) lbl_loadMore.Text = "没有更多评论了";
            foreach (Comment comment in currentCommentList)
            {
                CommentItem ci = new UserControls.CommentItem();
                ci.comment = comment;
                ci.fillContent();
                flp_comment.Controls.Add(ci);
            }
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

        /// <summary>
        /// 加载更多评论按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_loadMore_Click(object sender, EventArgs e)
        {
            loadComment();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            XiudingLiShi xdls = new CAAC_LawLibrary.XiudingLiShi();
            xdls.setRtbText(law.xiudingling);
            xdls.Show(this);
        }
    }
}
