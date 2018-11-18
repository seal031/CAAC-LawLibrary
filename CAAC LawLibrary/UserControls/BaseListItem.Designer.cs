namespace CAAC_LawLibrary
{
    partial class BaseListItem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_state = new System.Windows.Forms.Label();
            this.lbl_downloadState = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_expiryDate = new System.Windows.Forms.Label();
            this.lbl_effectiveDate = new System.Windows.Forms.Label();
            this.lbl_businessType = new System.Windows.Forms.Label();
            this.lbl_organization = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lable1 = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbl_state);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1333, 50);
            this.panel1.TabIndex = 0;
            // 
            // lbl_state
            // 
            this.lbl_state.AutoSize = true;
            this.lbl_state.Location = new System.Drawing.Point(1210, 18);
            this.lbl_state.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_state.Name = "lbl_state";
            this.lbl_state.Size = new System.Drawing.Size(37, 15);
            this.lbl_state.TabIndex = 2;
            this.lbl_state.Text = "状态";
            // 
            // lbl_downloadState
            // 
            this.lbl_downloadState.AutoSize = true;
            this.lbl_downloadState.Location = new System.Drawing.Point(1262, 15);
            this.lbl_downloadState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_downloadState.Name = "lbl_downloadState";
            this.lbl_downloadState.Size = new System.Drawing.Size(67, 15);
            this.lbl_downloadState.TabIndex = 1;
            this.lbl_downloadState.Text = "下载状态";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(916, 18);
            this.lbl_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(37, 15);
            this.lbl_name.TabIndex = 0;
            this.lbl_name.Text = "名字";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_expiryDate);
            this.panel2.Controls.Add(this.lbl_downloadState);
            this.panel2.Controls.Add(this.lbl_effectiveDate);
            this.panel2.Controls.Add(this.lbl_businessType);
            this.panel2.Controls.Add(this.lbl_organization);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lable1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1333, 50);
            this.panel2.TabIndex = 1;
            // 
            // lbl_expiryDate
            // 
            this.lbl_expiryDate.AutoSize = true;
            this.lbl_expiryDate.Location = new System.Drawing.Point(315, 15);
            this.lbl_expiryDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_expiryDate.Name = "lbl_expiryDate";
            this.lbl_expiryDate.Size = new System.Drawing.Size(0, 15);
            this.lbl_expiryDate.TabIndex = 7;
            this.lbl_expiryDate.Visible = false;
            // 
            // lbl_effectiveDate
            // 
            this.lbl_effectiveDate.AutoSize = true;
            this.lbl_effectiveDate.Location = new System.Drawing.Point(117, 16);
            this.lbl_effectiveDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_effectiveDate.Name = "lbl_effectiveDate";
            this.lbl_effectiveDate.Size = new System.Drawing.Size(55, 15);
            this.lbl_effectiveDate.TabIndex = 6;
            this.lbl_effectiveDate.Text = "------";
            // 
            // lbl_businessType
            // 
            this.lbl_businessType.AutoSize = true;
            this.lbl_businessType.Location = new System.Drawing.Point(678, 15);
            this.lbl_businessType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_businessType.Name = "lbl_businessType";
            this.lbl_businessType.Size = new System.Drawing.Size(67, 15);
            this.lbl_businessType.TabIndex = 5;
            this.lbl_businessType.Text = "业务类型";
            // 
            // lbl_organization
            // 
            this.lbl_organization.AutoSize = true;
            this.lbl_organization.Location = new System.Drawing.Point(362, 15);
            this.lbl_organization.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_organization.Name = "lbl_organization";
            this.lbl_organization.Size = new System.Drawing.Size(37, 15);
            this.lbl_organization.TabIndex = 4;
            this.lbl_organization.Text = "单位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "失效日期：";
            this.label2.Visible = false;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(37, 15);
            this.lable1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(82, 15);
            this.lable1.TabIndex = 2;
            this.lable1.Text = "生效日期：";
            // 
            // lbl_title
            // 
            this.lbl_title.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_title.Location = new System.Drawing.Point(46, 9);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(846, 32);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "标题";
            // 
            // BaseListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "BaseListItem";
            this.Size = new System.Drawing.Size(1333, 100);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Label lbl_state;
        protected System.Windows.Forms.Label lbl_name;
        protected System.Windows.Forms.Label lbl_title;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label lable1;
        protected System.Windows.Forms.Label lbl_organization;
        protected System.Windows.Forms.Label lbl_businessType;
        protected internal System.Windows.Forms.Panel panel1;
        protected internal System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label lbl_effectiveDate;
        public System.Windows.Forms.Label lbl_expiryDate;
        public System.Windows.Forms.Label lbl_downloadState;
    }
}
