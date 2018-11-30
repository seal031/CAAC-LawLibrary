using CAAC_LawLibrary.DAL;
using CAAC_LawLibrary.Entity;
using CAAC_LawLibrary.Utity;
using DevComponents.AdvTree;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAAC_LawLibrary.BLL
{
    public class NodeWorker
    {
        static DbHelper db = new DbHelper();

        public static string buildFromNodeContext(AdvTree NodeTree,List<CAAC_LawLibrary.Entity.Node> nodes)
        {
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append("<html><head>");
            contentBuilder.Append("<script>function btnclick(nodeId,tagLabelType,selectedText,text){window.external.CallFunction(nodeId,tagLabelType,selectedText,text);}</script>");
            contentBuilder.Append("<link rel=\"stylesheet\" href=\"" + Environment.CurrentDirectory + "\\CSS\\mystyle.css\">");
            contentBuilder.Append("</head><body>");
            DevComponents.AdvTree.Node perTreeNode=null;
            foreach (CAAC_LawLibrary.Entity.Node node in nodes)
            {
                DevComponents.AdvTree.Node treeNode = new DevComponents.AdvTree.Node();
                treeNode.Text = node.nodeNumber == string.Empty ? node.title : node.nodeNumber + "." + node.title;
                treeNode.Tag = node;
                //添加标题关系
                string nodeClass = string.Empty;
                string nodeDef = string.Empty;
                string nodeKey = string.Empty;
                string nodeRef = string.Empty;
                if (!string.IsNullOrEmpty(node.nodeClass))
                {
                    nodeClass = getButtonHtml("class",node.Id,node.title,node.nodeClass);
                }
                if (!string.IsNullOrEmpty(node.nodeDef))
                {
                    nodeDef = getButtonHtml("define", node.Id, node.title, node.nodeDef);
                }
                if (!string.IsNullOrEmpty(node.nodeKey))
                {
                    nodeKey = getButtonHtml("key", node.Id, node.title, node.nodeKey);
                }
                if (!string.IsNullOrEmpty(node.nodeRef))
                {
                    nodeRef = getButtonHtml("ref", node.Id, node.title, node.nodeRef);
                }
                string btnTag = getButtonHtml("征", node.Id,"", convertGTLT(node.title));
                btnTag += getButtonHtml("评", node.Id,"", convertGTLT(node.title));
                string realContent = Global.online ? node.content : node.offlineContent.Replace("CurrentLoginUser", Global.user.Id).Replace("CurrentApplicationPath", Environment.CurrentDirectory);//将离线内容中的CurrentApplicationPath替换为应用程序执行路径，CurrentLoginUser替换为当前用户id，用于加载离线图片
                List<string> list = realContent.Split(new string[] { "</s>" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string part in list)
                {
                    if (part.Contains("<s data-obj="))
                    {
                        string s = part.Substring(part.IndexOf("<s data-obj="));
                        string selectedText = s.Substring(s.IndexOf(">")+1);
                        //string stringToReplace = s.Substring(0,s.IndexOf(">") + 1);
                        int sIndex = s.IndexOf("\"") + 1;
                        int eIndex = s.LastIndexOf("\"");
                        string dataObject = string.Empty;
                        if (eIndex > sIndex)
                        {
                            dataObject = s.Substring(sIndex, eIndex - sIndex);
                            List<string> kv = dataObject.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                            if (kv.Count > 1)
                            {
                                string buttonHtml = getButtonHtml(kv[0], node.Id,selectedText,kv[1]);
                                realContent = realContent.Replace(s, buttonHtml);
                            }
                        }
                    }
                }

                if (node.nodeNumber == string.Empty && node.title == string.Empty)//如果标题和标题号都为空，就直接显示正文
                {
                    contentBuilder.Append(realContent);
                }
                else
                {
                    contentBuilder.Append("<p style=\"text - align: center; \" "+getStyle(node.nodeLevel)+">");//按照节点级别添加样式
                    contentBuilder.Append((node.nodeNumber == string.Empty ? convertGTLT(node.title) : node.nodeNumber + "." + convertGTLT(node.title)) + nodeClass + nodeDef + nodeKey + nodeRef + btnTag + Environment.NewLine + realContent + Environment.NewLine);
                    contentBuilder.Append("</p>");
                }


                if (perTreeNode == null)//第一个节点
                {
                    treeNode.Image = global::CAAC_LawLibrary.Properties.Resources.Folder;
                    NodeTree.Nodes.Add(treeNode);
                }
                else
                {
                    if (node.nodeLevel == 1)//如果是一级节点，直接加到树，图标为文件夹
                    {
                        treeNode.Image = global::CAAC_LawLibrary.Properties.Resources.Folder;
                        NodeTree.Nodes.Add(treeNode);
                    }
                    else
                    {
                        //如果当前节点比上一节点nodeLevel大，说明是上一节点的子节点，此时将当前节点加入上一节点的子节点，且将上一节点图标设为文件夹
                        if (node.nodeLevel > (perTreeNode.Tag as CAAC_LawLibrary.Entity.Node).nodeLevel)
                        {
                            treeNode.Image = global::CAAC_LawLibrary.Properties.Resources.Document;
                            perTreeNode.Nodes.Add(treeNode);
                            perTreeNode.Image = global::CAAC_LawLibrary.Properties.Resources.Folder;
                        }
                        //如果当前节点和上一节点nodeLevel相同，说明是上一节点的兄弟节点，此时将当前节点加入上一节点的父节点
                        else if (node.nodeLevel == (perTreeNode.Tag as CAAC_LawLibrary.Entity.Node).nodeLevel)
                        {
                            treeNode.Image = global::CAAC_LawLibrary.Properties.Resources.Document;
                            perTreeNode.Parent.Nodes.Add(treeNode);
                        }
                        else
                        {
                            treeNode.Image = global::CAAC_LawLibrary.Properties.Resources.Document;
                            perTreeNode.Parent.Parent.Nodes.Add(treeNode);
                        }
                    }
                }

                perTreeNode = treeNode;
            }
            contentBuilder.Append("</body>");
            string content = contentBuilder.ToString();
            return content;
        }

        public static string convertGTLT(string str)
        {
            return str.Replace(">", "&gt").Replace("<", "&lt");
        }

        public static List<NodeTag> buildRelationFromNode(List<CAAC_LawLibrary.Entity.Node> nodes)
        {
            List<NodeTag> tags = new List<NodeTag>();
            foreach (CAAC_LawLibrary.Entity.Node node in nodes)
            {
                tags = tags.Concat(pickTag(node)).ToList();
            }
            return tags;
        }

        private static List<NodeTag> pickTag(CAAC_LawLibrary.Entity.Node node)
        {
            List<NodeTag> tags = new List<NodeTag>();
            //标题中的标签
            if (string.IsNullOrEmpty(node.nodeClass) == false)
            {
                NodeTag tag = new NodeTag();
                tag.color = getColor("class");
                tag.TagType = getTypeCN("class");
                tag.TagNode = node.title;
                tag.TagContent = node.nodeClass;
                tag.OuterHTML= getButtonHtml("class", node.Id, node.title, node.nodeClass);
                tags.Add(tag);
            }
            if (string.IsNullOrEmpty(node.nodeDef) == false)
            {
                NodeTag tag = new NodeTag();
                tag.color = getColor("define");
                tag.TagType = getTypeCN("define");
                tag.TagNode = node.title;
                tag.TagContent = node.nodeDef;
                tag.OuterHTML = getButtonHtml("define", node.Id, node.title, node.nodeDef);
                tags.Add(tag);
            }
            if (string.IsNullOrEmpty(node.nodeKey) == false)
            {
                NodeTag tag = new NodeTag();
                tag.color = getColor("key");
                tag.TagType = getTypeCN("key");
                tag.TagNode = node.title;
                tag.TagContent = node.nodeKey;
                tag.OuterHTML = getButtonHtml("key", node.Id, node.title, node.nodeKey);
                tags.Add(tag);
            }
            if (string.IsNullOrEmpty(node.nodeRef) == false)
            {
                NodeTag tag = new NodeTag();
                tag.color = getColor("ref");
                tag.TagType = getTypeCN("ref");
                tag.TagNode = node.title;
                //tag.TagContent = node.nodeRef;
                List<string> tagContentList = new List<string>();
                foreach (string str in node.nodeRef.Split(new string[] { ";"}, StringSplitOptions.RemoveEmptyEntries))
                {
                    List<string> idsList = str.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (idsList.Count > 0)
                    {
                        string lawId = idsList[0];
                        Law law = db.getLawById(lawId);
                        if (law != null)
                        {
                            tagContentList.Add(law.title);
                        }
                    }
                }
                tag.TagContent = string.Join(Environment.NewLine, tagContentList);
                tag.OuterHTML = getButtonHtml("ref", node.Id, node.title, node.nodeRef);
                tags.Add(tag);
            }
            //正文中的标签
            List<string> list = (Global.online? node.content:node.offlineContent.ToString()).Split(new string[] { "</s>" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string part in list)
            {
                if (part.Contains("<s data-obj="))
                {
                    NodeTag tag = new NodeTag();
                    string s = part.Substring(part.IndexOf("<s data-obj="));
                    string selectedText = s.Substring(s.IndexOf(">") + 1);
                    //tag.TagContent = s.Substring(s.IndexOf(">") + 1);
                    //tag.OuterHTML = s;
                    int sIndex=s.IndexOf("\"")+1;
                    int eIndex=s.LastIndexOf("\"");
                    string dataObject = string.Empty;
                    if(eIndex>sIndex)
                    {
                       dataObject= s.Substring(sIndex, eIndex - sIndex);
                        List<string> kv = dataObject.Split(new string[] {"-" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        if (kv.Count > 1)
                        {
                            tag.TagType = kv[0];
                            tag.TagNode = selectedText;
                            tag.color = getColor(tag.TagType);
                            tag.TagType = getTypeCN(tag.TagType);
                            if (kv[0] == "ref")
                            {
                                List<string> list1 = new List<string>();
                                foreach (string partStr in kv[1].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    foreach (string subpartStr in partStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                                    {
                                        string lawId = string.Empty;
                                        if (subpartStr.Contains("@"))
                                        {
                                            lawId = subpartStr.Substring(0, subpartStr.IndexOf("@"));
                                        }
                                        else
                                        {
                                            lawId = subpartStr;
                                        }
                                        Law law = db.getLawById(lawId);
                                        if (law != null)
                                        {
                                            list1.Add(law.title);
                                        }
                                    }
                                }
                                tag.TagContent = string.Join(",", list1);
                            }
                            else
                            {
                                List<string> list2 = new List<string>();
                                foreach (string s1 in kv[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    int id;
                                    if (int.TryParse(s1, out id)) //text可能为逗号分隔的id，也有可能是逗号分隔的文本值
                                    {
                                        list2.Add(Global.GetCodeValueById(s1));
                                    }
                                    else
                                    {
                                        list2.Add(s1);
                                    }
                                }
                                tag.TagContent = string.Join(",",list2);
                            }
                            tag.OuterHTML = getButtonHtml(kv[0], node.Id,selectedText,kv[1]);
                        }
                    }

                    tags.Add(tag);
                }
            }
            return tags;
        }

        private static Color getColor(string tagType)
        {
            switch (tagType)
            {
                case "define":
                    return Color.Yellow;
                case "key":
                    return Color.Orange;
                case "class":
                    return Color.Gray;
                case "":
                    return Color.Blue;
                default:
                    return Color.White;
            }
        }
        /// <summary>
        /// 根据标签类型返回HTML代码（供页面正文显示）
        /// </summary>
        /// <param name="tagType"></param>
        /// <param name="nodeId"></param>
        /// <param name="selectedText"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string getButtonHtml(string tagType,string nodeId,string selectedText,string text)
        {
            switch (tagType)
            {//todo
                case "define":
                    //return " <input onclick=\"btnclick(" + nodeId + ",'定','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #ffff00\" type=button value=定>";
                    return " <input onclick=\"btnclick(" + nodeId + ",'定','" + selectedText + "','" + text + "')\" " + getStyle("def") + " type=button value=定>";
                case "key":
                    //return " <input onclick=\"btnclick(" + nodeId + ",'键','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #ffa500\" type=button value=键>";
                    return " <input onclick=\"btnclick(" + nodeId + ",'键','" + selectedText + "','" + text + "')\" " + getStyle(tagType) + " type=button value=键>";
                case "class":
                    //return " <input onclick=\"btnclick(" + nodeId + ",'类','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #808080\" type=button value=类>";
                    return " <input onclick=\"btnclick(" + nodeId + ",'类','" + selectedText + "','" + text + "')\" " + getStyle(tagType) + " type=button value=类>";
                case "y":
                    return " <input onclick=\"btnclick(" + nodeId + ",'依','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=依>";
                case "f":
                    return " <input onclick=\"btnclick(" + nodeId + ",'罚','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=罚>";
                case "ref":
                    //return " <input onclick=\"btnclick(" + nodeId + ",'引','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #ffff00\" type=button value=引>";
                    return " <input onclick=\"btnclick(" + nodeId + ",'引','" + selectedText + "','" + text + "')\" " + getStyle(tagType) + " type=button value=引>";
                case "z":
                    return " <input onclick=\"btnclick(" + nodeId + ",'政','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #ffff00\" type=button value=政>";
                case "l":
                    return " <input onclick=\"btnclick(" + nodeId + ",'律','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #ffa500\" type=button value=律>";
                case "s":
                    return " <input onclick=\"btnclick(" + nodeId + ",'手','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #808080\" type=button value=手>";
                case "t":
                    return " <input onclick=\"btnclick(" + nodeId + ",'他','" + selectedText + "','" + text + "')\" sstyle=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=他>";
                case "x":
                    return " <input onclick=\"btnclick(" + nodeId + ",'信','" + selectedText + "','" + text + "')\" sstyle=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=信>";
                case "评":
                    //return " <input type=\"button\" value=\"评\" style=\"background-color:#FFFFFF;width:25px;height:25px\" onclick=btnclick(" + nodeId + ",'评','" + text + "')>";
                    return " <input type=\"button\" value=\"评\" " + getStyle(tagType) + " onclick=btnclick(" + nodeId + ",'评','" + text + "')>";
                case "征":
                    //return " <input type=\"button\" value=\"征\" style=\"background-color:#FFFFFF;width:25px;height:25px\" onclick=btnclick(" + nodeId + ",'征','" + text + "')>";
                    return " <input type=\"button\" value=\"征\" " + getStyle(tagType) + " onclick=btnclick(" + nodeId + ",'征','" + text + "')>";
                default:
                    return "";
            }
        }
        /// <summary>
        /// 根据标签类型返回相应文字（供右侧关系列表显示）
        /// </summary>
        /// <param name="tagType"></param>
        /// <returns></returns>
        private static string getTypeCN(string tagType)
        {
            switch (tagType)
            {//todo
                case "define":
                    return "定";
                case "key":
                    return "键";
                case "class":
                    return "类";
                case "":
                    return "依";
                case "ref":
                    return "引";
                case "z":
                    return "政";
                case "l":
                    return "律";
                case "s":
                    return "手";
                case "t":
                    return "他";
                case "x":
                    return "信";
                default:
                    return "";
            }
        }

        private static string getStyle(int nodeLevel)
        {
            string styleName = string.Empty;
            styleName = "level" + nodeLevel;
            return "class=\"" + styleName + "\"";
        }
        private static string getStyle(string type)
        {
            string styleName = string.Empty;
            switch (type)
            {
                case "评":
                    styleName = "ping";
                    break;
                case "征":
                    styleName = "zheng";
                    break;
                case "def":
                    styleName = "ding";
                    break;
                case "class":
                    styleName = "lei";
                    break;
                case "key":
                    styleName = "jian";
                    break;
                case "ref":
                    styleName = "yin";
                    break;
                case "y":

                    break;
                case "f":

                    break;
                case "z":

                    break;
                case "l":

                    break;
                case "s":

                    break;
                case "t":

                    break;
                case "x":

                    break;
            }
            return "onmousemove=\"this.className = '" + styleName + "_out'\" onmouseout=\"this.className = '" + styleName + "'\"" + " class=\"" + styleName + "\"";
        }
    }

    /// <summary>
    /// 右侧的关系标签对象
    /// </summary>
    public class NodeTag
    {
        public string TagType { get; set; }

        public string TagNode { get; set; }

        public string TagContent { get; set; }

        public string OuterHTML { get; set; }

        public Color color { get; set; }
    }
}
