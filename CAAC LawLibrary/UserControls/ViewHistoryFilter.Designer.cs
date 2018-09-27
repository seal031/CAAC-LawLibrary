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
            CAAC_LawLibrary.Entity.Code code1 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code2 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code3 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code4 = new CAAC_LawLibrary.Entity.Code();
            CAAC_LawLibrary.Entity.Code code5 = new CAAC_LawLibrary.Entity.Code();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewHistoryFilter));
            this.ckb_showDownloaded = new System.Windows.Forms.CheckBox();
            this.btn_clearHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbb_buhao
            // 
            this.cbb_buhao.DisplayMember = "desc";
            code1.desc = "不限部号范围";
            code1.Id = null;
            code1.order = 0;
            code1.type = null;
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
            // ckb_showDownloaded
            // 
            this.ckb_showDownloaded.AutoSize = true;
            this.ckb_showDownloaded.Location = new System.Drawing.Point(19, 59);
            this.ckb_showDownloaded.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckb_showDownloaded.Name = "ckb_showDownloaded";
            this.ckb_showDownloaded.Size = new System.Drawing.Size(96, 16);
            this.ckb_showDownloaded.TabIndex = 9;
            this.ckb_showDownloaded.Text = "仅显示已下载";
            this.ckb_showDownloaded.UseVisualStyleBackColor = true;
            this.ckb_showDownloaded.CheckedChanged += new System.EventHandler(this.ckb_showDownloaded_CheckedChanged);
            // 
            // btn_clearHistory
            // 
            this.btn_clearHistory.Location = new System.Drawing.Point(849, 58);
            this.btn_clearHistory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_clearHistory.Name = "btn_clearHistory";
            this.btn_clearHistory.Size = new System.Drawing.Size(123, 24);
            this.btn_clearHistory.TabIndex = 10;
            this.btn_clearHistory.Text = "清空历史";
            this.btn_clearHistory.UseVisualStyleBackColor = true;
            this.btn_clearHistory.Click += new System.EventHandler(this.btn_clearHistory_Click);
            // 
            // ViewHistoryFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
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
