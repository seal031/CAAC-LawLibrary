namespace CAAC_LawLibrary
{
    partial class SuggestItem
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
            this.lbl_lawNo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtb_remark = new System.Windows.Forms.RichTextBox();
            this.rtb_suggest = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_lawNo
            // 
            this.lbl_lawNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_lawNo.Location = new System.Drawing.Point(0, 0);
            this.lbl_lawNo.Name = "lbl_lawNo";
            this.lbl_lawNo.Size = new System.Drawing.Size(780, 23);
            this.lbl_lawNo.TabIndex = 0;
            this.lbl_lawNo.Text = "条款号:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtb_suggest);
            this.panel1.Controls.Add(this.rtb_remark);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 127);
            this.panel1.TabIndex = 1;
            // 
            // rtb_remark
            // 
            this.rtb_remark.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtb_remark.Location = new System.Drawing.Point(520, 0);
            this.rtb_remark.Name = "rtb_remark";
            this.rtb_remark.Size = new System.Drawing.Size(260, 127);
            this.rtb_remark.TabIndex = 0;
            this.rtb_remark.Text = "备注";
            // 
            // rtb_suggest
            // 
            this.rtb_suggest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_suggest.Location = new System.Drawing.Point(0, 0);
            this.rtb_suggest.Name = "rtb_suggest";
            this.rtb_suggest.Size = new System.Drawing.Size(520, 127);
            this.rtb_suggest.TabIndex = 1;
            this.rtb_suggest.Text = "意见建议";
            // 
            // SuggestItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_lawNo);
            this.Name = "SuggestItem";
            this.Size = new System.Drawing.Size(780, 150);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_lawNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtb_suggest;
        private System.Windows.Forms.RichTextBox rtb_remark;
    }
}
