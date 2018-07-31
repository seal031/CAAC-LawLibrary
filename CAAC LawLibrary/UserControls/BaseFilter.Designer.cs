namespace CAAC_LawLibrary
{
    partial class BaseFilter
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
            this.cbb_buhao = new System.Windows.Forms.ComboBox();
            this.cbb_siju = new System.Windows.Forms.ComboBox();
            this.cbb_weijie = new System.Windows.Forms.ComboBox();
            this.cbb_yewu = new System.Windows.Forms.ComboBox();
            this.cbb_zidingyi = new System.Windows.Forms.ComboBox();
            this.cbb_sort = new System.Windows.Forms.ComboBox();
            this.txt_keyword = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbb_buhao
            // 
            this.cbb_buhao.FormattingEnabled = true;
            this.cbb_buhao.Location = new System.Drawing.Point(25, 20);
            this.cbb_buhao.Name = "cbb_buhao";
            this.cbb_buhao.Size = new System.Drawing.Size(229, 23);
            this.cbb_buhao.TabIndex = 0;
            this.cbb_buhao.SelectedIndexChanged += new System.EventHandler(this.cbb_buhao_SelectedIndexChanged);
            // 
            // cbb_siju
            // 
            this.cbb_siju.FormattingEnabled = true;
            this.cbb_siju.Location = new System.Drawing.Point(291, 20);
            this.cbb_siju.Name = "cbb_siju";
            this.cbb_siju.Size = new System.Drawing.Size(143, 23);
            this.cbb_siju.TabIndex = 1;
            this.cbb_siju.SelectedIndexChanged += new System.EventHandler(this.cbb_siju_SelectedIndexChanged);
            // 
            // cbb_weijie
            // 
            this.cbb_weijie.FormattingEnabled = true;
            this.cbb_weijie.Location = new System.Drawing.Point(466, 20);
            this.cbb_weijie.Name = "cbb_weijie";
            this.cbb_weijie.Size = new System.Drawing.Size(145, 23);
            this.cbb_weijie.TabIndex = 2;
            this.cbb_weijie.SelectedIndexChanged += new System.EventHandler(this.cbb_weijie_SelectedIndexChanged);
            // 
            // cbb_yewu
            // 
            this.cbb_yewu.FormattingEnabled = true;
            this.cbb_yewu.Location = new System.Drawing.Point(636, 20);
            this.cbb_yewu.Name = "cbb_yewu";
            this.cbb_yewu.Size = new System.Drawing.Size(149, 23);
            this.cbb_yewu.TabIndex = 3;
            this.cbb_yewu.SelectedIndexChanged += new System.EventHandler(this.cbb_yewu_SelectedIndexChanged);
            // 
            // cbb_zidingyi
            // 
            this.cbb_zidingyi.FormattingEnabled = true;
            this.cbb_zidingyi.Location = new System.Drawing.Point(817, 20);
            this.cbb_zidingyi.Name = "cbb_zidingyi";
            this.cbb_zidingyi.Size = new System.Drawing.Size(150, 23);
            this.cbb_zidingyi.TabIndex = 4;
            this.cbb_zidingyi.SelectedIndexChanged += new System.EventHandler(this.cbb_zidingyi_SelectedIndexChanged);
            // 
            // cbb_sort
            // 
            this.cbb_sort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_sort.FormattingEnabled = true;
            this.cbb_sort.Location = new System.Drawing.Point(1132, 20);
            this.cbb_sort.Name = "cbb_sort";
            this.cbb_sort.Size = new System.Drawing.Size(164, 23);
            this.cbb_sort.TabIndex = 5;
            // 
            // txt_keyword
            // 
            this.txt_keyword.Location = new System.Drawing.Point(467, 71);
            this.txt_keyword.Name = "txt_keyword";
            this.txt_keyword.Size = new System.Drawing.Size(328, 25);
            this.txt_keyword.TabIndex = 6;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(817, 71);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 7;
            this.btn_search.Text = "搜索";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // BaseFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_keyword);
            this.Controls.Add(this.cbb_sort);
            this.Controls.Add(this.cbb_zidingyi);
            this.Controls.Add(this.cbb_yewu);
            this.Controls.Add(this.cbb_weijie);
            this.Controls.Add(this.cbb_siju);
            this.Controls.Add(this.cbb_buhao);
            this.Name = "BaseFilter";
            this.Size = new System.Drawing.Size(1333, 123);
            this.Load += new System.EventHandler(this.BaseFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ComboBox cbb_buhao;
        protected System.Windows.Forms.ComboBox cbb_siju;
        protected System.Windows.Forms.ComboBox cbb_weijie;
        protected System.Windows.Forms.ComboBox cbb_yewu;
        protected System.Windows.Forms.ComboBox cbb_zidingyi;
        protected System.Windows.Forms.ComboBox cbb_sort;
        private System.Windows.Forms.TextBox txt_keyword;
        private System.Windows.Forms.Button btn_search;
    }
}
