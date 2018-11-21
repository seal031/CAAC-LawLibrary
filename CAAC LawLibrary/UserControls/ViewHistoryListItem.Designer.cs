namespace CAAC_LawLibrary
{
    partial class ViewHistoryListItem
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
            this.lbl_version = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Size = new System.Drawing.Size(39, 20);
            // 
            // lbl_title
            // 
            this.lbl_title.Click += new System.EventHandler(this.lbl_title_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_version);
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Controls.SetChildIndex(this.lbl_title, 0);
            this.panel1.Controls.SetChildIndex(this.lbl_name, 0);
            this.panel1.Controls.SetChildIndex(this.lbl_state, 0);
            this.panel1.Controls.SetChildIndex(this.lbl_version, 0);
            // 
            // panel2
            // 
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // lbl_downloadState
            // 
            this.lbl_downloadState.AutoSize = true;
            this.lbl_downloadState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_downloadState.Size = new System.Drawing.Size(69, 20);
            this.lbl_downloadState.Click += new System.EventHandler(this.lbl_downloadState_Click);
            // 
            // lbl_version
            // 
            this.lbl_version.AutoSize = true;
            this.lbl_version.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_version.Location = new System.Drawing.Point(1271, 18);
            this.lbl_version.Name = "lbl_version";
            this.lbl_version.Size = new System.Drawing.Size(53, 20);
            this.lbl_version.TabIndex = 3;
            this.lbl_version.Text = "label1";
            // 
            // ViewHistoryListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ViewHistoryListItem";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_version;
    }
}
