namespace CAAC_LawLibrary
{
    partial class AddNewComment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_title = new System.Windows.Forms.Panel();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            this.rtb_content = new System.Windows.Forms.RichTextBox();
            this.panel_title.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_title
            // 
            this.panel_title.Controls.Add(this.lbl_title);
            this.panel_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title.Location = new System.Drawing.Point(0, 0);
            this.panel_title.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_title.Name = "panel_title";
            this.panel_title.Size = new System.Drawing.Size(371, 52);
            this.panel_title.TabIndex = 0;
            // 
            // lbl_title
            // 
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(371, 52);
            this.lbl_title.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_cancel);
            this.panel1.Controls.Add(this.btn_submit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 263);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 52);
            this.panel1.TabIndex = 1;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_cancel.Location = new System.Drawing.Point(261, 8);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(83, 34);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_submit.Location = new System.Drawing.Point(147, 8);
            this.btn_submit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(83, 34);
            this.btn_submit.TabIndex = 0;
            this.btn_submit.Text = "确定";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // rtb_content
            // 
            this.rtb_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_content.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_content.Location = new System.Drawing.Point(0, 52);
            this.rtb_content.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtb_content.Name = "rtb_content";
            this.rtb_content.Size = new System.Drawing.Size(371, 211);
            this.rtb_content.TabIndex = 2;
            this.rtb_content.Text = "";
            // 
            // AddNewComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 315);
            this.Controls.Add(this.rtb_content);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "AddNewComment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "评论编写";
            this.panel_title.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtb_content;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_submit;
        public System.Windows.Forms.Panel panel_title;
        public System.Windows.Forms.Label lbl_title;
    }
}