﻿namespace CAAC_LawLibrary.UserControls
{
    partial class TagLabel
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
            this.lbl_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_label
            // 
            this.lbl_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_label.Location = new System.Drawing.Point(0, 0);
            this.lbl_label.Name = "lbl_label";
            this.lbl_label.Size = new System.Drawing.Size(15, 15);
            this.lbl_label.TabIndex = 0;
            this.lbl_label.TextChanged += new System.EventHandler(this.lbl_label_TextChanged);
            this.lbl_label.Click += new System.EventHandler(this.lbl_label_Click);
            // 
            // TagLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_label);
            this.Name = "TagLabel";
            this.Size = new System.Drawing.Size(15, 15);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbl_label;
    }
}
