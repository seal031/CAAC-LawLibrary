namespace CAAC_LawLibrary
{
    partial class ViewHistoryFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewHistoryFilter));
            this.ckb_showDownloaded = new System.Windows.Forms.CheckBox();
            this.btn_clearHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.ckb_showDownloaded.Location = new System.Drawing.Point(25, 74);
            this.ckb_showDownloaded.Name = "ckb_showDownloaded";
            this.ckb_showDownloaded.Size = new System.Drawing.Size(119, 19);
            this.ckb_showDownloaded.TabIndex = 9;
            this.ckb_showDownloaded.Text = "仅显示已下载";
            this.ckb_showDownloaded.UseVisualStyleBackColor = true;
            this.ckb_showDownloaded.CheckedChanged += new System.EventHandler(this.ckb_showDownloaded_CheckedChanged);
            // 
            // btn_clearHistory
            // 
            this.btn_clearHistory.Location = new System.Drawing.Point(1132, 72);
            this.btn_clearHistory.Name = "btn_clearHistory";
            this.btn_clearHistory.Size = new System.Drawing.Size(164, 23);
            this.btn_clearHistory.TabIndex = 10;
            this.btn_clearHistory.Text = "清空历史";
            this.btn_clearHistory.UseVisualStyleBackColor = true;
            // 
            // ViewHistoryFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_clearHistory);
            this.Controls.Add(this.ckb_showDownloaded);
            this.Name = "ViewHistoryFilter";
            this.Controls.SetChildIndex(this.cbb_buhao, 0);
            this.Controls.SetChildIndex(this.cbb_siju, 0);
            this.Controls.SetChildIndex(this.cbb_weijie, 0);
            this.Controls.SetChildIndex(this.cbb_yewu, 0);
            this.Controls.SetChildIndex(this.cbb_zidingyi, 0);
            this.Controls.SetChildIndex(this.cbb_sort, 0);
            this.Controls.SetChildIndex(this.ckb_showDownloaded, 0);
            this.Controls.SetChildIndex(this.btn_clearHistory, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckb_showDownloaded;
        private System.Windows.Forms.Button btn_clearHistory;
    }
}
