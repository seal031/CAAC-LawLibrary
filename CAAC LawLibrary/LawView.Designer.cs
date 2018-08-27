﻿namespace CAAC_LawLibrary
{
    partial class LawView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LawView));
            this.pl_title = new System.Windows.Forms.Panel();
            this.btn_suggest = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_keyword = new System.Windows.Forms.TextBox();
            this.btn_return = new System.Windows.Forms.Button();
            this.btn_logout = new System.Windows.Forms.Button();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.np_left = new DevComponents.DotNetBar.NavigationPane();
            this.npp_docInfo = new DevComponents.DotNetBar.NavigationPanePanel();
            this.lawInfo1 = new CAAC_LawLibrary.UserControls.LawInfo();
            this.btn_item_docInfo = new DevComponents.DotNetBar.ButtonItem();
            this.npp_tree = new DevComponents.DotNetBar.NavigationPanePanel();
            this.btn_item_tree = new DevComponents.DotNetBar.ButtonItem();
            this.np_right = new DevComponents.DotNetBar.NavigationPane();
            this.navigationPanePanel2 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.btn_item_comment = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel1 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.btn_item_relation = new DevComponents.DotNetBar.ButtonItem();
            this.pn_main_document = new DevComponents.DotNetBar.PanelEx();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.LawTree = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.pl_title.SuspendLayout();
            this.np_left.SuspendLayout();
            this.npp_docInfo.SuspendLayout();
            this.npp_tree.SuspendLayout();
            this.np_right.SuspendLayout();
            this.pn_main_document.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LawTree)).BeginInit();
            this.SuspendLayout();
            // 
            // pl_title
            // 
            this.pl_title.Controls.Add(this.btn_suggest);
            this.pl_title.Controls.Add(this.btn_search);
            this.pl_title.Controls.Add(this.txt_keyword);
            this.pl_title.Controls.Add(this.btn_return);
            this.pl_title.Controls.Add(this.btn_logout);
            this.pl_title.Controls.Add(this.lbl_welcome);
            this.pl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_title.Location = new System.Drawing.Point(0, 0);
            this.pl_title.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pl_title.Name = "pl_title";
            this.pl_title.Size = new System.Drawing.Size(1367, 49);
            this.pl_title.TabIndex = 1;
            // 
            // btn_suggest
            // 
            this.btn_suggest.Location = new System.Drawing.Point(836, 14);
            this.btn_suggest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_suggest.Name = "btn_suggest";
            this.btn_suggest.Size = new System.Drawing.Size(101, 22);
            this.btn_suggest.TabIndex = 5;
            this.btn_suggest.Text = "意见征询";
            this.btn_suggest.UseVisualStyleBackColor = true;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(612, 12);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 22);
            this.btn_search.TabIndex = 4;
            this.btn_search.Text = "查找";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // txt_keyword
            // 
            this.txt_keyword.Location = new System.Drawing.Point(267, 12);
            this.txt_keyword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_keyword.Name = "txt_keyword";
            this.txt_keyword.Size = new System.Drawing.Size(324, 25);
            this.txt_keyword.TabIndex = 3;
            // 
            // btn_return
            // 
            this.btn_return.Location = new System.Drawing.Point(28, 12);
            this.btn_return.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_return.Name = "btn_return";
            this.btn_return.Size = new System.Drawing.Size(107, 22);
            this.btn_return.TabIndex = 2;
            this.btn_return.Text = "返回库";
            this.btn_return.UseVisualStyleBackColor = true;
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(1251, 10);
            this.btn_logout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(100, 29);
            this.btn_logout.TabIndex = 1;
            this.btn_logout.Text = "退出";
            this.btn_logout.UseVisualStyleBackColor = true;
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.Location = new System.Drawing.Point(1048, 16);
            this.lbl_welcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(52, 15);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "您好：";
            // 
            // np_left
            // 
            this.np_left.CanCollapse = true;
            this.np_left.ConfigureItemVisible = false;
            this.np_left.Controls.Add(this.npp_tree);
            this.np_left.Controls.Add(this.npp_docInfo);
            this.np_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.np_left.ItemPaddingBottom = 2;
            this.np_left.ItemPaddingTop = 2;
            this.np_left.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_item_tree,
            this.btn_item_docInfo});
            this.np_left.Location = new System.Drawing.Point(0, 49);
            this.np_left.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.np_left.Name = "np_left";
            this.np_left.NavigationBarHeight = 35;
            this.np_left.Padding = new System.Windows.Forms.Padding(1);
            this.np_left.Size = new System.Drawing.Size(267, 919);
            this.np_left.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.np_left.TabIndex = 2;
            // 
            // 
            // 
            this.np_left.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.np_left.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.np_left.TitlePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.np_left.TitlePanel.Name = "panelTitle";
            this.np_left.TitlePanel.Size = new System.Drawing.Size(267, 125);
            this.np_left.TitlePanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            this.np_left.TitlePanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(56)))), ((int)(((byte)(148)))));
            this.np_left.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.np_left.TitlePanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.np_left.TitlePanel.Style.ForeColor.Color = System.Drawing.Color.White;
            this.np_left.TitlePanel.TabIndex = 0;
            this.np_left.TitlePanel.Text = "目录";
            // 
            // npp_docInfo
            // 
            this.npp_docInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.npp_docInfo.Controls.Add(this.lawInfo1);
            this.npp_docInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.npp_docInfo.Location = new System.Drawing.Point(1, 1);
            this.npp_docInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.npp_docInfo.Name = "npp_docInfo";
            this.npp_docInfo.ParentItem = this.btn_item_docInfo;
            this.npp_docInfo.Size = new System.Drawing.Size(265, 917);
            this.npp_docInfo.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.npp_docInfo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.npp_docInfo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.npp_docInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.npp_docInfo.Style.GradientAngle = 90;
            this.npp_docInfo.TabIndex = 3;
            // 
            // lawInfo1
            // 
            this.lawInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lawInfo1.Location = new System.Drawing.Point(0, 0);
            this.lawInfo1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lawInfo1.Name = "lawInfo1";
            this.lawInfo1.Size = new System.Drawing.Size(265, 917);
            this.lawInfo1.TabIndex = 0;
            // 
            // btn_item_docInfo
            // 
            this.btn_item_docInfo.Image = ((System.Drawing.Image)(resources.GetObject("btn_item_docInfo.Image")));
            this.btn_item_docInfo.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btn_item_docInfo.Name = "btn_item_docInfo";
            this.btn_item_docInfo.OptionGroup = "navBar";
            this.btn_item_docInfo.Text = "文档信息";
            // 
            // npp_tree
            // 
            this.npp_tree.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.npp_tree.Controls.Add(this.LawTree);
            this.npp_tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.npp_tree.Location = new System.Drawing.Point(1, 1);
            this.npp_tree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.npp_tree.Name = "npp_tree";
            this.npp_tree.ParentItem = this.btn_item_tree;
            this.npp_tree.Size = new System.Drawing.Size(265, 882);
            this.npp_tree.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.npp_tree.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.npp_tree.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.npp_tree.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.npp_tree.Style.GradientAngle = 90;
            this.npp_tree.TabIndex = 2;
            // 
            // btn_item_tree
            // 
            this.btn_item_tree.Checked = true;
            this.btn_item_tree.Image = ((System.Drawing.Image)(resources.GetObject("btn_item_tree.Image")));
            this.btn_item_tree.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btn_item_tree.Name = "btn_item_tree";
            this.btn_item_tree.OptionGroup = "navBar";
            this.btn_item_tree.Text = "目录";
            // 
            // np_right
            // 
            this.np_right.CanCollapse = true;
            this.np_right.ConfigureItemVisible = false;
            this.np_right.Controls.Add(this.navigationPanePanel2);
            this.np_right.Controls.Add(this.navigationPanePanel1);
            this.np_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.np_right.ItemPaddingBottom = 2;
            this.np_right.ItemPaddingTop = 2;
            this.np_right.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_item_relation,
            this.btn_item_comment});
            this.np_right.Location = new System.Drawing.Point(1100, 49);
            this.np_right.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.np_right.Name = "np_right";
            this.np_right.NavigationBarHeight = 35;
            this.np_right.Padding = new System.Windows.Forms.Padding(1);
            this.np_right.Size = new System.Drawing.Size(267, 919);
            this.np_right.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.np_right.TabIndex = 3;
            // 
            // 
            // 
            this.np_right.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.np_right.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.np_right.TitlePanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.np_right.TitlePanel.Name = "panelTitle";
            this.np_right.TitlePanel.Size = new System.Drawing.Size(267, 125);
            this.np_right.TitlePanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            this.np_right.TitlePanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(56)))), ((int)(((byte)(148)))));
            this.np_right.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.np_right.TitlePanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.np_right.TitlePanel.Style.ForeColor.Color = System.Drawing.Color.White;
            this.np_right.TitlePanel.TabIndex = 0;
            this.np_right.TitlePanel.Text = "评论";
            // 
            // navigationPanePanel2
            // 
            this.navigationPanePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPanePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel2.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.navigationPanePanel2.Name = "navigationPanePanel2";
            this.navigationPanePanel2.ParentItem = this.btn_item_comment;
            this.navigationPanePanel2.Size = new System.Drawing.Size(265, 882);
            this.navigationPanePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel2.Style.GradientAngle = 90;
            this.navigationPanePanel2.TabIndex = 3;
            // 
            // btn_item_comment
            // 
            this.btn_item_comment.Checked = true;
            this.btn_item_comment.Image = ((System.Drawing.Image)(resources.GetObject("btn_item_comment.Image")));
            this.btn_item_comment.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btn_item_comment.Name = "btn_item_comment";
            this.btn_item_comment.OptionGroup = "navBar";
            this.btn_item_comment.Text = "评论";
            // 
            // navigationPanePanel1
            // 
            this.navigationPanePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel1.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.navigationPanePanel1.Name = "navigationPanePanel1";
            this.navigationPanePanel1.ParentItem = this.btn_item_relation;
            this.navigationPanePanel1.Size = new System.Drawing.Size(265, 882);
            this.navigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel1.Style.GradientAngle = 90;
            this.navigationPanePanel1.TabIndex = 2;
            // 
            // btn_item_relation
            // 
            this.btn_item_relation.Image = ((System.Drawing.Image)(resources.GetObject("btn_item_relation.Image")));
            this.btn_item_relation.ImageFixedSize = new System.Drawing.Size(16, 16);
            this.btn_item_relation.Name = "btn_item_relation";
            this.btn_item_relation.OptionGroup = "navBar";
            this.btn_item_relation.Text = "关系";
            // 
            // pn_main_document
            // 
            this.pn_main_document.AllowDrop = true;
            this.pn_main_document.CanvasColor = System.Drawing.SystemColors.Control;
            this.pn_main_document.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pn_main_document.Controls.Add(this.wb);
            this.pn_main_document.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_main_document.Location = new System.Drawing.Point(267, 49);
            this.pn_main_document.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pn_main_document.Name = "pn_main_document";
            this.pn_main_document.Size = new System.Drawing.Size(833, 919);
            this.pn_main_document.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pn_main_document.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pn_main_document.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pn_main_document.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pn_main_document.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pn_main_document.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pn_main_document.Style.GradientAngle = 90;
            this.pn_main_document.TabIndex = 4;
            // 
            // wb
            // 
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.wb.MinimumSize = new System.Drawing.Size(27, 25);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(833, 919);
            this.wb.TabIndex = 0;
            // 
            // LawTree
            // 
            this.LawTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.LawTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.LawTree.BackgroundStyle.Class = "TreeBorderKey";
            this.LawTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LawTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LawTree.Location = new System.Drawing.Point(0, 0);
            this.LawTree.Name = "LawTree";
            this.LawTree.NodesConnector = this.nodeConnector1;
            this.LawTree.NodeStyle = this.elementStyle1;
            this.LawTree.PathSeparator = ";";
            this.LawTree.Size = new System.Drawing.Size(265, 882);
            this.LawTree.Styles.Add(this.elementStyle1);
            this.LawTree.TabIndex = 0;
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Class = "";
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // LawView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 968);
            this.Controls.Add(this.pn_main_document);
            this.Controls.Add(this.np_right);
            this.Controls.Add(this.np_left);
            this.Controls.Add(this.pl_title);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LawView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "法规详情";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LawView_FormClosed);
            this.Load += new System.EventHandler(this.LawView_Load);
            this.pl_title.ResumeLayout(false);
            this.pl_title.PerformLayout();
            this.np_left.ResumeLayout(false);
            this.npp_docInfo.ResumeLayout(false);
            this.npp_tree.ResumeLayout(false);
            this.np_right.ResumeLayout(false);
            this.pn_main_document.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LawTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_title;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label lbl_welcome;
        private DevComponents.DotNetBar.NavigationPane np_left;
        private DevComponents.DotNetBar.NavigationPanePanel npp_tree;
        private DevComponents.DotNetBar.ButtonItem btn_item_tree;
        private DevComponents.DotNetBar.NavigationPanePanel npp_docInfo;
        private DevComponents.DotNetBar.ButtonItem btn_item_docInfo;
        private DevComponents.DotNetBar.NavigationPane np_right;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanel1;
        private DevComponents.DotNetBar.ButtonItem btn_item_relation;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanel2;
        private DevComponents.DotNetBar.ButtonItem btn_item_comment;
        private DevComponents.DotNetBar.PanelEx pn_main_document;
        private System.Windows.Forms.Button btn_return;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_keyword;
        private System.Windows.Forms.Button btn_suggest;
        private UserControls.LawInfo lawInfo1;
        private System.Windows.Forms.WebBrowser wb;
        private DevComponents.AdvTree.AdvTree LawTree;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
    }
}