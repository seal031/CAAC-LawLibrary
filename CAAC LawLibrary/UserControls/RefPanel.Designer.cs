namespace CAAC_LawLibrary.UserControls
{
    partial class RefPanel
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
            this.lbl_close = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_yilai = new System.Windows.Forms.Label();
            this.ll_yilai = new System.Windows.Forms.LinkLabel();
            this.ll_zefa = new System.Windows.Forms.LinkLabel();
            this.lbl_zefa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_close
            // 
            this.lbl_close.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_close.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_close.Location = new System.Drawing.Point(383, 2);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(20, 23);
            this.lbl_close.TabIndex = 0;
            this.lbl_close.Text = "X";
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(177, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "引用";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "选中文字：";
            // 
            // lbl_yilai
            // 
            this.lbl_yilai.AutoSize = true;
            this.lbl_yilai.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_yilai.Location = new System.Drawing.Point(4, 75);
            this.lbl_yilai.Name = "lbl_yilai";
            this.lbl_yilai.Size = new System.Drawing.Size(54, 20);
            this.lbl_yilai.TabIndex = 3;
            this.lbl_yilai.Text = "依赖：";
            // 
            // ll_yilai
            // 
            this.ll_yilai.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ll_yilai.Location = new System.Drawing.Point(6, 98);
            this.ll_yilai.Name = "ll_yilai";
            this.ll_yilai.Size = new System.Drawing.Size(396, 58);
            this.ll_yilai.TabIndex = 4;
            this.ll_yilai.TabStop = true;
            this.ll_yilai.Text = " ";
            this.ll_yilai.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_yilai_LinkClicked);
            // 
            // ll_zefa
            // 
            this.ll_zefa.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ll_zefa.Location = new System.Drawing.Point(6, 187);
            this.ll_zefa.Name = "ll_zefa";
            this.ll_zefa.Size = new System.Drawing.Size(396, 58);
            this.ll_zefa.TabIndex = 6;
            this.ll_zefa.TabStop = true;
            this.ll_zefa.Text = " ";
            this.ll_zefa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_zefa_LinkClicked);
            // 
            // lbl_zefa
            // 
            this.lbl_zefa.AutoSize = true;
            this.lbl_zefa.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_zefa.Location = new System.Drawing.Point(4, 164);
            this.lbl_zefa.Name = "lbl_zefa";
            this.lbl_zefa.Size = new System.Drawing.Size(54, 20);
            this.lbl_zefa.TabIndex = 5;
            this.lbl_zefa.Text = "责罚：";
            // 
            // RefPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.ll_zefa);
            this.Controls.Add(this.lbl_zefa);
            this.Controls.Add(this.ll_yilai);
            this.Controls.Add(this.lbl_yilai);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_close);
            this.Name = "RefPanel";
            this.Size = new System.Drawing.Size(407, 278);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_yilai;
        private System.Windows.Forms.LinkLabel ll_yilai;
        private System.Windows.Forms.LinkLabel ll_zefa;
        private System.Windows.Forms.Label lbl_zefa;
    }
}
