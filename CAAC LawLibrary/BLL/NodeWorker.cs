﻿using CAAC_LawLibrary.Entity;
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
        public static string buildFromNodeContext(AdvTree NodeTree,List<CAAC_LawLibrary.Entity.Node> nodes)
        {
            StringBuilder contentBuilder = new StringBuilder();
            contentBuilder.Append("<html><head><script>function btnclick(nodeId,tagLabelType){window.external.CallFunction(nodeId,tagLabelType);}</script></head><body>");
            DevComponents.AdvTree.Node perTreeNode=null;
            foreach (CAAC_LawLibrary.Entity.Node node in nodes)
            {
                DevComponents.AdvTree.Node treeNode = new DevComponents.AdvTree.Node();
                treeNode.Text = node.title;
                treeNode.Tag = node;
                string btnTag = getButtonHtml("征", node.Id);
                btnTag += getButtonHtml("评", node.Id);
                List<string> list = node.content.Split(new string[] { "</s>" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string part in list)
                {
                    if (part.Contains("<s data-obj="))
                    {
                        string s = part.Substring(part.IndexOf("<s data-obj="));
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
                                string buttonHtml = getButtonHtml(kv[0], node.Id);
                                node.content = node.content.Replace(s, buttonHtml);
                            }
                        }
                    }
                }

                contentBuilder.Append(node.title + btnTag + Environment.NewLine + node.content + Environment.NewLine);
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
                            perTreeNode.Parent.Nodes.Add(treeNode);
                        }
                        else
                        {
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
            List<string> list = node.content.Split(new string[] { "</s>" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string part in list)
            {
                if (part.Contains("<s data-obj="))
                {
                    NodeTag tag = new NodeTag();
                    string s = part.Substring(part.IndexOf("<s data-obj="));
                    tag.TagContent = s.Substring(s.IndexOf(">") + 1);
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
                            tag.TagNode = kv[1];
                            tag.color = getColor(tag.TagType);
                            tag.TagType = getTypeCN(tag.TagType);
                            tag.OuterHTML = getButtonHtml(kv[0], node.Id);
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
        private static string getButtonHtml(string tagType,string nodeId)
        {
            switch (tagType)
            {
                case "define":
                    return " <input onclick=\"btnclick(" + nodeId + ",'定')\" style=\"height: 25px; width: 25px; background-color: #ffff00\" type=button value=定>";
                case "key":
                    return " <input onclick=\"btnclick(" + nodeId + ",'键')\" style=\"height: 25px; width: 25px; background-color: #ffa500\" type=button value=键>";
                case "class":
                    return " <input onclick=\"btnclick(" + nodeId + ",'类')\" style=\"height: 25px; width: 25px; background-color: #808080\" type=button value=类>";
                case "":
                    return " <input onclick=\"btnclick(" + nodeId + ",'键')\" sstyle=\"height: 25px; width: 25px; background-color: #0000ff\" type=button value=键>";
                case "评":
                    return " <input type=\"button\" value=\"评\" style=\"background-color:#FFFFFF;width:25px;height:25px\" onclick=btnclick(" + nodeId + ",'评')>";
                case "征":
                    return " <input type=\"button\" value=\"征\" style=\"background-color:#FFFFFF;width:25px;height:25px\" onclick=btnclick(" + nodeId + ",'征')>";
                default:
                    return "";
            }
        }
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
                case "":
                    return "依";
                default:
                    return "";
            }
        }
    }

    public class NodeTag
    {
        public string TagType { get; set; }

        public string TagNode { get; set; }

        public string TagContent { get; set; }

        public string OuterHTML { get; set; }

        public Color color { get; set; }
    }
}
