namespace CAAC_LawLibrary
{
    partial class LawListItem
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
            this.ckb = new System.Windows.Forms.CheckBox();
            this.lbl_delete = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.Click += new System.EventHandler(this.lbl_title_Click);
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
            this.panel2.Controls.SetChildIndex(this.lbl_title, 0);
            this.panel2.Controls.SetChildIndex(this.lbl_effectiveDate, 0);
            this.panel2.Controls.SetChildIndex(this.lbl_expiryDate, 0);
            this.panel2.Controls.SetChildIndex(this.lbl_organization, 0);
            this.panel2.Controls.SetChildIndex(this.lbl_businessType, 0);
            this.panel2.Controls.SetChildIndex(this.ckb, 0);
            // 
            // ckb
            // 
            this.ckb.AutoSize = true;
            this.ckb.Location = new System.Drawing.Point(18, 7);
            this.ckb.Name = "ckb";
            this.ckb.Size = new System.Drawing.Size(18, 17);
            this.ckb.TabIndex = 6;
            this.ckb.UseVisualStyleBackColor = true;
            // 
            // lbl_delete
            // 
            this.lbl_delete.AutoSize = true;
            this.lbl_delete.Location = new System.Drawing.Point(1249, 18);
            this.lbl_delete.Name = "lbl_delete";
            this.lbl_delete.Size = new System.Drawing.Size(67, 15);
            this.lbl_delete.TabIndex = 3;
            this.lbl_delete.TabStop = true;
            this.lbl_delete.Text = "删除任务";
            // 
            // LawListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "LawListItem";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox ckb;
        private System.Windows.Forms.LinkLabel lbl_delete;
    }
}
