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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadFilter));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
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
            this.cbb_buhao.ValueMember = "Id";
            // 
            // cbb_siju
            // 
            this.cbb_siju.DisplayMember = "desc";
            this.cbb_siju.ValueMember = "Id";
            // 
            // cbb_weijie
            // 
            this.cbb_weijie.DisplayMember = "desc";
            this.cbb_weijie.ValueMember = "Id";
            // 
            // cbb_yewu
            // 
            this.cbb_yewu.DisplayMember = "desc";
            this.cbb_yewu.ValueMember = "Id";
            // 
            // cbb_zidingyi
            // 
            this.cbb_zidingyi.DisplayMember = "desc";
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(25, 72);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 8;
            // 
            // ckb_selectAll
            // 
            this.ckb_selectAll.AutoSize = true;
            this.ckb_selectAll.Location = new System.Drawing.Point(211, 76);
            this.ckb_selectAll.Name = "ckb_selectAll";
            this.ckb_selectAll.Size = new System.Drawing.Size(89, 19);
            this.ckb_selectAll.TabIndex = 9;
            this.ckb_selectAll.Text = "本页全选";
            this.ckb_selectAll.UseVisualStyleBackColor = true;
            // 
            // btn_manageTask
            // 
            this.btn_manageTask.Location = new System.Drawing.Point(1132, 71);
            this.btn_manageTask.Name = "btn_manageTask";
            this.btn_manageTask.Size = new System.Drawing.Size(164, 30);
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
            this.menu.Size = new System.Drawing.Size(190, 108);
            // 
            // 暂停已选任务ToolStripMenuItem
            // 
            this.暂停已选任务ToolStripMenuItem.Name = "暂停已选任务ToolStripMenuItem";
            this.暂停已选任务ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.暂停已选任务ToolStripMenuItem.Text = "暂停已选任务";
            // 
            // 继续已选任务ToolStripMenuItem
            // 
            this.继续已选任务ToolStripMenuItem.Name = "继续已选任务ToolStripMenuItem";
            this.继续已选任务ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.继续已选任务ToolStripMenuItem.Text = "继续已选任务";
            // 
            // 删除已选任务ToolStripMenuItem
            // 
            this.删除已选任务ToolStripMenuItem.Name = "删除已选任务ToolStripMenuItem";
            this.删除已选任务ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.删除已选任务ToolStripMenuItem.Text = "删除已选任务";
            // 
            // 清空已完成任务ToolStripMenuItem
            // 
            this.清空已完成任务ToolStripMenuItem.Name = "清空已完成任务ToolStripMenuItem";
            this.清空已完成任务ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.清空已完成任务ToolStripMenuItem.Text = "清空已完成任务";
            // 
            // DownloadFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_manageTask);
            this.Controls.Add(this.ckb_selectAll);
            this.Controls.Add(this.comboBox1);
            this.Name = "DownloadFilter";
            this.Controls.SetChildIndex(this.cbb_buhao, 0);
            this.Controls.SetChildIndex(this.cbb_siju, 0);
            this.Controls.SetChildIndex(this.cbb_weijie, 0);
            this.Controls.SetChildIndex(this.cbb_yewu, 0);
            this.Controls.SetChildIndex(this.cbb_zidingyi, 0);
            this.Controls.SetChildIndex(this.cbb_sort, 0);
            this.Controls.SetChildIndex(this.comboBox1, 0);
            this.Controls.SetChildIndex(this.ckb_selectAll, 0);
            this.Controls.SetChildIndex(this.btn_manageTask, 0);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox ckb_selectAll;
        private System.Windows.Forms.Button btn_manageTask;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 暂停已选任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 继续已选任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除已选任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空已完成任务ToolStripMenuItem;
    }
}
