using CAAC_LawLibrary.BLL;
using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.UserControls;
using CAAC_LawLibrary.Utity;
using mshtml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace CAAC_LawLibrary
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]//COM+组件可见
    public partial class LawView : Form, IMessageFilter
    {
        public string lawId = string.Empty;
        public Law law;
        public List<Law> laws;
        private List<Node> nodes;
        private List<Comment> commentList;
        private List<NodeTag> tags;
        private DbHelper db = new DbHelper();
        public Form parentForm;
        private int commentShownCount = 0;
        bool bindState = false;
        RefPanel refPanel = new UserControls.RefPanel();

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pt);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

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
            Application.AddMessageFilter(this);
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
            //mh.UnHook();
            if (parentForm != null)
            {
                parentForm.Show();
                parentForm.WindowState = FormWindowState.Minimized;
                parentForm.WindowState = FormWindowState.Normal;
            }
        }
        /// <summary>
        /// 处理win32消息的具体方法
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 522)
                bt.CloseBalloon();
            return false;
        }

        private void LawView_Load(object sender, EventArgs e)
        {
            //mh = new Utity.MouseHook();
            //mh.SetHook();
            //mh.MouseMoveEvent += Mh_MouseMoveEvent;
            //this.Text += "-"+law.title + " " + law.version;
            lbl_title.Text= law.title + " " + law.version;
            lbl_welcome.Text += Global.user.Xm;
            if (law != null)
            {
                //如果在线，且未下载到本地，则从远程获取章节信息，并入库
                if (Global.online && "0" == law.isLocal)
                {
                    List<Node> nodes = RemoteWorker.getBookContent(law.lawId);//获取法规整体章节结构
                    RemoteWorker.getNodeDetail(nodes.Select(n => n.Id).ToList());//再获取每个章节的内容
                }
                nodes = db.getNodeByLawId(law.lawId);
                //绑定关系
                tags = NodeWorker.buildRelationFromNode(nodes);
                bindTagsToDGW();
                //绑定树结构
                string content = NodeWorker.buildFromNodeContext(NodeTree,nodes);
                //绑定法规内容
                wb.DocumentText = content;
                SetAutoWrap(true);
                if (Global.online)// && string.IsNullOrEmpty(law.isLocal))
                {
                    //远程获取评论
                    RemoteWorker.getOpinionList(law.lawId);
                    //加载评论
                    loadComment();
                }
                //加载文档信息
                lawInfo1.law = law;
                lawInfo1.parentForm = this.parentForm;
                lawInfo1.fillLawVersion(laws);
                lawInfo1.fillLawInfo();
                lawInfo1.bindState = true;
                //写入阅读历史
                ViewHistory history = new ViewHistory()
                {
                    Id = law.lawId,
                    LawID = law.lawId,
                    UserID = Global.user.Id,
                    ViewDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                if (db.saveHistory(history))
                {
                    ((LibraryList)parentForm).addHistory(history);
                }
            }
        }
        
        private void Mh_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            MessageBox.Show("");  
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

        public void loadComment(bool reload=false)
        {
            if (commentList == null||reload)
            {
                commentList = db.getComment(new Utity.QueryParam() { lawId = law.lawId });
            }
            if (Global.online == false)
            {
                Label label = new Label() { Text = "离线状态下无法显示评论",AutoSize=false,Dock=DockStyle.Top };
                flp_comment.Controls.Add(label);
                return;
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
                ci.lawView = this;
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
            string xiudingling = string.Empty;
            //QueryParam param = new QueryParam() { lastVersion = law.lastversion};
            //var effectiveDateList = db.getLaws(param).Select(l=>l.effectiveDate);
            //for (int i = 0; i < effectiveDateList.Count(); i++)
            //{
            //    if (i == 0)
            //    {
            //        xiudingling = DateTime.Parse(effectiveDateList.ElementAt(i)).ToString("yyyy年MM月dd日") + "发布";
            //    }
            //    else
            //    {
            //        xiudingling += DateTime.Parse(effectiveDateList.ElementAt(i)).ToString("yyyy年MM月dd日") + "第" + Global.NumberToChinese(i.ToString()) + "次修订";
            //    }
            //    xiudingling += Environment.NewLine;
            //}
            xiudingling = RemoteWorker.getHistory(law.lawId);
            xdls.setRtbText(xiudingling);
            //xdls.setRtbText(law.xiudingling);
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
        //点击树定位
        private void NodeTree_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            DevComponents.AdvTree.Node clickedNode = e.Node;
            Node node = clickedNode.Tag as Node;
            if (node != null)
            {
                //如果当前节点内容不为空，直接定位
                if (string.IsNullOrEmpty(node.content) ==false)
                {
                    findLocation(node.content);
                }
                else//否则查找内容不为空的第一个子节点，再定位
                {
                    foreach (DevComponents.AdvTree.Node subTreeNode in clickedNode.Nodes)
                    {
                        Node subNode = subTreeNode.Tag as Node;
                        if (string.IsNullOrEmpty(subNode.content) == false)
                        {
                            findLocation(subNode.content);
                        }
                        else
                        {
                            findLocation(subNode.title);
                        }
                        break;
                    }
                }
            }
        }
        //点击右侧列表定位
        private void dgw_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string outerHTML = dgw.Rows[e.RowIndex].Cells["OuterHTML"].Value.ToString();
            findLocation(outerHTML, true);
        }

        //private void addTagLabels()
        //{
        //    foreach (DevComponents.AdvTree.Node treeNode in NodeTree.Nodes)
        //    {
        //        if (treeNode.Tag != null)
        //        {
        //            Node node = treeNode.Tag as Node;
        //            addTagLabel(node);
        //        }
        //    }
        //}
        //private void addTagLabel(Node node)
        //{
        //    foreach (HtmlElement item in wb.Document.All)
        //    {
        //        if (item.InnerText != null)
        //        {
        //            string content = item.OuterHtml.ToLower();
        //            content = ClearChar(content);
        //            if (item.OuterHtml.ToLower().Contains(node.content))
        //            {
        //                Point point = GetPointTail(item);
        //                TagLabel tagLabel = new TagLabel();
        //                wb.Controls.Add(tagLabel);
        //                tagLabel.Location = point;

        //            }
        //        }
        //    }
        //}

        /// <summary>
        /// 文字定位
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isTag">是否来着右侧列表的定位</param>
        private void findLocation(string title,bool isTag=false)
        {
            string content = string.Empty;
            foreach (HtmlElement item in wb.Document.All)
            {
                if (item.InnerText != null)
                {
                    content = item.OuterHtml.ToLower();
                    content = ClearChar(content);
                    if (isTag)
                    {
                        if (item.OuterHtml.ToLower().Contains(title)||content.Contains(ClearChar(title).ToLower()))
                        {
                            Point point = GetPointHead(item);
                            wb.Document.Window.ScrollTo(0, point.Y-15);//滚动条至指定位置
                            //break;
                        }
                    }
                    else
                    {
                        if (title.IndexOf(content) == 0||content.Contains(title))
                        {
                            Point point = GetPointHead(item);
                            wb.Document.Window.ScrollTo(point.X, point.Y-15);//滚动条至指定位置
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
        //private Point GetPointTail(HtmlElement el)
        //{
        //    Point pos = new Point(el.OffsetRectangle.Right, el.OffsetRectangle.Top);
        //    //循环获取父级的坐标
        //    HtmlElement tempEl = el.OffsetParent;
        //    while (tempEl != null)
        //    {
        //        pos.X += tempEl.OffsetRectangle.Left;
        //        pos.Y += tempEl.OffsetRectangle.Top;
        //        tempEl = tempEl.OffsetParent;
        //    }
        //    return pos;
        //}

        private string ClearChar(string str)
        {
            str = str.Replace("\n", null);
            str = str.Replace("\r", null);
            str = str.Replace("&nbsp;", null);
            str = str.Replace(" ", null);
            str = str.Replace("'", null);
            str = str.Replace("\"", null);
            return str;
        }

        private void btn_suggest_Click(object sender, EventArgs e)
        {
            SuggestForm suggest = new SuggestForm();
            suggest.LawId = law.lawId;
            suggest.Show(this);
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
            string selectedText = paramList[2].ToString();
            string text = string.Empty;
            if (paramList.Length > 3)
            {
                if(paramList[3]!=null)
                    text = paramList[3].ToString();
            }

            List<string> list = new List<string>();
            switch (tagType)
            {
                case "征":
                    if (DateTime.Parse(law.expiryDate) > DateTime.Now)
                    {
                        AddNewSuggest suggest = new AddNewSuggest();
                        suggest.lawId = law.lawId;
                        suggest.nodeId = nodeId;
                        suggest.lbl_title.Text = selectedText;
                        suggest.ShowDialog(this);
                    }
                    else
                    {
                        MessageBox.Show("征询已截止，无法再提交征询意见");
                    }
                    break;
                case "评":
                    if (Global.online == false)
                    {
                        MessageBox.Show("离线状态下无法进行评论");
                        break;
                    }
                    AddNewComment comment = new AddNewComment();
                    comment.lawView = this;
                    comment.nodeId = nodeId;
                    comment.lawId = law.lawId;
                    comment.lbl_title.Text = selectedText;
                    comment.ShowDialog(this);
                    break;
                case "定":
                    foreach (string s in text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        int id;
                        if (int.TryParse(s, out id)) //text可能为逗号分隔的id，也有可能是逗号分隔的文本值
                        {
                            list.Add(Global.GetCodeValueById(s));
                        }
                        else
                        {
                            list.Add(s);
                        }
                    }
                    showBalloon("定义",selectedText, string.Join(" ", list), nodeId);
                    break;
                case "类":
                    foreach (string s in text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        int id;
                        if (int.TryParse(s, out id)) //text可能为逗号分隔的id，也有可能是逗号分隔的文本值
                        {
                            list.Add(Global.GetCodeValueById(s));
                        }
                        else
                        {
                            list.Add(s);
                        }
                    }
                    showBalloon("分类", selectedText, string.Join(" ", list), nodeId);
                    break;
                case "键":
                    foreach (string s in text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        int id;
                        if (int.TryParse(s, out id)) //text可能为逗号分隔的id，也有可能是逗号分隔的文本值
                        {
                            list.Add(Global.GetCodeValueById(s));
                        }
                        else
                        {
                            list.Add(s);
                        }
                    }
                    showBalloon("关键字", selectedText, string.Join(" ", list), nodeId);
                    break;
                case "依":
                    showBalloon("依赖", selectedText, "", nodeId);
                    break;
                case "罚":
                    showBalloon("罚则", selectedText, "", nodeId);
                    break;
                case "引":
                    showBalloon("引用", selectedText, text, nodeId);
                    break;
                case "政":
                    showBalloon("行政处罚", selectedText, "", nodeId);
                    break;
                case "律":
                    showBalloon("纪律处分", selectedText, "", nodeId);
                    break;
                case "手":
                    showBalloon("行政手段", selectedText, "", nodeId);
                    break;
                case "他":
                    showBalloon("其他责任", selectedText, "", nodeId);
                    break;
                case "信":
                    showBalloon("信用手段", selectedText, "", nodeId);
                    break;
                default:
                    break;
            }

        }

        private void showBalloon(string caption,string selectedText, string _text,string nodeId)
        {
            string text = "选中文字：" + selectedText + Environment.NewLine + caption + "：" + _text;
            if (caption == "引用")
            {
                //bt.SetBalloonText(wb, "<input type=\"text\" onclick=\"alert(1)\" name=\"firstname\">");
                refPanel.setDb(db);
                refPanel.setParentForm(this);
                refPanel.setText(_text);
                wb.Controls.Add(refPanel);
                Point p1 = Control.MousePosition;
                p1.Offset(-lawInfo1.Width, -pl_title.Height);
                refPanel.Location = p1;
                refPanel.Show();
                return;
            }
            bt.SetBalloonText(wb, text);
            bt.SetBalloonCaption(wb, caption);

            Point p = Control.MousePosition;
            bt.ShowBalloon(wb);
            p.Offset(-bt.BalloonControl.TipOffset, bt.BalloonControl.TipLength - 100);
            bt.BalloonControl.Location = p;
        }

        int findIndex = 0;
        int findCount = 0;
        private void btn_search_Click(object sender, EventArgs e)
        {
            //searchWord(txt_keyword.Text.Trim(),-1);
            findCount = getFindCount();
            if (findCount > 0)
            {
                lbl_findCount.Visible = true;
                btn_p.Visible = true;
                btn_n.Visible = true;
                btn_n.Enabled = true;
                btn_p.Enabled = false;
                lbl_findCount.Text = findIndex + "/" + findCount;
            }
            else
            {
                lbl_findCount.Visible = false;
                btn_p.Visible = false;
                btn_n.Visible = false;
            }
        }

        private int getFindCount()
        {
            string str = wb.Document.Body.InnerText;
            string substring = txt_keyword.Text.Trim();
            if (string.IsNullOrEmpty(substring))
            {
                return 0;
            }
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }
            MessageBox.Show("未找到相关文字");
            return 0;
        }

        private void searchWord(string keyword,int findIndex)
        {
            IHTMLTxtRange searchRange = null;
            IHTMLDocument2 document = (IHTMLDocument2)wb.Document.DomDocument; 
            if (keyword == "") return;  
            if (document.selection.type.ToLower() != "none")
            {
                searchRange = (IHTMLTxtRange) document.selection.createRange();
                searchRange.collapse(true);
                searchRange.moveStart("character", 1);
            }
            else
            {
                IHTMLBodyElement body = (IHTMLBodyElement) document.body;
                searchRange = (IHTMLTxtRange) body.createTextRange();
            } 
            if (searchRange.findText(keyword, findIndex, 0))// 如果找到了，就选取（高亮显示）该关键字；否则弹出消息。 
            {
                searchRange.select();
            }
            else
            {
                MessageBox.Show("已搜索到文档结尾。");
            } 
        }

        private void btn_n_Click(object sender, EventArgs e)
        {
            searchWord(txt_keyword.Text.Trim(), 1);
            btn_p.Enabled = true;
            if (findIndex == findCount)
            {
                btn_n.Enabled = false;
            }
            else
            {
                findIndex++;
                btn_n.Enabled = true;
            }
            lbl_findCount.Text = findIndex + "/" + findCount;
        }

        private void btn_p_Click(object sender, EventArgs e)
        {
            btn_n.Enabled = true;
            searchWord(txt_keyword.Text.Trim(), -1);
            if (findIndex == 1)
            {
                btn_p.Enabled = false;
            }
            else
            {
                findIndex--;
                btn_p.Enabled = true;
            }
            lbl_findCount.Text = findIndex + "/" + findCount;
        }

        private void btn_item_relation_Click(object sender, EventArgs e)
        {

        }

        private void LawView_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }
    }
}
