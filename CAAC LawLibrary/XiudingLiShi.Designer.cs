namespace CAAC_LawLibrary
{
    partial class XiudingLiShi
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
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.rtb_title = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb
            // 
            this.rtb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtb.Enabled = false;
            this.rtb.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb.Location = new System.Drawing.Point(0, 64);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(476, 390);
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            // 
            // rtb_title
            // 
            this.rtb_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtb_title.Enabled = false;
            this.rtb_title.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rtb_title.Location = new System.Drawing.Point(0, 0);
            this.rtb_title.Name = "rtb_title";
            this.rtb_title.Size = new System.Drawing.Size(476, 65);
            this.rtb_title.TabIndex = 1;
            this.rtb_title.Text = "修订记录";
            // 
            // XiudingLiShi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 454);
            this.Controls.Add(this.rtb_title);
            this.Controls.Add(this.rtb);
            this.MaximizeBox = false;
            this.Name = "XiudingLiShi";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修订历史页";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtb;
        public System.Windows.Forms.RichTextBox rtb_title;
    }
}