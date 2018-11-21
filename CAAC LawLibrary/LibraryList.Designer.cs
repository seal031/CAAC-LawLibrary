namespace CAAC_LawLibrary
{
    partial class LibraryList
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraryList));
            this.pl_title = new System.Windows.Forms.Panel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.pl_main = new System.Windows.Forms.Panel();
            this.tbc = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.flp_downloadTask = new System.Windows.Forms.FlowLayoutPanel();
            this.superTabItem3 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.flp_viewHistory = new System.Windows.Forms.FlowLayoutPanel();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.flp_lawLibrary = new System.Windows.Forms.FlowLayoutPanel();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.dgv_updateHistory = new System.Windows.Forms.DataGridView();
            this.LawId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LawTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpdateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.superTabItem4 = new DevComponents.DotNetBar.SuperTabItem();
            this.lawFilter = new CAAC_LawLibrary.LawFilter();
            this.downloadFilter = new CAAC_LawLibrary.DownloadFilter();
            this.viewHistoryFilter = new CAAC_LawLibrary.ViewHistoryFilter();
            this.pl_title.SuspendLayout();
            this.pl_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbc)).BeginInit();
            this.tbc.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            this.flp_downloadTask.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.flp_viewHistory.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.flp_lawLibrary.SuspendLayout();
            this.superTabControlPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_updateHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // pl_title
            // 
            this.pl_title.Controls.Add(this.btn_logout);
            this.pl_title.Controls.Add(this.lbl_welcome);
            this.pl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_title.Location = new System.Drawing.Point(0, 0);
            this.pl_title.Margin = new System.Windows.Forms.Padding(4);
            this.pl_title.Name = "pl_title";
            this.pl_title.Size = new System.Drawing.Size(1379, 42);
            this.pl_title.TabIndex = 0;
            // 
            // btn_logout
            // 
            this.btn_logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_logout.AutoSize = true;
            this.btn_logout.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_logout.Location = new System.Drawing.Point(1267, 4);
            this.btn_logout.Margin = new System.Windows.Forms.Padding(4);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(100, 33);
            this.btn_logout.TabIndex = 1;
            this.btn_logout.Text = "退出";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_welcome.Location = new System.Drawing.Point(1019, 14);
            this.lbl_welcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(61, 23);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "您好：";
            // 
            // pl_main
            // 
            this.pl_main.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pl_main.Controls.Add(this.tbc);
            this.pl_main.Location = new System.Drawing.Point(0, 41);
            this.pl_main.Margin = new System.Windows.Forms.Padding(4);
            this.pl_main.Name = "pl_main";
            this.pl_main.Size = new System.Drawing.Size(1379, 926);
            this.pl_main.TabIndex = 1;
            // 
            // tbc
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tbc.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tbc.ControlBox.MenuBox.Name = "";
            this.tbc.ControlBox.Name = "";
            this.tbc.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbc.ControlBox.MenuBox,
            this.tbc.ControlBox.CloseBox});
            this.tbc.Controls.Add(this.superTabControlPanel4);
            this.tbc.Controls.Add(this.superTabControlPanel3);
            this.tbc.Controls.Add(this.superTabControlPanel2);
            this.tbc.Controls.Add(this.superTabControlPanel1);
            this.tbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbc.Location = new System.Drawing.Point(0, 0);
            this.tbc.Name = "tbc";
            this.tbc.ReorderTabsEnabled = true;
            this.tbc.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tbc.SelectedTabIndex = 0;
            this.tbc.Size = new System.Drawing.Size(1379, 926);
            this.tbc.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbc.TabIndex = 0;
            this.tbc.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2,
            this.superTabItem3,
            this.superTabItem4});
            this.tbc.Text = "superTabControl1";
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.flp_downloadTask);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 46);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(1379, 880);
            this.superTabControlPanel3.TabIndex = 0;
            this.superTabControlPanel3.TabItem = this.superTabItem3;
            // 
            // flp_downloadTask
            // 
            this.flp_downloadTask.Controls.Add(this.downloadFilter);
            this.flp_downloadTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_downloadTask.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_downloadTask.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flp_downloadTask.Location = new System.Drawing.Point(0, 0);
            this.flp_downloadTask.Name = "flp_downloadTask";
            this.flp_downloadTask.Size = new System.Drawing.Size(1379, 880);
            this.flp_downloadTask.TabIndex = 0;
            // 
            // superTabItem3
            // 
            this.superTabItem3.AttachedControl = this.superTabControlPanel3;
            this.superTabItem3.GlobalItem = false;
            this.superTabItem3.Icon = ((System.Drawing.Icon)(resources.GetObject("superTabItem3.Icon")));
            this.superTabItem3.Name = "superTabItem3";
            this.superTabItem3.Text = "下载任务管理";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.flp_viewHistory);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 46);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(1379, 880);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // flp_viewHistory
            // 
            this.flp_viewHistory.Controls.Add(this.viewHistoryFilter);
            this.flp_viewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_viewHistory.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_viewHistory.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flp_viewHistory.Location = new System.Drawing.Point(0, 0);
            this.flp_viewHistory.Name = "flp_viewHistory";
            this.flp_viewHistory.Size = new System.Drawing.Size(1379, 880);
            this.flp_viewHistory.TabIndex = 0;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Icon = ((System.Drawing.Icon)(resources.GetObject("superTabItem2.Icon")));
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "阅读历史";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.flp_lawLibrary);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 46);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(1379, 880);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // flp_lawLibrary
            // 
            this.flp_lawLibrary.Controls.Add(this.lawFilter);
            this.flp_lawLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_lawLibrary.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_lawLibrary.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.flp_lawLibrary.Location = new System.Drawing.Point(0, 0);
            this.flp_lawLibrary.Name = "flp_lawLibrary";
            this.flp_lawLibrary.Size = new System.Drawing.Size(1379, 880);
            this.flp_lawLibrary.TabIndex = 0;
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Icon = ((System.Drawing.Icon)(resources.GetObject("superTabItem1.Icon")));
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "法规库列表";
            // 
            // superTabControlPanel4
            // 
            this.superTabControlPanel4.Controls.Add(this.dgv_updateHistory);
            this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel4.Location = new System.Drawing.Point(0, 46);
            this.superTabControlPanel4.Name = "superTabControlPanel4";
            this.superTabControlPanel4.Size = new System.Drawing.Size(1379, 880);
            this.superTabControlPanel4.TabIndex = 0;
            this.superTabControlPanel4.TabItem = this.superTabItem4;
            // 
            // dgv_updateHistory
            // 
            this.dgv_updateHistory.AllowUserToAddRows = false;
            this.dgv_updateHistory.AllowUserToDeleteRows = false;
            this.dgv_updateHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_updateHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LawId,
            this.LawTitle,
            this.Version,
            this.UpdateDate,
            this.UserId,
            this.Id});
            this.dgv_updateHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_updateHistory.Location = new System.Drawing.Point(0, 0);
            this.dgv_updateHistory.Name = "dgv_updateHistory";
            this.dgv_updateHistory.ReadOnly = true;
            this.dgv_updateHistory.RowHeadersVisible = false;
            this.dgv_updateHistory.RowTemplate.Height = 27;
            this.dgv_updateHistory.Size = new System.Drawing.Size(1379, 880);
            this.dgv_updateHistory.TabIndex = 2;
            // 
            // LawId
            // 
            this.LawId.DataPropertyName = "LawId";
            this.LawId.HeaderText = "LawId";
            this.LawId.Name = "LawId";
            this.LawId.ReadOnly = true;
            this.LawId.Visible = false;
            // 
            // LawTitle
            // 
            this.LawTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LawTitle.DataPropertyName = "LawTitle";
            this.LawTitle.HeaderText = "法规名称";
            this.LawTitle.Name = "LawTitle";
            this.LawTitle.ReadOnly = true;
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "版本";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            // 
            // UpdateDate
            // 
            this.UpdateDate.DataPropertyName = "UpdateDate";
            this.UpdateDate.HeaderText = "更新时间";
            this.UpdateDate.Name = "UpdateDate";
            this.UpdateDate.ReadOnly = true;
            this.UpdateDate.Width = 200;
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Visible = false;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // superTabItem4
            // 
            this.superTabItem4.AttachedControl = this.superTabControlPanel4;
            this.superTabItem4.GlobalItem = false;
            this.superTabItem4.Icon = ((System.Drawing.Icon)(resources.GetObject("superTabItem4.Icon")));
            this.superTabItem4.Name = "superTabItem4";
            this.superTabItem4.Text = "自动更新历史";
            // 
            // lawFilter
            // 
            this.lawFilter.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lawFilter.Location = new System.Drawing.Point(3, 2);
            this.lawFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lawFilter.Name = "lawFilter";
            this.lawFilter.Size = new System.Drawing.Size(1373, 92);
            this.lawFilter.TabIndex = 0;
            // 
            // downloadFilter
            // 
            this.downloadFilter.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.downloadFilter.Location = new System.Drawing.Point(4, 2);
            this.downloadFilter.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.downloadFilter.Name = "downloadFilter";
            this.downloadFilter.Size = new System.Drawing.Size(1373, 91);
            this.downloadFilter.TabIndex = 0;
            // 
            // viewHistoryFilter
            // 
            this.viewHistoryFilter.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.viewHistoryFilter.Location = new System.Drawing.Point(4, 2);
            this.viewHistoryFilter.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.viewHistoryFilter.Name = "viewHistoryFilter";
            this.viewHistoryFilter.Size = new System.Drawing.Size(1373, 90);
            this.viewHistoryFilter.TabIndex = 0;
            // 
            // LibraryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1379, 784);
            this.Controls.Add(this.pl_main);
            this.Controls.Add(this.pl_title);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "LibraryList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LibraryList_FormClosed);
            this.Load += new System.EventHandler(this.LibraryList_Load);
            this.pl_title.ResumeLayout(false);
            this.pl_title.PerformLayout();
            this.pl_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbc)).EndInit();
            this.tbc.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
            this.flp_downloadTask.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.flp_viewHistory.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.flp_lawLibrary.ResumeLayout(false);
            this.superTabControlPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_updateHistory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_title;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Panel pl_main;
        private DevComponents.DotNetBar.SuperTabControl tbc;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private System.Windows.Forms.FlowLayoutPanel flp_lawLibrary;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
        private DevComponents.DotNetBar.SuperTabItem superTabItem4;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private DevComponents.DotNetBar.SuperTabItem superTabItem3;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private System.Windows.Forms.FlowLayoutPanel flp_viewHistory;
        private System.Windows.Forms.FlowLayoutPanel flp_downloadTask;
        private LawFilter lawFilter;
        private ViewHistoryFilter viewHistoryFilter;
        private DownloadFilter downloadFilter;
        private System.Windows.Forms.DataGridView dgv_updateHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn LawId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LawTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpdateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}

