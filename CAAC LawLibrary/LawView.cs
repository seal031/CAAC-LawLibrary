using System;
using System.Collections;
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
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace CAAC_LawLibrary
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]//COM+组件可见
    public partial class LawView : Form
    {
        public string lawId = string.Empty;
        public Law law;
        private List<Node> nodes;
        private List<Comment> commentList;
        private List<NodeTag> tags;
        private DbHelper db = new DbHelper();
        public Form parentForm;
        private int commentShownCount = 0;
        bool bindState = false;

        public LawView()
        {
            InitializeComponent();
            cbb_tag.DataSource = new BindingSource(Global.tag, null); ;
            cbb_tag.DisplayMember = "Value";
            cbb_tag.ValueMember = "Key";
            bindState = true;
            this.WindowState = FormWindowState.Maximized;//打开时最大化
            setFlpTopDownOnly(flp_comment);
            wb.DocumentCompleted += Wb_DocumentCompleted;
            wb.ObjectForScripting = this;
        }

        private void Wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //绑定小标签
            //addTagLabels();
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
                nodes = db.getNodeByLawId(law.Id);
                //绑定关系
                tags = NodeWorker.buildRelationFromNode(nodes);
                bindTagsToDGW();
                //绑定树结构
                string content = NodeWorker.buildFromNodeContext(NodeTree,nodes);
                //绑定法规内容
                wb.DocumentText = content;
                SetAutoWrap(true);
                //远程获取评论
                RemoteWorker.getOpinionList(law.Id);
                //加载评论
                if (Global.online && string.IsNullOrEmpty(law.isLocal))
                {
                    loadComment();
                }
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

        private void bindTagsToDGW(string tagType = "全")
        {
            if (tags != null)
            {
                var list = from t in tags
                           where tagType == "全" ? 1 == 1 : t.TagType == tagType
                           select t;
                dgw.Rows.Clear();
                foreach (NodeTag tag in list)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    int index = dgw.Rows.Add(row);
                    dgw.Rows[index].Cells["tagType"].Value = tag.TagType;
                    dgw.Rows[index].Cells["tagNode"].Value = tag.TagNode;
                    dgw.Rows[index].Cells["tagContent"].Value = tag.TagContent;
                    dgw.Rows[index].Cells["OuterHTML"].Value = tag.OuterHTML;
                    dgw.Rows[index].Cells["tagType"].Style.BackColor = tag.color;
                }
            }
        }

        private void NodeTree_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            DevComponents.AdvTree.Node clickedNode = e.Node;
            Node node = clickedNode.Tag as Node;
            if (node != null)
            {
                //如果当前节点内容不为空，直接定位
                if (node.content != string.Empty)
                {
                    findLocation(node.content);
                }
                else//否则查找内容不为空的第一个子节点，再定位
                {
                    foreach (DevComponents.AdvTree.Node subTreeNode in clickedNode.Nodes)
                    {
                        Node subNode = subTreeNode.Tag as Node;
                        if (subNode.content != string.Empty)
                        {
                            findLocation(subNode.content);
                            break;
                        }
                    }
                }
            }
        }

        private void addTagLabels()
        {
            foreach (DevComponents.AdvTree.Node treeNode in NodeTree.Nodes)
            {
                if (treeNode.Tag != null)
                {
                    Node node = treeNode.Tag as Node;
                    addTagLabel(node);
                }
            }
        }
        private void addTagLabel(Node node)
        {
            foreach (HtmlElement item in wb.Document.All)
            {
                if (item.InnerText != null)
                {
                    string content = item.OuterHtml.ToLower();
                    content = ClearChar(content);
                    if (item.OuterHtml.ToLower().Contains(node.content))
                    {
                        Point point = GetPointTail(item);
                        TagLabel tagLabel = new TagLabel();
                        wb.Controls.Add(tagLabel);
                        tagLabel.Location = point;
                        
                    }
                }
            }
        }

        /// <summary>
        /// 文字定位
        /// </summary>
        /// <param name="title"></param>
        private void findLocation(string title,bool isTag=false)
        {
            foreach (HtmlElement item in wb.Document.All)
            {
                if (item.InnerText != null)
                {
                    string content = item.OuterHtml.ToLower();
                    content = ClearChar(content);
                    if (isTag)
                    {
                        if (item.OuterHtml.ToLower().Contains(title))
                        {
                            Point point = GetPointHead(item);
                            wb.Document.Window.ScrollTo(0, point.Y);//滚动条至指定位置
                            //break;
                        }
                    }
                    else
                    {
                        if (title.IndexOf(content) == 0)
                        {
                            Point point = GetPointHead(item);
                            wb.Document.Window.ScrollTo(point.X, point.Y);//滚动条至指定位置
                            //break;
                        }
                    }
                }
            }
        }
        private Point GetPointHead(HtmlElement el)
        {
            Point pos = new Point(el.OffsetRectangle.Left, el.OffsetRectangle.Top);
            //循环获取父级的坐标
            HtmlElement tempEl = el.OffsetParent;
            while (tempEl != null)
            {
                pos.X += tempEl.OffsetRectangle.Left;
                pos.Y += tempEl.OffsetRectangle.Top;
                tempEl = tempEl.OffsetParent;
            }
            return pos;
        }
        private Point GetPointTail(HtmlElement el)
        {
            Point pos = new Point(el.OffsetRectangle.Right, el.OffsetRectangle.Top);
            //循环获取父级的坐标
            HtmlElement tempEl = el.OffsetParent;
            while (tempEl != null)
            {
                pos.X += tempEl.OffsetRectangle.Left;
                pos.Y += tempEl.OffsetRectangle.Top;
                tempEl = tempEl.OffsetParent;
            }
            return pos;
        }

        private string ClearChar(string str)
        {
            str = str.Replace("\n", null);
            str = str.Replace("\r", null);
            str = str.Replace("&nbsp;", null);
            str = str.Replace(" ", null);
            return str;
        }

        private void btn_suggest_Click(object sender, EventArgs e)
        {
            SuggestForm suggest = new SuggestForm();
            suggest.LawId = law.Id;
            suggest.Show(this);
        }

        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string outerHTML = dgw.Rows[e.RowIndex].Cells["OuterHTML"].Value.ToString();
            findLocation(outerHTML,true);
        }

        public void SetAutoWrap(bool value)
        {
            mshtml.HTMLDocument doc = this.wb.Document.DomDocument as mshtml.HTMLDocument;
            if (doc != null)
            {
                mshtml.HTMLBody body = doc.body as mshtml.HTMLBody;
                if (body != null)
                { body.noWrap = !value; }
            }
        }

        private void cbb_tag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindState)
            {
                var selectedTag = (DictionaryEntry)(cbb_tag.SelectedItem);
                bindTagsToDGW(tagType: selectedTag.Key.ToString());
            }
        }

        public void CallFunction(params object[] paramList)
        {
            string nodeId = paramList[0].ToString();
            string tagType = paramList[1].ToString();

            bt.SetBalloonText(wb,nodeId);
            bt.SetBalloonCaption(wb, tagType);

            Point p = Control.MousePosition;
            p.Offset(-bt.BalloonControl.TipOffset, bt.BalloonControl.TipLength + 4);
            bt.BalloonControl.Location = p;
        }
    }
}
