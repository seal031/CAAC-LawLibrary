namespace CAAC_LawLibrary
{
    partial class LawFilter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LawFilter));
            this.ckb_showDownloaded = new System.Windows.Forms.CheckBox();
            this.ckb_selectAll = new System.Windows.Forms.CheckBox();
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.下载已选项到本地库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.从本地库移除已选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空本地库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_manageLocal = new System.Windows.Forms.Button();
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
            // ckb_showDownloaded
            // 
            this.ckb_showDownloaded.AutoSize = true;
            this.ckb_showDownloaded.Location = new System.Drawing.Point(25, 76);
            this.ckb_showDownloaded.Name = "ckb_showDownloaded";
            this.ckb_showDownloaded.Size = new System.Drawing.Size(119, 19);
            this.ckb_showDownloaded.TabIndex = 8;
            this.ckb_showDownloaded.Text = "仅显示已下载";
            this.ckb_showDownloaded.UseVisualStyleBackColor = true;
            this.ckb_showDownloaded.CheckedChanged += new System.EventHandler(this.ckb_showDownloaded_CheckedChanged);
            // 
            // ckb_selectAll
            // 
            this.ckb_selectAll.AutoSize = true;
            this.ckb_selectAll.Location = new System.Drawing.Point(193, 76);
            this.ckb_selectAll.Name = "ckb_selectAll";
            this.ckb_selectAll.Size = new System.Drawing.Size(89, 19);
            this.ckb_selectAll.TabIndex = 9;
            this.ckb_selectAll.Text = "本页全选";
            this.ckb_selectAll.UseVisualStyleBackColor = true;
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载已选项到本地库ToolStripMenuItem,
            this.从本地库移除已选项ToolStripMenuItem,
            this.清空本地库ToolStripMenuItem});
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menu.Size = new System.Drawing.Size(220, 110);
            // 
            // 下载已选项到本地库ToolStripMenuItem
            // 
            this.下载已选项到本地库ToolStripMenuItem.Name = "下载已选项到本地库ToolStripMenuItem";
            this.下载已选项到本地库ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.下载已选项到本地库ToolStripMenuItem.Text = "下载已选项到本地库";
            this.下载已选项到本地库ToolStripMenuItem.Click += new System.EventHandler(this.下载已选项到本地库ToolStripMenuItem_Click);
            // 
            // 从本地库移除已选项ToolStripMenuItem
            // 
            this.从本地库移除已选项ToolStripMenuItem.Name = "从本地库移除已选项ToolStripMenuItem";
            this.从本地库移除已选项ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.从本地库移除已选项ToolStripMenuItem.Text = "从本地库移除已选项";
            this.从本地库移除已选项ToolStripMenuItem.Click += new System.EventHandler(this.从本地库移除已选项ToolStripMenuItem_Click);
            // 
            // 清空本地库ToolStripMenuItem
            // 
            this.清空本地库ToolStripMenuItem.Name = "清空本地库ToolStripMenuItem";
            this.清空本地库ToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.清空本地库ToolStripMenuItem.Text = "清空本地库";
            this.清空本地库ToolStripMenuItem.Click += new System.EventHandler(this.清空本地库ToolStripMenuItem_Click);
            // 
            // btn_manageLocal
            // 
            this.btn_manageLocal.Location = new System.Drawing.Point(1132, 70);
            this.btn_manageLocal.Name = "btn_manageLocal";
            this.btn_manageLocal.Size = new System.Drawing.Size(164, 23);
            this.btn_manageLocal.TabIndex = 10;
            this.btn_manageLocal.Text = "管理本地库";
            this.btn_manageLocal.UseVisualStyleBackColor = true;
            this.btn_manageLocal.Click += new System.EventHandler(this.btn_manageLocal_Click);
            // 
            // LawFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_manageLocal);
            this.Controls.Add(this.ckb_selectAll);
            this.Controls.Add(this.ckb_showDownloaded);
            this.Name = "LawFilter";
            this.Controls.SetChildIndex(this.cbb_buhao, 0);
            this.Controls.SetChildIndex(this.cbb_siju, 0);
            this.Controls.SetChildIndex(this.cbb_weijie, 0);
            this.Controls.SetChildIndex(this.cbb_yewu, 0);
            this.Controls.SetChildIndex(this.cbb_zidingyi, 0);
            this.Controls.SetChildIndex(this.cbb_sort, 0);
            this.Controls.SetChildIndex(this.ckb_showDownloaded, 0);
            this.Controls.SetChildIndex(this.ckb_selectAll, 0);
            this.Controls.SetChildIndex(this.btn_manageLocal, 0);
            this.menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckb_showDownloaded;
        private System.Windows.Forms.CheckBox ckb_selectAll;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem 下载已选项到本地库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 从本地库移除已选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空本地库ToolStripMenuItem;
        private System.Windows.Forms.Button btn_manageLocal;
    }
}
