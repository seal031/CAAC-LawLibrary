namespace CAAC_LawLibrary.UserControls
{
    partial class CommentItem
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
            this.lbl_node = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.lbl_content = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_node
            // 
            this.lbl_node.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_node.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_node.Location = new System.Drawing.Point(0, 0);
            this.lbl_node.Name = "lbl_node";
            this.lbl_node.Size = new System.Drawing.Size(250, 25);
            this.lbl_node.TabIndex = 0;
            this.lbl_node.Text = "label1";
            // 
            // lbl_user
            // 
            this.lbl_user.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbl_user.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_user.Location = new System.Drawing.Point(0, 170);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(250, 30);
            this.lbl_user.TabIndex = 1;
            this.lbl_user.Text = "label2";
            // 
            // lbl_content
            // 
            this.lbl_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_content.Location = new System.Drawing.Point(0, 25);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Size = new System.Drawing.Size(250, 145);
            this.lbl_content.TabIndex = 2;
            this.lbl_content.Text = "label3";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Location = new System.Drawing.Point(227, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "评";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // CommentItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_content);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.lbl_node);
            this.Name = "CommentItem";
            this.Size = new System.Drawing.Size(250, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_node;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label lbl_content;
        private System.Windows.Forms.Label label1;
    }
}
