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
            CAAC_LawLibrary.Entity.Code code1 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code2 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code3 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code4 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code5 = new CAAC_LawLibrary.Entity.Code();
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
            code1.desc = "不限部号范围";
            code1.Id = null;
            code1.order = 0;
            code1.type = null;
            code1.valueMax = null;
            code1.valueMin = null;
            this.cbb_buhao.Items.AddRange(new object[] {
            code1});
            this.cbb_buhao.ValueMember = "Id";
            // 
            // cbb_siju
            // 
            this.cbb_siju.DisplayMember = "desc";
            code2.desc = "不限司局";
            code2.Id = null;
            code2.order = 0;
            code2.type = null;
            code2.valueMax = null;
            code2.valueMin = null;
            this.cbb_siju.Items.AddRange(new object[] {
            code2});
            this.cbb_siju.ValueMember = "Id";
            // 
            // cbb_weijie
            // 
            this.cbb_weijie.DisplayMember = "desc";
            code3.desc = "不限位阶范围";
            code3.Id = null;
            code3.order = 0;
            code3.type = null;
            code3.valueMax = null;
            code3.valueMin = null;
            this.cbb_weijie.Items.AddRange(new object[] {
            code3});
            this.cbb_weijie.ValueMember = "Id";
            // 
            // cbb_yewu
            // 
            this.cbb_yewu.DisplayMember = "desc";
            code4.desc = "不限业务分类";
            code4.Id = null;
            code4.order = 0;
            code4.type = null;
            code4.valueMax = null;
            code4.valueMin = null;
            this.cbb_yewu.Items.AddRange(new object[] {
            code4});
            this.cbb_yewu.ValueMember = "Id";
            // 
            // cbb_zidingyi
            // 
            this.cbb_zidingyi.DisplayMember = "desc";
            code5.desc = "不限自定义标签";
            code5.Id = null;
            code5.order = 0;
            code5.type = null;
            code5.valueMax = null;
            code5.valueMin = null;
            this.cbb_zidingyi.Items.AddRange(new object[] {
            code5});
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
            this.cbb_downloadState.Location = new System.Drawing.Point(25, 55);
            this.cbb_downloadState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbb_downloadState.Name = "cbb_downloadState";
            this.cbb_downloadState.Size = new System.Drawing.Size(121, 23);
            this.cbb_downloadState.TabIndex = 8;
            this.cbb_downloadState.SelectedIndexChanged += new System.EventHandler(this.cb_downloadState_SelectedIndexChanged);
            // 
            // ckb_selectAll
            // 
            this.ckb_selectAll.AutoSize = true;
            this.ckb_selectAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_selectAll.Location = new System.Drawing.Point(165, 57);
            this.ckb_selectAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ckb_selectAll.Name = "ckb_selectAll";
            this.ckb_selectAll.Size = new System.Drawing.Size(61, 24);
            this.ckb_selectAll.TabIndex = 9;
            this.ckb_selectAll.Text = "全选";
            this.ckb_selectAll.UseVisualStyleBackColor = true;
            this.ckb_selectAll.CheckedChanged += new System.EventHandler(this.ckb_selectAll_CheckedChanged);
            // 
            // btn_manageTask
            // 
            this.btn_manageTask.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_manageTask.Location = new System.Drawing.Point(1154, 53);
            this.btn_manageTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_manageTask.Name = "btn_manageTask";
            this.btn_manageTask.Size = new System.Drawing.Size(164, 30);
            this.btn_manageTask.TabIndex = 10;
            this.btn_manageTask.Text = "管理任务";
            this.btn_manageTask.UseVisualStyleBackColor = true;
            this.btn_manageTask.Click += new System.EventHandler(this.btn_manageTask_Click);
            // 
            // menu
            // 
            this.menu.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.暂停已选任务ToolStripMenuItem,
            this.继续已选任务ToolStripMenuItem,
            this.删除已选任务ToolStripMenuItem,
            this.清空已完成任务ToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(190, 108);
            // 
            // 暂停已选任务ToolStripMenuItem
            // 
            this.暂停已选任务ToolStripMenuItem.Name = "暂停已选任务ToolStripMenuItem";
            this.暂停已选任务ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.暂停已选任务ToolStripMenuItem.Text = "暂停已选任务";
            this.暂停已选任务ToolStripMenuItem.Click += new System.EventHandler(this.暂停已选任务ToolStripMenuItem_Click);
            // 
            // 继续已选任务ToolStripMenuItem
            // 
            this.继续已选任务ToolStripMenuItem.Name = "继续已选任务ToolStripMenuItem";
            this.继续已选任务ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.继续已选任务ToolStripMenuItem.Text = "继续已选任务";
            this.继续已选任务ToolStripMenuItem.Click += new System.EventHandler(this.继续已选任务ToolStripMenuItem_Click);
            // 
            // 删除已选任务ToolStripMenuItem
            // 
            this.删除已选任务ToolStripMenuItem.Name = "删除已选任务ToolStripMenuItem";
            this.删除已选任务ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.删除已选任务ToolStripMenuItem.Text = "删除已选任务";
            this.删除已选任务ToolStripMenuItem.Click += new System.EventHandler(this.删除已选任务ToolStripMenuItem_Click);
            // 
            // 清空已完成任务ToolStripMenuItem
            // 
            this.清空已完成任务ToolStripMenuItem.Name = "清空已完成任务ToolStripMenuItem";
            this.清空已完成任务ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.清空已完成任务ToolStripMenuItem.Text = "清空已完成任务";
            this.清空已完成任务ToolStripMenuItem.Click += new System.EventHandler(this.清空已完成任务ToolStripMenuItem_Click);
            // 
            // DownloadFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_manageTask);
            this.Controls.Add(this.ckb_selectAll);
            this.Controls.Add(this.cbb_downloadState);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "DownloadFilter";
            this.Size = new System.Drawing.Size(1333, 92);
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
