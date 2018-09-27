namespace CAAC_LawLibrary
{
    partial class DownloadListItem
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
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.ckb = new System.Windows.Forms.CheckBox();
            this.lbl_delete = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_delete);
            this.panel1.Controls.SetChildIndex(this.lbl_name, 0);
            this.panel1.Controls.SetChildIndex(this.lbl_downloadState, 0);
            this.panel1.Controls.SetChildIndex(this.lbl_state, 0);
            this.panel1.Controls.SetChildIndex(this.lbl_delete, 0);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ckb);
            this.panel2.Controls.SetChildIndex(this.lbl_effectiveDate, 0);
            this.panel2.Controls.SetChildIndex(this.lbl_expiryDate, 0);
            this.panel2.Controls.SetChildIndex(this.lbl_title, 0);
            this.panel2.Controls.SetChildIndex(this.lable1, 0);
            this.panel2.Controls.SetChildIndex(this.label2, 0);
            this.panel2.Controls.SetChildIndex(this.lbl_organization, 0);
            this.panel2.Controls.SetChildIndex(this.lbl_businessType, 0);
            this.panel2.Controls.SetChildIndex(this.ckb, 0);
            // 
            // ckb
            // 
            this.ckb.AutoSize = true;
            this.ckb.Location = new System.Drawing.Point(14, 6);
            this.ckb.Margin = new System.Windows.Forms.Padding(2);
            this.ckb.Name = "ckb";
            this.ckb.Size = new System.Drawing.Size(15, 14);
            this.ckb.TabIndex = 7;
            this.ckb.UseVisualStyleBackColor = true;
            this.ckb.CheckedChanged += new System.EventHandler(this.ckb_CheckedChanged);
            // 
            // lbl_delete
            // 
            this.lbl_delete.AutoSize = true;
            this.lbl_delete.Location = new System.Drawing.Point(940, 14);
            this.lbl_delete.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_delete.Name = "lbl_delete";
            this.lbl_delete.Size = new System.Drawing.Size(53, 12);
            this.lbl_delete.TabIndex = 4;
            this.lbl_delete.TabStop = true;
            this.lbl_delete.Text = "删除任务";
            this.lbl_delete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_delete_LinkClicked);
            // 
            // DownloadListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DownloadListItem";
            this.Load += new System.EventHandler(this.DownloadListItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker bgw;
        public System.Windows.Forms.CheckBox ckb;
        private System.Windows.Forms.LinkLabel lbl_delete;
    }
}
