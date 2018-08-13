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
            this.pl_title = new System.Windows.Forms.Panel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.lbl_welcome = new System.Windows.Forms.Label();
            this.pl_main = new System.Windows.Forms.Panel();
            this.tbc = new System.Windows.Forms.TabControl();
            this.tp_libraryList = new System.Windows.Forms.TabPage();
            this.flp_libraryList = new System.Windows.Forms.FlowLayoutPanel();
            this.lawFilter = new CAAC_LawLibrary.LawFilter();
            this.tp_viewHistory = new System.Windows.Forms.TabPage();
            this.flp_viewHistory = new System.Windows.Forms.FlowLayoutPanel();
            this.viewHistoryFilter = new CAAC_LawLibrary.ViewHistoryFilter();
            this.tp_downloadTask = new System.Windows.Forms.TabPage();
            this.flp_downloadTask = new System.Windows.Forms.FlowLayoutPanel();
            this.downloadFilter = new CAAC_LawLibrary.DownloadFilter();
            this.pl_title.SuspendLayout();
            this.pl_main.SuspendLayout();
            this.tbc.SuspendLayout();
            this.tp_libraryList.SuspendLayout();
            this.flp_libraryList.SuspendLayout();
            this.tp_viewHistory.SuspendLayout();
            this.flp_viewHistory.SuspendLayout();
            this.tp_downloadTask.SuspendLayout();
            this.flp_downloadTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // pl_title
            // 
            this.pl_title.Controls.Add(this.btn_logout);
            this.pl_title.Controls.Add(this.lbl_welcome);
            this.pl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.pl_title.Location = new System.Drawing.Point(0, 0);
            this.pl_title.Name = "pl_title";
            this.pl_title.Size = new System.Drawing.Size(1022, 39);
            this.pl_title.TabIndex = 0;
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(938, 8);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 23);
            this.btn_logout.TabIndex = 1;
            this.btn_logout.Text = "退出";
            this.btn_logout.UseVisualStyleBackColor = true;
            // 
            // lbl_welcome
            // 
            this.lbl_welcome.AutoSize = true;
            this.lbl_welcome.Location = new System.Drawing.Point(752, 13);
            this.lbl_welcome.Name = "lbl_welcome";
            this.lbl_welcome.Size = new System.Drawing.Size(41, 12);
            this.lbl_welcome.TabIndex = 0;
            this.lbl_welcome.Text = "您好：";
            // 
            // pl_main
            // 
            this.pl_main.Controls.Add(this.tbc);
            this.pl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pl_main.Location = new System.Drawing.Point(0, 39);
            this.pl_main.Name = "pl_main";
            this.pl_main.Size = new System.Drawing.Size(1022, 735);
            this.pl_main.TabIndex = 1;
            // 
            // tbc
            // 
            this.tbc.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbc.Controls.Add(this.tp_libraryList);
            this.tbc.Controls.Add(this.tp_viewHistory);
            this.tbc.Controls.Add(this.tp_downloadTask);
            this.tbc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbc.ItemSize = new System.Drawing.Size(100, 30);
            this.tbc.Location = new System.Drawing.Point(0, 0);
            this.tbc.Name = "tbc";
            this.tbc.SelectedIndex = 0;
            this.tbc.Size = new System.Drawing.Size(1022, 735);
            this.tbc.TabIndex = 0;
            // 
            // tp_libraryList
            // 
            this.tp_libraryList.Controls.Add(this.flp_libraryList);
            this.tp_libraryList.Location = new System.Drawing.Point(4, 34);
            this.tp_libraryList.Name = "tp_libraryList";
            this.tp_libraryList.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tp_libraryList.Size = new System.Drawing.Size(1014, 697);
            this.tp_libraryList.TabIndex = 0;
            this.tp_libraryList.Text = "法规库目录";
            this.tp_libraryList.UseVisualStyleBackColor = true;
            // 
            // flp_libraryList
            // 
            this.flp_libraryList.Controls.Add(this.lawFilter);
            this.flp_libraryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_libraryList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_libraryList.Location = new System.Drawing.Point(3, 3);
            this.flp_libraryList.Name = "flp_libraryList";
            this.flp_libraryList.Size = new System.Drawing.Size(1008, 691);
            this.flp_libraryList.TabIndex = 0;
            // 
            // lawFilter
            // 
            this.lawFilter.Location = new System.Drawing.Point(2, 2);
            this.lawFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lawFilter.Name = "lawFilter";
            this.lawFilter.Size = new System.Drawing.Size(1000, 103);
            this.lawFilter.TabIndex = 0;
            // 
            // tp_viewHistory
            // 
            this.tp_viewHistory.Controls.Add(this.flp_viewHistory);
            this.tp_viewHistory.Location = new System.Drawing.Point(4, 34);
            this.tp_viewHistory.Name = "tp_viewHistory";
            this.tp_viewHistory.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tp_viewHistory.Size = new System.Drawing.Size(1014, 697);
            this.tp_viewHistory.TabIndex = 1;
            this.tp_viewHistory.Text = "阅读历史";
            this.tp_viewHistory.UseVisualStyleBackColor = true;
            // 
            // flp_viewHistory
            // 
            this.flp_viewHistory.Controls.Add(this.viewHistoryFilter);
            this.flp_viewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_viewHistory.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_viewHistory.Location = new System.Drawing.Point(3, 3);
            this.flp_viewHistory.Name = "flp_viewHistory";
            this.flp_viewHistory.Size = new System.Drawing.Size(1008, 691);
            this.flp_viewHistory.TabIndex = 1;
            // 
            // viewHistoryFilter
            // 
            this.viewHistoryFilter.Location = new System.Drawing.Point(2, 2);
            this.viewHistoryFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.viewHistoryFilter.Name = "viewHistoryFilter";
            this.viewHistoryFilter.Size = new System.Drawing.Size(1000, 98);
            this.viewHistoryFilter.TabIndex = 0;
            // 
            // tp_downloadTask
            // 
            this.tp_downloadTask.Controls.Add(this.flp_downloadTask);
            this.tp_downloadTask.Location = new System.Drawing.Point(4, 34);
            this.tp_downloadTask.Name = "tp_downloadTask";
            this.tp_downloadTask.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tp_downloadTask.Size = new System.Drawing.Size(1014, 697);
            this.tp_downloadTask.TabIndex = 2;
            this.tp_downloadTask.Text = "下载任务管理";
            this.tp_downloadTask.UseVisualStyleBackColor = true;
            // 
            // flp_downloadTask
            // 
            this.flp_downloadTask.Controls.Add(this.downloadFilter);
            this.flp_downloadTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_downloadTask.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_downloadTask.Location = new System.Drawing.Point(3, 3);
            this.flp_downloadTask.Name = "flp_downloadTask";
            this.flp_downloadTask.Size = new System.Drawing.Size(1008, 691);
            this.flp_downloadTask.TabIndex = 1;
            // 
            // downloadFilter
            // 
            this.downloadFilter.Location = new System.Drawing.Point(2, 2);
            this.downloadFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.downloadFilter.Name = "downloadFilter";
            this.downloadFilter.Size = new System.Drawing.Size(1000, 98);
            this.downloadFilter.TabIndex = 0;
            // 
            // LibraryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 774);
            this.Controls.Add(this.pl_main);
            this.Controls.Add(this.pl_title);
            this.Name = "LibraryList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LibraryList_FormClosed);
            this.Load += new System.EventHandler(this.LibraryList_Load);
            this.pl_title.ResumeLayout(false);
            this.pl_title.PerformLayout();
            this.pl_main.ResumeLayout(false);
            this.tbc.ResumeLayout(false);
            this.tp_libraryList.ResumeLayout(false);
            this.flp_libraryList.ResumeLayout(false);
            this.tp_viewHistory.ResumeLayout(false);
            this.flp_viewHistory.ResumeLayout(false);
            this.tp_downloadTask.ResumeLayout(false);
            this.flp_downloadTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pl_title;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Label lbl_welcome;
        private System.Windows.Forms.Panel pl_main;
        private System.Windows.Forms.TabControl tbc;
        private System.Windows.Forms.TabPage tp_libraryList;
        private System.Windows.Forms.TabPage tp_viewHistory;
        private System.Windows.Forms.TabPage tp_downloadTask;
        private System.Windows.Forms.FlowLayoutPanel flp_libraryList;
        private System.Windows.Forms.FlowLayoutPanel flp_viewHistory;
        private System.Windows.Forms.FlowLayoutPanel flp_downloadTask;
        private LawFilter lawFilter;
        private ViewHistoryFilter viewHistoryFilter;
        private DownloadFilter downloadFilter;
    }
}

