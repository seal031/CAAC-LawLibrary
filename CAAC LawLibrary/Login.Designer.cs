namespace CAAC_LawLibrary
{
    partial class Login
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
            this.lbl_user = new System.Windows.Forms.Label();
            this.lbl_pwd = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cb_remindPwd = new System.Windows.Forms.CheckBox();
            this.btn_login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Location = new System.Drawing.Point(34, 48);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(41, 12);
            this.lbl_user.TabIndex = 0;
            this.lbl_user.Text = "用户ID";
            // 
            // lbl_pwd
            // 
            this.lbl_pwd.AutoSize = true;
            this.lbl_pwd.Location = new System.Drawing.Point(36, 88);
            this.lbl_pwd.Name = "lbl_pwd";
            this.lbl_pwd.Size = new System.Drawing.Size(29, 12);
            this.lbl_pwd.TabIndex = 1;
            this.lbl_pwd.Text = "密码";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 21);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(94, 84);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.ShortcutsEnabled = false;
            this.textBox2.Size = new System.Drawing.Size(128, 21);
            this.textBox2.TabIndex = 1;
            // 
            // cb_remindPwd
            // 
            this.cb_remindPwd.AutoSize = true;
            this.cb_remindPwd.Location = new System.Drawing.Point(38, 131);
            this.cb_remindPwd.Name = "cb_remindPwd";
            this.cb_remindPwd.Size = new System.Drawing.Size(72, 16);
            this.cb_remindPwd.TabIndex = 2;
            this.cb_remindPwd.Text = "记住密码";
            this.cb_remindPwd.UseVisualStyleBackColor = true;
            // 
            // btn_login
            // 
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.Location = new System.Drawing.Point(147, 167);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(75, 23);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            this.AcceptButton = this.btn_login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(275, 223);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.cb_remindPwd);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_pwd);
            this.Controls.Add(this.lbl_user);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Label lbl_pwd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox cb_remindPwd;
        private System.Windows.Forms.Button btn_login;
    }
}