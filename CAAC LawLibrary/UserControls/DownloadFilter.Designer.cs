namespace CAAC_LawLibrary
{
    partial class DownloadFilter
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            CAAC_LawLibrary.Entity.Code code16 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code17 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code18 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code19 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code20 = new CAAC_LawLibrary.Entity.Code();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadFilter));
            this.cbb_downloadState = new System.Windows.Forms.ComboBox();
            this.ckb_selectAll = new System.Windows.Forms.CheckBox();
            this.btn_manageTask = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.暂停已选任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.继续已选任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除已选任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空已完成任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbb_buhao
            // 
            this.cbb_buhao.DisplayMember = "desc";
            code16.desc = "不限部号范围";
            code16.Id = null;
            code16.order = 0;
            code16.type = null;
            this.cbb_buhao.Items.AddRange(new object[] {
            code16});
            this.cbb_buhao.ValueMember = "Id";
            // 
            // cbb_siju
            // 
            this.cbb_siju.DisplayMember = "desc";
            code17.desc = "不限司局";
            code17.Id = null;
            code17.order = 0;
            code17.type = null;
            this.cbb_siju.Items.AddRange(new object[] {
            code17});
            this.cbb_siju.ValueMember = "Id";
            // 
            // cbb_weijie
            // 
            this.cbb_weijie.DisplayMember = "desc";
            code18.desc = "不限位阶范围";
            code18.Id = null;
            code18.order = 0;
            code18.type = null;
            this.cbb_weijie.Items.AddRange(new object[] {
            code18});
            this.cbb_weijie.ValueMember = "Id";
            // 
            // cbb_yewu
            // 
            this.cbb_yewu.DisplayMember = "desc";
            code19.desc = "不限业务分类";
            code19.Id = null;
            code19.order = 0;
            code19.type = null;
            this.cbb_yewu.Items.AddRange(new object[] {
            code19});
            this.cbb_yewu.ValueMember = "Id";
            // 
            // cbb_zidingyi
            // 
            this.cbb_zidingyi.DisplayMember = "desc";
            code20.desc = "不限自定义标签";
            code20.Id = null;
            code20.order = 0;
            code20.type = null;
            this.cbb_zidingyi.Items.AddRange(new object[] {
            code20});
            this.cbb_zidingyi.ValueMember = "Id";
            // 
            // cbb_sort
            // 
            this.cbb_sort.DisplayMember = "Value";
            this.cbb_sort.Items.AddRange(new object[] {
            ((object)(resources.GetObject("cbb_sort.Items"))),
            ((object)(resources.GetObject("cbb_sort.Items1")))});
            this.cbb_sort.ValueMember = "Key";
            // 
            // cbb_downloadState
            // 
            this.cbb_downloadState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_downloadState.FormattingEnabled = true;
            this.cbb_downloadState.Location = new System.Drawing.Point(19, 58);
            this.cbb_downloadState.Margin = new System.Windows.Forms.Padding(2);
            this.cbb_downloadState.Name = "cbb_downloadState";
            this.cbb_downloadState.Size = new System.Drawing.Size(92, 20);
            this.cbb_downloadState.TabIndex = 8;
            this.cbb_downloadState.SelectedIndexChanged += new System.EventHandler(this.cb_downloadState_SelectedIndexChanged);
            // 
            // ckb_selectAll
            // 
            this.ckb_selectAll.AutoSize = true;
            this.ckb_selectAll.Location = new System.Drawing.Point(158, 61);
            this.ckb_selectAll.Margin = new System.Windows.Forms.Padding(2);
            this.ckb_selectAll.Name = "ckb_selectAll";
            this.ckb_selectAll.Size = new System.Drawing.Size(72, 16);
            this.ckb_selectAll.TabIndex = 9;
            this.ckb_selectAll.Text = "本页全选";
            this.ckb_selectAll.UseVisualStyleBackColor = true;
            this.ckb_selectAll.CheckedChanged += new System.EventHandler(this.ckb_selectAll_CheckedChanged);
            // 
            // btn_manageTask
            // 
            this.btn_manageTask.Location = new System.Drawing.Point(849, 57);
            this.btn_manageTask.Margin = new System.Windows.Forms.Padding(2);
            this.btn_manageTask.Name = "btn_manageTask";
            this.btn_manageTask.Size = new System.Drawing.Size(123, 24);
            this.btn_manageTask.TabIndex = 10;
            this.btn_manageTask.Text = "管理任务";
            this.btn_manageTask.UseVisualStyleBackColor = true;
            this.btn_manageTask.Click += new System.EventHandler(this.btn_manageTask_Click);
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.暂停已选任务ToolStripMenuItem,
            this.继续已选任务ToolStripMenuItem,
            this.删除已选任务ToolStripMenuItem,
            this.清空已完成任务ToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(161, 114);
            // 
            // 暂停已选任务ToolStripMenuItem
            // 
            this.暂停已选任务ToolStripMenuItem.Name = "暂停已选任务ToolStripMenuItem";
            this.暂停已选任务ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.暂停已选任务ToolStripMenuItem.Text = "暂停已选任务";
            this.暂停已选任务ToolStripMenuItem.Click += new System.EventHandler(this.暂停已选任务ToolStripMenuItem_Click);
            // 
            // 继续已选任务ToolStripMenuItem
            // 
            this.继续已选任务ToolStripMenuItem.Name = "继续已选任务ToolStripMenuItem";
            this.继续已选任务ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.继续已选任务ToolStripMenuItem.Text = "继续已选任务";
            this.继续已选任务ToolStripMenuItem.Click += new System.EventHandler(this.继续已选任务ToolStripMenuItem_Click);
            // 
            // 删除已选任务ToolStripMenuItem
            // 
            this.删除已选任务ToolStripMenuItem.Name = "删除已选任务ToolStripMenuItem";
            this.删除已选任务ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.删除已选任务ToolStripMenuItem.Text = "删除已选任务";
            this.删除已选任务ToolStripMenuItem.Click += new System.EventHandler(this.删除已选任务ToolStripMenuItem_Click);
            // 
            // 清空已完成任务ToolStripMenuItem
            // 
            this.清空已完成任务ToolStripMenuItem.Name = "清空已完成任务ToolStripMenuItem";
            this.清空已完成任务ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.清空已完成任务ToolStripMenuItem.Text = "清空已完成任务";
            this.清空已完成任务ToolStripMenuItem.Click += new System.EventHandler(this.清空已完成任务ToolStripMenuItem_Click);
            // 
            // DownloadFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_manageTask);
            this.Controls.Add(this.ckb_selectAll);
            this.Controls.Add(this.cbb_downloadState);
            this.Name = "DownloadFilter";
            this.Load += new System.EventHandler(this.DownloadFilter_Load);
            this.Controls.SetChildIndex(this.cbb_buhao, 0);
            this.Controls.SetChildIndex(this.cbb_siju, 0);
            this.Controls.SetChildIndex(this.cbb_weijie, 0);
            this.Controls.SetChildIndex(this.cbb_yewu, 0);
            this.Controls.SetChildIndex(this.cbb_zidingyi, 0);
            this.Controls.SetChildIndex(this.cbb_sort, 0);
            this.Controls.SetChildIndex(this.cbb_downloadState, 0);
            this.Controls.SetChildIndex(this.ckb_selectAll, 0);
            this.Controls.SetChildIndex(this.btn_manageTask, 0);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_downloadState;
        public System.Windows.Forms.CheckBox ckb_selectAll;
        private System.Windows.Forms.Button btn_manageTask;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 暂停已选任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 继续已选任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除已选任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空已完成任务ToolStripMenuItem;
    }
}
