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
                    nodeClass = getTitleButtonHtml("class",node.Id,node.title,node.nodeClass);
                }
                if (!string.IsNullOrEmpty(node.nodeDef))
                {
                    nodeDef = getTitleButtonHtml("define", node.Id, node.title, node.nodeDef);
                }
                if (!string.IsNullOrEmpty(node.nodeKey))
                {
                    nodeKey = getTitleButtonHtml("key", node.Id, node.title, node.nodeKey);
                }
                if (!string.IsNullOrEmpty(node.nodeRef))
                {
                    nodeRef = getTitleButtonHtml("ref", node.Id, node.title, node.nodeRef);
                }
                string btnTag = getContentButtonHtml("征", node.Id,"", convertGTLT(node.title));
                btnTag += getContentButtonHtml("评", node.Id,"", convertGTLT(node.title));
                string realContent = Global.online ? node.content : node.offlineContent.Replace("CurrentLoginUser", Global.user.Id).Replace("CurrentApplicationPath", Environment.CurrentDirectory);//将离线内容中的CurrentApplicationPath替换为应用程序执行路径，CurrentLoginUser替换为当前用户id，用于加载离线图片
                List<string> list = realContent.Split(new string[] { "</s>" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string part in list)
                {
                    //添加正文关系
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
                                string buttonHtml = getContentButtonHtml(kv[0], node.Id,selectedText,kv[1]);
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
                tag.OuterHTML= getContentButtonHtml("class", node.Id, node.title, node.nodeClass);
                tags.Add(tag);
            }
            if (string.IsNullOrEmpty(node.nodeDef) == false)
            {
                NodeTag tag = new NodeTag();
                tag.color = getColor("define");
                tag.TagType = getTypeCN("define");
                tag.TagNode = node.title;
                tag.TagContent = node.nodeDef;
                tag.OuterHTML = getContentButtonHtml("define", node.Id, node.title, node.nodeDef);
                tags.Add(tag);
            }
            if (string.IsNullOrEmpty(node.nodeKey) == false)
            {
                NodeTag tag = new NodeTag();
                tag.color = getColor("key");
                tag.TagType = getTypeCN("key");
                tag.TagNode = node.title;
                tag.TagContent = node.nodeKey;
                tag.OuterHTML = getContentButtonHtml("key", node.Id, node.title, node.nodeKey);
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
                tag.OuterHTML = getContentButtonHtml("ref", node.Id, node.title, node.nodeRef);
                tags.Add(tag);
            }
            //正文中的标签
            List<string> list = (Global.online? node.content:node.offlineContent.ToString()).Split(new string[] { "</s>" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string part in list)
            {
                if (part.Contains("<s data-obj="))
                {
                    //NodeTag tag = new NodeTag();
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
                        List<string> kv = dataObject.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        if (kv.Count > 1)
                        {
                            //tag.TagType = kv[0];
                            //tag.TagNode = selectedText;
                            //tag.color = getColor(tag.TagType);
                            //tag.TagType = getTypeCN(tag.TagType);
                            if (kv[0] == "ref")
                            {
                                //List<string> list1 = new List<string>();
                                //foreach (string partStr in kv[1].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                                //{
                                //    foreach (string subpartStr in partStr.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                                //    {
                                //        string lawId = string.Empty;
                                //        if (subpartStr.Contains("@"))
                                //        {
                                //            lawId = subpartStr.Substring(0, subpartStr.IndexOf("@"));
                                //        }
                                //        else
                                //        {
                                //            lawId = subpartStr;
                                //        }
                                //        Law law = db.getLawById(lawId);
                                //        if (law != null)
                                //        {
                                //            list1.Add(law.title);
                                //        }
                                //    }
                                //}
                                //tag.TagContent = string.Join(",", list1);
                                foreach (string partStr in kv[1].Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries))
                                {
                                    string typeStr = string.Empty;
                                    string contentStr = string.Empty;
                                    if (partStr.Contains("=="))//2018.12.28 分隔符替换为==
                                    {
                                        typeStr = partStr.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries)[0];
                                        contentStr = partStr.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries)[1];
                                    }
                                    foreach (string bookStr in contentStr.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries))
                                    {
                                        string bookId = string.Empty;
                                        string nodeId = string.Empty;
                                        if (bookStr.Contains("@"))//含bookid和nodeid
                                        {
                                            bookId = bookStr.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries)[0];
                                            Law law = db.getLawById(bookId);
                                            string nodeStr = bookStr.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries)[1];
                                            foreach (string nodeIdStr in nodeStr.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
                                            {
                                                nodeId = nodeIdStr;
                                                NodeTag tag = new NodeTag();
                                                if (typeStr.Contains("OUT"))//外部引用
                                                {
                                                    tag.color = getColor("ref");
                                                    tag.TagType = getTypeCN(typeStr);
                                                    tag.TagNode = Base64.DecodeBase64(bookId); //bookId;
                                                    tag.TagContent = Base64.DecodeBase64(nodeId); //nodeId;
                                                    tag.OuterHTML = getContentButtonHtml(kv[0], node.Id, selectedText, kv[1]);
                                                    tags.Add(tag);
                                                }
                                                else//内部引用
                                                {
                                                    CAAC_LawLibrary.Entity.Node tagNode = db.getNodeById(nodeId);
                                                    if (law != null) tag.TagContent = law.title;
                                                    if (tagNode != null)
                                                    {
                                                        tag.TagContent += node.title;
                                                        tag.TagNode = string.IsNullOrEmpty(tagNode.title) ? (string.IsNullOrEmpty(tagNode.nodeNumber)?tagNode.content:tagNode.nodeNumber) : tagNode.title;

                                                    }
                                                    else//如果node在数据库中查不到，说明用户没有下载或打开过该法规，此时去接口中查node信息
                                                    {
                                                        if (Global.online == true)
                                                        {
                                                            if (RemoteWorker.getNodeDetail(new List<string>() { nodeId }))
                                                            {
                                                                tagNode = db.getNodeById(nodeId);
                                                                if (tagNode != null)
                                                                {
                                                                    tag.TagContent += node.title;
                                                                    tag.TagNode = tagNode.title;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    tag.color = getColor("ref");
                                                    tag.TagType = getTypeCN(typeStr);
                                                    tag.OuterHTML = getContentButtonHtml(kv[0], node.Id, selectedText, kv[1]);
                                                    tags.Add(tag);
                                                }
                                            }
                                        }
                                        else//只含bookid
                                        {
                                            bookId = bookStr;
                                            Law law = db.getLawById(bookId);
                                            NodeTag tag = new NodeTag();
                                            if (law != null) { tag.TagContent = law.title; tag.TagNode = law.title; }
                                            tag.color = getColor("ref");
                                            tag.TagType = getTypeCN(typeStr);
                                            tag.OuterHTML = getContentButtonHtml(kv[0], node.Id, selectedText, kv[1]);
                                            tags.Add(tag);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                NodeTag tag = new NodeTag();
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
                                tag.OuterHTML = getContentButtonHtml(kv[0], node.Id,selectedText,kv[1]);
                                tags.Add(tag);
                            }
                        }
                    }
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
                case "ref":
                    return Color.LightBlue;
                default:
                    return Color.White;
            }
        }
        /// <summary>
        /// 根据标签类型返回HTML代码（供页面章节内容显示）
        /// </summary>
        /// <param name="tagType"></param>
        /// <param name="nodeId"></param>
        /// <param name="selectedText"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string getContentButtonHtml(string tagType,string nodeId,string selectedText,string text)
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
                case "refRELATED":
                    return " <input onclick=\"btnclick(" + nodeId + ",'依','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=依>";
                case "refPUNISH":
                    return " <input onclick=\"btnclick(" + nodeId + ",'罚','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=罚>";
                case "ref":
                    //return " <input onclick=\"btnclick(" + nodeId + ",'引','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #ffff00\" type=button value=引>";
                    return " <input onclick=\"btnclick(" + nodeId + ",'引','" + selectedText + "','" + text + "')\" " + getStyle(tagType) + " type=button value=引>";
                case "refCHUFA":
                    return " <input onclick=\"btnclick(" + nodeId + ",'政','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #ffff00\" type=button value=政>";
                case "refCHUFEN":
                    return " <input onclick=\"btnclick(" + nodeId + ",'律','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #ffa500\" type=button value=律>";
                case "refXINGZHENG":
                    return " <input onclick=\"btnclick(" + nodeId + ",'手','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #808080\" type=button value=手>";
                case "refZEREN":
                    return " <input onclick=\"btnclick(" + nodeId + ",'他','" + selectedText + "','" + text + "')\" sstyle=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=他>";
                case "refXINGYONG":
                    return " <input onclick=\"btnclick(" + nodeId + ",'信','" + selectedText + "','" + text + "')\" sstyle=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=信>";
                case "refXUKE":
                    return " <input onclick=\"btnclick(" + nodeId + ",'许','" + selectedText + "','" + text + "')\" sstyle=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=许>";
                case "refQIANGZHI":
                    return " <input onclick=\"btnclick(" + nodeId + ",'强','" + selectedText + "','" + text + "')\" sstyle=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=强 >";
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
        /// 根据标签类型返回HTML代码（供页面章节标题显示）
        /// </summary>
        /// <param name="tagType"></param>
        /// <param name="nodeId"></param>
        /// <param name="selectedText"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string getTitleButtonHtml(string tagType, string nodeId, string selectedText, string text)
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
                case "refRELATED":
                    return " <input onclick=\"btnclick(" + nodeId + ",'依','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=依>";
                case "refPUNISH":
                    return " <input onclick=\"btnclick(" + nodeId + ",'罚','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=罚>";
                case "ref":
                    //return " <input onclick=\"btnclick(" + nodeId + ",'引','" + selectedText + "','" + text + "')\" style=\"height: 25px; width: 25px; background-color: #ffff00\" type=button value=引>";
                    return " <input onclick=\"btnclick(" + nodeId + ",'引','" + selectedText + "','" + text + "')\" " + getStyle(tagType) + " type=button value=引>";
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
            {
                case "define":
                    return "定";
                case "key":
                    return "键";
                case "class":
                    return "类";
                case "refRELATED":
                    return "依";
                case "refPUNISH":
                    return "罚";
                case "refCHUFA":
                    return "政";
                case "refCHUFEN":
                    return "律";
                case "refXINGZHENG":
                    return "手";
                case "refZEREN":
                    return "他";
                case "refXINYONG":
                    return "信";
                case "refXUKE":
                    return "许";
                case "refQIANGZHI":
                    return "强";
                case "refOUTRELATED":
                    return "依";
                case "refOUTPUNISH":
                    return "罚";
                case "refOUTCHUFA":
                    return "政";
                case "refOUTCHUFEN":
                    return "律";
                case "refOUTXINGZHENG":
                    return "手";
                case "refOUTZEREN":
                    return "他";
                case "refOUTXINYONG":
                    return "信";
                case "refOUTXUKE":
                    return "许";
                case "refOUTQIANGZHI":
                    return "强";
                case "ref":
                    return "引";
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
                //case "y":

                //    break;
                //case "f":

                //    break;
                //case "z":

                //    break;
                //case "l":

                //    break;
                //case "s":

                //    break;
                //case "t":

                //    break;
                //case "x":

                //    break;
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

    /// <summary>
    /// 正文章节内容中的关系标签对象
    /// </summary>
    public class NodeContentTag
    {
        public List<InnerRef> innerRefList;
        public List<OutterRef> outterRefList;

        public NodeContentTag()
        {
            innerRefList = new List<InnerRef>();
            outterRefList = new List<OutterRef>();
        }

        /// <summary>
        /// 内部标签
        /// </summary>
        public class InnerRef
        {
            public string refType { get; set; }
            public string bookId { get; set; }
            public string nodeId { get; set; }
        }
        /// <summary>
        /// 外部标签
        /// </summary>
        public class OutterRef
        {
            public string refType { get; set; }
            public string title { get; set; }
            public string url { get; set; }
        }

        public NodeContentTag strToNodeContentTag(string str)
        {
            //string typeStr = string.Empty;
            //if (str.Contains("_"))
            //{
            //    typeStr = str.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[0];
            //    str = str.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries)[1];
            //}
            foreach (string part in str.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries))
            {
                string typeStr = string.Empty;
                string partStr = part;
                if (part.Contains("=="))//2018.12.28 分隔符替换为==
                {
                    typeStr = part.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    partStr= part.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries)[1];
                }
                foreach (string bookStr in partStr.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string bookId = string.Empty;
                    string nodeId = string.Empty;
                    if (bookStr.Contains("@"))//含bookid和nodeid
                    {
                        bookId = bookStr.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries)[0];
                        string nodeStr = bookStr.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries)[1];
                        foreach (string nodeIdStr in nodeStr.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            nodeId = nodeIdStr;
                            if (part.Contains("refOUT"))//外部资源
                            {
                                OutterRef outRef = new BLL.NodeContentTag.OutterRef()
                                {
                                    refType = typeStr,
                                    title = Base64.DecodeBase64(bookId),// bookId,
                                    url = Base64.DecodeBase64(nodeId), //nodeId
                                };
                                outterRefList.Add(outRef);
                            }
                            else//内部资源
                            {
                                InnerRef inRef = new BLL.NodeContentTag.InnerRef()
                                {
                                    refType = typeStr,
                                    bookId=bookId,
                                    nodeId=nodeId
                                };
                                innerRefList.Add(inRef);
                            }
                        }
                    }
                    else//只含bookid
                    {
                        bookId = bookStr;
                        if (part.Contains("refOUT"))//外部资源
                        {
                            OutterRef outRef = new BLL.NodeContentTag.OutterRef()
                            {
                                refType = typeStr,
                                title = Base64.DecodeBase64(bookId),//bookId,
                                url = string.Empty
                            };
                            outterRefList.Add(outRef);
                        }
                        else
                        {
                            InnerRef inRef = new BLL.NodeContentTag.InnerRef()
                            {
                                refType = typeStr,
                                bookId = bookId,
                                nodeId = string.Empty
                            };
                            innerRefList.Add(inRef);
                        }
                    }
                }
            }
            return this;
        }
    }


}
