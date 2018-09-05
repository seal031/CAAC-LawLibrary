using CAAC_LawLibrary.Entity;
using DevComponents.AdvTree;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAAC_LawLibrary.BLL
{
    public class NodeWorker
    {
        public static string buildFromNodeContext(AdvTree NodeTree,List<CAAC_LawLibrary.Entity.Node> nodes)
        {
            string content = string.Empty;
            DevComponents.AdvTree.Node perTreeNode=null;
            foreach (CAAC_LawLibrary.Entity.Node node in nodes)
            {
                DevComponents.AdvTree.Node treeNode = new DevComponents.AdvTree.Node();
                treeNode.Text = node.title;
                treeNode.Tag = node;
                content += node.content + Environment.NewLine;
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
            return content;
        }

    }
}
