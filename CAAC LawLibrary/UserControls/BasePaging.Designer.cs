namespace CAAC_LawLibrary.UserControls
{
    partial class BasePaging
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
            this.ll_p = new System.Windows.Forms.LinkLabel();
            this.ll_n = new System.Windows.Forms.LinkLabel();
            this.lbl_page = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_page = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_skip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_page)).BeginInit();
            this.SuspendLayout();
            // 
            // ll_p
            // 
            this.ll_p.AutoSize = true;
            this.ll_p.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ll_p.Location = new System.Drawing.Point(11, 10);
            this.ll_p.Name = "ll_p";
            this.ll_p.Size = new System.Drawing.Size(54, 20);
            this.ll_p.TabIndex = 0;
            this.ll_p.TabStop = true;
            this.ll_p.Text = "上一页";
            // 
            // ll_n
            // 
            this.ll_n.AutoSize = true;
            this.ll_n.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ll_n.Location = new System.Drawing.Point(75, 10);
            this.ll_n.Name = "ll_n";
            this.ll_n.Size = new System.Drawing.Size(54, 20);
            this.ll_n.TabIndex = 1;
            this.ll_n.TabStop = true;
            this.ll_n.Text = "下一页";
            // 
            // lbl_page
            // 
            this.lbl_page.AutoSize = true;
            this.lbl_page.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_page.Location = new System.Drawing.Point(147, 10);
            this.lbl_page.Name = "lbl_page";
            this.lbl_page.Size = new System.Drawing.Size(45, 20);
            this.lbl_page.TabIndex = 2;
            this.lbl_page.Text = "第/页";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(221, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "跳转至第";
            // 
            // nud_page
            // 
            this.nud_page.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nud_page.Location = new System.Drawing.Point(291, 5);
            this.nud_page.Name = "nud_page";
            this.nud_page.Size = new System.Drawing.Size(46, 27);
            this.nud_page.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(344, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "页";
            // 
            // btn_skip
            // 
            this.btn_skip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_skip.Location = new System.Drawing.Point(372, 3);
            this.btn_skip.Name = "btn_skip";
            this.btn_skip.Size = new System.Drawing.Size(53, 29);
            this.btn_skip.TabIndex = 6;
            this.btn_skip.Text = "跳转";
            this.btn_skip.UseVisualStyleBackColor = true;
            // 
            // BasePaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_skip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nud_page);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_page);
            this.Controls.Add(this.ll_n);
            this.Controls.Add(this.ll_p);
            this.Name = "BasePaging";
            this.Size = new System.Drawing.Size(1049, 35);
            ((System.ComponentModel.ISupportInitialize)(this.nud_page)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.LinkLabel ll_p;
        public System.Windows.Forms.LinkLabel ll_n;
        public System.Windows.Forms.Label lbl_page;
        public System.Windows.Forms.NumericUpDown nud_page;
        public System.Windows.Forms.Button btn_skip;
    }
}
