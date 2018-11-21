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
            this.ccb_version = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Size = new System.Drawing.Size(39, 20);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ckb);
            this.panel1.Controls.Add(this.ccb_version);
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            this.panel1.Controls.SetChildIndex(this.lbl_title, 0);
            this.panel1.Controls.SetChildIndex(this.lbl_name, 0);
            this.panel1.Controls.SetChildIndex(this.lbl_state, 0);
            this.panel1.Controls.SetChildIndex(this.ccb_version, 0);
            this.panel1.Controls.SetChildIndex(this.ckb, 0);
            // 
            // panel2
            // 
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // lbl_downloadState
            // 
            this.lbl_downloadState.AutoEllipsis = true;
            this.lbl_downloadState.AutoSize = true;
            this.lbl_downloadState.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_downloadState.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_downloadState.Size = new System.Drawing.Size(69, 20);
            this.lbl_downloadState.Click += new System.EventHandler(this.lbl_downloadState_Click);
            // 
            // ckb
            // 
            this.ckb.AutoSize = true;
            this.ckb.Location = new System.Drawing.Point(21, 15);
            this.ckb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ckb.Name = "ckb";
            this.ckb.Size = new System.Drawing.Size(18, 17);
            this.ckb.TabIndex = 6;
            this.ckb.UseVisualStyleBackColor = true;
            this.ckb.CheckedChanged += new System.EventHandler(this.ckb_CheckedChanged);
            // 
            // ccb_version
            // 
            this.ccb_version.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ccb_version.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ccb_version.FormattingEnabled = true;
            this.ccb_version.Location = new System.Drawing.Point(1269, 14);
            this.ccb_version.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ccb_version.Name = "ccb_version";
            this.ccb_version.Size = new System.Drawing.Size(53, 28);
            this.ccb_version.TabIndex = 3;
            this.ccb_version.SelectedIndexChanged += new System.EventHandler(this.ccb_version_SelectedIndexChanged);
            // 
            // LawListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LawListItem";
            this.Load += new System.EventHandler(this.LawListItem_Load);
            this.Click += new System.EventHandler(this.LawListItem_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox ckb;
        private System.Windows.Forms.ComboBox ccb_version;
    }
}
