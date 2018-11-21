namespace CAAC_LawLibrary
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pl_title = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.btn_n = new System.Windows.Forms.Button();
            this.lbl_findCount = new System.Windows.Forms.Label();
            this.btn_p = new System.Windows.Forms.Button();
            this.btn_suggest = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_keyword = new System.Windows.Forms.TextBox();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.np_left = new DevComponents.DotNetBar.NavigationPane();
            this.npp_docInfo = new DevComponents.DotNetBar.NavigationPanePanel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btn_item_docInfo = new DevComponents.DotNetBar.ButtonItem();
            this.npp_tree = new DevComponents.DotNetBar.NavigationPanePanel();
            this.NodeTree = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.btn_item_tree = new DevComponents.DotNetBar.ButtonItem();
            this.np_right = new DevComponents.DotNetBar.NavigationPane();
            this.navigationPanePanel1 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.dgw = new System.Windows.Forms.DataGridView();
            this.tagType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagNode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OuterHTML = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbb_tag = new System.Windows.Forms.ComboBox();
            this.btn_item_relation = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel2 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.lbl_loadMore = new System.Windows.Forms.Label();
            this.flp_comment = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_item_comment = new DevComponents.DotNetBar.ButtonItem();
            this.pn_main_document = new DevComponents.DotNetBar.PanelEx();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.bt = new DevComponents.DotNetBar.BalloonTip();
            this.lawInfo1 = new CAAC_LawLibrary.UserControls.LawInfo();
            this.pl_title.SuspendLayout();
            this.np_left.SuspendLayout();
            this.npp_docInfo.SuspendLayout();
            this.npp_tree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodeTree)).BeginInit();
            this.np_right.SuspendLayout();
            this.navigationPanePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).BeginInit();
            this.navigationPanePanel2.SuspendLayout();
            this.pn_main_document.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_title
            // 
            this.pl_title.BackColor = System.Drawing.SystemColors.Highlight;
            this.pl_title.Controls.Add(this.lbl_title);
            this.pl_title.Controls.Add(this.btn_n);
            this.pl_title.Controls.Add(this.lbl_findCount);
            this.pl_title.Controls.Add(this.btn_p);
            this.pl_title.Controls.Add(this.btn_suggest);
            this.pl_title.Controls.Add(this.btn_search);
            this.pl_title.Controls.Add(this.txt_keyword);
            this.pl_title.Controls.Add(this.lbl_welcome);
            this.pl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_title.Location = new System.Drawing.Point(0, 0);
            this.pl_title.Margin = new System.Windows.Forms.Padding(4);
            this.pl_title.Name = "pl_title";
            this.pl_title.Size = new System.Drawing.Size(1367, 49);
            this.pl_title.TabIndex = 1;
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(12, 10);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(777, 29);
            this.lbl_title.TabIndex = 9;
            this.lbl_title.Text = "label1";
            // 
            // btn_n
            // 
            this.btn_n.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_n.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_n.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_n.Location = new System.Drawing.Point(1219, 13);
            this.btn_n.Name = "btn_n";
            this.btn_n.Size = new System.Drawing.Size(22, 25);
            this.btn_n.TabIndex = 8;
            this.btn_n.Text = ">";
            this.btn_n.UseVisualStyleBackColor = false;
            this.btn_n.Visible = false;
            this.btn_n.Click += new System.EventHandler(this.btn_n_Click);
            // 
            // lbl_findCount
            // 
            this.lbl_findCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_findCount.AutoSize = true;
            this.lbl_findCount.Location = new System.Drawing.Point(1171, 17);
            this.lbl_findCount.Name = "lbl_findCount";
            this.lbl_findCount.Size = new System.Drawing.Size(0, 15);
            this.lbl_findCount.TabIndex = 7;
            this.lbl_findCount.Visible = false;
            // 
            // btn_p
            // 
            this.btn_p.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_p.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_p.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_p.Location = new System.Drawing.Point(1144, 13);
            this.btn_p.Name = "btn_p";
            this.btn_p.Size = new System.Drawing.Size(22, 25);
            this.btn_p.TabIndex = 6;
            this.btn_p.Text = "<";
            this.btn_p.UseVisualStyleBackColor = false;
            this.btn_p.Visible = false;
            this.btn_p.Click += new System.EventHandler(this.btn_p_Click);
            // 
            // btn_suggest
            // 
            this.btn_suggest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_suggest.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_suggest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_suggest.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_suggest.Location = new System.Drawing.Point(1252, 10);
            this.btn_suggest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_suggest.Name = "btn_suggest";
            this.btn_suggest.Size = new System.Drawing.Size(101, 30);
            this.btn_suggest.TabIndex = 5;
            this.btn_suggest.Text = "意见征询";
            this.btn_suggest.UseVisualStyleBackColor = false;
            this.btn_suggest.Click += new System.EventHandler(this.btn_suggest_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_search.Location = new System.Drawing.Point(1062, 11);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 30);
            this.btn_search.TabIndex = 4;
            this.btn_search.Text = "查找";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_keyword
            // 
            this.txt_keyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_keyword.Location = new System.Drawing.Point(722, 13);
            this.txt_keyword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_keyword.Name = "txt_keyword";
            this.txt_keyword.Size = new System.Drawing.Size(335, 25);
            this.txt_keyword.TabIndex = 3;
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.Location = new System.Drawing.Point(1163, 16);
            this.lbl_welcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(52, 15);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "您好：";
            this.lbl_welcome.Visible = false;
            // 
            // np_left
            // 
            this.np_left.CanCollapse = true;
            this.np_left.ConfigureAddRemoveVisible = false;
            this.np_left.ConfigureItemVisible = false;
            this.np_left.Controls.Add(this.npp_docInfo);
            this.np_left.Controls.Add(this.npp_tree);
            this.np_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.np_left.ItemPaddingBottom = 2;
            this.np_left.ItemPaddingTop = 2;
            this.np_left.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_item_tree,
            this.btn_item_docInfo});
            this.np_left.Location = new System.Drawing.Point(0, 49);
            this.np_left.Name = "np_left";
            this.np_left.NavigationBarHeight = 121;
            this.np_left.Padding = new System.Windows.Forms.Padding(1);
            this.np_left.Size = new System.Drawing.Size(280, 919);
            this.np_left.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.np_left.TabIndex = 2;
            // 
            // 
            // 
            this.np_left.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.np_left.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.np_left.TitlePanel.Margin = new System.Windows.Forms.Padding(4);
            this.np_left.TitlePanel.Name = "panelTitle";
            this.np_left.TitlePanel.Size = new System.Drawing.Size(267, 30);
            this.np_left.TitlePanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            this.np_left.TitlePanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(56)))), ((int)(((byte)(148)))));
            this.np_left.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.np_left.TitlePanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.np_left.TitlePanel.Style.ForeColor.Color = System.Drawing.Color.White;
            this.np_left.TitlePanel.TabIndex = 0;
            this.np_left.TitlePanel.Text = "文档信息";
            // 
            // npp_docInfo
            // 
            this.npp_docInfo.AutoScroll = true;
            this.npp_docInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.npp_docInfo.Controls.Add(this.linkLabel1);
            this.npp_docInfo.Controls.Add(this.lawInfo1);
            this.npp_docInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.npp_docInfo.Location = new System.Drawing.Point(1, 1);
            this.npp_docInfo.Margin = new System.Windows.Forms.Padding(4);
            this.npp_docInfo.Name = "npp_docInfo";
            this.npp_docInfo.ParentItem = this.btn_item_docInfo;
            this.npp_docInfo.Size = new System.Drawing.Size(278, 796);
            this.npp_docInfo.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.npp_docInfo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.npp_docInfo.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.npp_docInfo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.npp_docInfo.Style.GradientAngle = 90;
            this.npp_docInfo.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(150, 116);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(114, 20);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "查看修订历史页";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btn_item_docInfo
            // 
            this.btn_item_docInfo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_item_docInfo.Checked = true;
            this.btn_item_docInfo.Image = ((System.Drawing.Image)(resources.GetObject("btn_item_docInfo.Image")));
            this.btn_item_docInfo.Name = "btn_item_docInfo";
            this.btn_item_docInfo.OptionGroup = "navBar";
            this.btn_item_docInfo.PopupSide = DevComponents.DotNetBar.ePopupSide.Top;
            this.btn_item_docInfo.RibbonWordWrap = false;
            this.btn_item_docInfo.Text = "文档信息";
            // 
            // npp_tree
            // 
            this.npp_tree.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.npp_tree.Controls.Add(this.NodeTree);
            this.npp_tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.npp_tree.Location = new System.Drawing.Point(1, 1);
            this.npp_tree.Margin = new System.Windows.Forms.Padding(4);
            this.npp_tree.Name = "npp_tree";
            this.npp_tree.ParentItem = this.btn_item_tree;
            this.npp_tree.Size = new System.Drawing.Size(278, 796);
            this.npp_tree.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.npp_tree.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.npp_tree.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.npp_tree.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.npp_tree.Style.GradientAngle = 90;
            this.npp_tree.TabIndex = 2;
            // 
            // NodeTree
            // 
            this.NodeTree.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.NodeTree.AllowDrop = true;
            this.NodeTree.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.NodeTree.BackgroundStyle.Class = "TreeBorderKey";
            this.NodeTree.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.NodeTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeTree.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.NodeTree.Location = new System.Drawing.Point(0, 0);
            this.NodeTree.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NodeTree.Name = "NodeTree";
            this.NodeTree.NodesConnector = this.nodeConnector1;
            this.NodeTree.NodeStyle = this.elementStyle1;
            this.NodeTree.PathSeparator = ";";
            this.NodeTree.Size = new System.Drawing.Size(278, 796);
            this.NodeTree.Styles.Add(this.elementStyle1);
            this.NodeTree.TabIndex = 0;
            this.NodeTree.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.NodeTree_NodeClick);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Class = "";
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // btn_item_tree
            // 
            this.btn_item_tree.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_item_tree.Image = ((System.Drawing.Image)(resources.GetObject("btn_item_tree.Image")));
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
            this.np_right.Location = new System.Drawing.Point(1082, 49);
            this.np_right.Margin = new System.Windows.Forms.Padding(4);
            this.np_right.Name = "np_right";
            this.np_right.NavigationBarHeight = 121;
            this.np_right.Padding = new System.Windows.Forms.Padding(1);
            this.np_right.Size = new System.Drawing.Size(285, 919);
            this.np_right.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.np_right.TabIndex = 3;
            this.np_right.TitleButtonAlignment = DevComponents.DotNetBar.eTitleButtonAlignment.Left;
            // 
            // 
            // 
            this.np_right.TitlePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.np_right.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.np_right.TitlePanel.Margin = new System.Windows.Forms.Padding(4);
            this.np_right.TitlePanel.Name = "panelTitle";
            this.np_right.TitlePanel.Size = new System.Drawing.Size(267, 30);
            this.np_right.TitlePanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            this.np_right.TitlePanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(56)))), ((int)(((byte)(148)))));
            this.np_right.TitlePanel.Style.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.np_right.TitlePanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.np_right.TitlePanel.Style.ForeColor.Color = System.Drawing.Color.White;
            this.np_right.TitlePanel.TabIndex = 0;
            this.np_right.TitlePanel.Text = "评论";
            // 
            // navigationPanePanel1
            // 
            this.navigationPanePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPanePanel1.Controls.Add(this.dgw);
            this.navigationPanePanel1.Controls.Add(this.cbb_tag);
            this.navigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel1.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel1.Margin = new System.Windows.Forms.Padding(4);
            this.navigationPanePanel1.Name = "navigationPanePanel1";
            this.navigationPanePanel1.ParentItem = this.btn_item_relation;
            this.navigationPanePanel1.Size = new System.Drawing.Size(283, 917);
            this.navigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel1.Style.GradientAngle = 90;
            this.navigationPanePanel1.TabIndex = 2;
            // 
            // dgw
            // 
            this.dgw.AllowUserToAddRows = false;
            this.dgw.AllowUserToDeleteRows = false;
            this.dgw.BackgroundColor = System.Drawing.Color.White;
            this.dgw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgw.ColumnHeadersVisible = false;
            this.dgw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tagType,
            this.tagNode,
            this.tagContent,
            this.OuterHTML});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgw.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgw.Location = new System.Drawing.Point(0, 23);
            this.dgw.Margin = new System.Windows.Forms.Padding(4);
            this.dgw.Name = "dgw";
            this.dgw.RowHeadersVisible = false;
            this.dgw.RowTemplate.Height = 23;
            this.dgw.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgw.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgw.ShowEditingIcon = false;
            this.dgw.Size = new System.Drawing.Size(283, 894);
            this.dgw.TabIndex = 0;
            this.dgw.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgw_CellDoubleClick);
            // 
            // tagType
            // 
            this.tagType.HeaderText = "";
            this.tagType.Name = "tagType";
            this.tagType.ReadOnly = true;
            this.tagType.Width = 20;
            // 
            // tagNode
            // 
            this.tagNode.HeaderText = "";
            this.tagNode.Name = "tagNode";
            this.tagNode.ReadOnly = true;
            this.tagNode.Width = 80;
            // 
            // tagContent
            // 
            this.tagContent.HeaderText = "";
            this.tagContent.Name = "tagContent";
            this.tagContent.ReadOnly = true;
            this.tagContent.Width = 120;
            // 
            // OuterHTML
            // 
            this.OuterHTML.HeaderText = "";
            this.OuterHTML.Name = "OuterHTML";
            this.OuterHTML.ReadOnly = true;
            this.OuterHTML.Visible = false;
            // 
            // cbb_tag
            // 
            this.cbb_tag.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbb_tag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_tag.FormattingEnabled = true;
            this.cbb_tag.Location = new System.Drawing.Point(0, 0);
            this.cbb_tag.Margin = new System.Windows.Forms.Padding(4);
            this.cbb_tag.Name = "cbb_tag";
            this.cbb_tag.Size = new System.Drawing.Size(283, 23);
            this.cbb_tag.TabIndex = 0;
            this.cbb_tag.SelectedIndexChanged += new System.EventHandler(this.cbb_tag_SelectedIndexChanged);
            // 
            // btn_item_relation
            // 
            this.btn_item_relation.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_item_relation.Image = ((System.Drawing.Image)(resources.GetObject("btn_item_relation.Image")));
            this.btn_item_relation.Name = "btn_item_relation";
            this.btn_item_relation.OptionGroup = "navBar";
            this.btn_item_relation.Text = "关系";
            this.btn_item_relation.Click += new System.EventHandler(this.btn_item_relation_Click);
            // 
            // navigationPanePanel2
            // 
            this.navigationPanePanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.navigationPanePanel2.Controls.Add(this.lbl_loadMore);
            this.navigationPanePanel2.Controls.Add(this.flp_comment);
            this.navigationPanePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel2.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel2.Margin = new System.Windows.Forms.Padding(4);
            this.navigationPanePanel2.Name = "navigationPanePanel2";
            this.navigationPanePanel2.ParentItem = this.btn_item_comment;
            this.navigationPanePanel2.Size = new System.Drawing.Size(283, 796);
            this.navigationPanePanel2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel2.Style.GradientAngle = 90;
            this.navigationPanePanel2.TabIndex = 3;
            // 
            // lbl_loadMore
            // 
            this.lbl_loadMore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_loadMore.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_loadMore.Location = new System.Drawing.Point(0, 758);
            this.lbl_loadMore.Name = "lbl_loadMore";
            this.lbl_loadMore.Size = new System.Drawing.Size(283, 38);
            this.lbl_loadMore.TabIndex = 2;
            this.lbl_loadMore.Text = "加载更多";
            this.lbl_loadMore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_loadMore.Click += new System.EventHandler(this.lbl_loadMore_Click);
            // 
            // flp_comment
            // 
            this.flp_comment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_comment.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_comment.Location = new System.Drawing.Point(0, 0);
            this.flp_comment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flp_comment.Name = "flp_comment";
            this.flp_comment.Size = new System.Drawing.Size(283, 796);
            this.flp_comment.TabIndex = 0;
            // 
            // btn_item_comment
            // 
            this.btn_item_comment.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btn_item_comment.Checked = true;
            this.btn_item_comment.Image = ((System.Drawing.Image)(resources.GetObject("btn_item_comment.Image")));
            this.btn_item_comment.Name = "btn_item_comment";
            this.btn_item_comment.OptionGroup = "navBar";
            this.btn_item_comment.Text = "评论";
            // 
            // pn_main_document
            // 
            this.pn_main_document.AllowDrop = true;
            this.pn_main_document.CanvasColor = System.Drawing.SystemColors.Control;
            this.pn_main_document.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pn_main_document.Controls.Add(this.wb);
            this.pn_main_document.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_main_document.Location = new System.Drawing.Point(280, 49);
            this.pn_main_document.Margin = new System.Windows.Forms.Padding(4);
            this.pn_main_document.Name = "pn_main_document";
            this.pn_main_document.Size = new System.Drawing.Size(802, 919);
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
            this.wb.AllowNavigation = false;
            this.wb.AllowWebBrowserDrop = false;
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.Margin = new System.Windows.Forms.Padding(4);
            this.wb.MinimumSize = new System.Drawing.Size(27, 25);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(802, 919);
            this.wb.TabIndex = 0;
            this.wb.WebBrowserShortcutsEnabled = false;
            // 
            // bt
            // 
            this.bt.AutoCloseTimeOut = 0;
            // 
            // lawInfo1
            // 
            this.lawInfo1.AutoScroll = true;
            this.lawInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lawInfo1.Location = new System.Drawing.Point(0, 0);
            this.lawInfo1.Margin = new System.Windows.Forms.Padding(5);
            this.lawInfo1.Name = "lawInfo1";
            this.lawInfo1.Size = new System.Drawing.Size(278, 796);
            this.lawInfo1.TabIndex = 0;
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LawView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "法规详情";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LawView_FormClosed);
            this.Load += new System.EventHandler(this.LawView_Load);
            this.pl_title.ResumeLayout(false);
            this.pl_title.PerformLayout();
            this.np_left.ResumeLayout(false);
            this.npp_docInfo.ResumeLayout(false);
            this.npp_docInfo.PerformLayout();
            this.npp_tree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NodeTree)).EndInit();
            this.np_right.ResumeLayout(false);
            this.navigationPanePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgw)).EndInit();
            this.navigationPanePanel2.ResumeLayout(false);
            this.pn_main_document.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_title;
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
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_keyword;
        private System.Windows.Forms.Button btn_suggest;
        private UserControls.LawInfo lawInfo1;
        private System.Windows.Forms.WebBrowser wb;
        private DevComponents.AdvTree.AdvTree NodeTree;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private System.Windows.Forms.FlowLayoutPanel flp_comment;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label lbl_loadMore;
        private System.Windows.Forms.DataGridView dgw;
        private System.Windows.Forms.ComboBox cbb_tag;
        private DevComponents.DotNetBar.BalloonTip bt;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagType;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagNode;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn OuterHTML;
        private System.Windows.Forms.Button btn_n;
        private System.Windows.Forms.Label lbl_findCount;
        private System.Windows.Forms.Button btn_p;
        private System.Windows.Forms.Label lbl_title;
    }
}