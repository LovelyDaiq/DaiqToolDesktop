namespace DaiqDesktop
{
    partial class Form3
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSub = new Label();
            lblUser = new Label();
            txtUsername = new TextBox();
            lblPass = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnRegister = new Button();
            btnBack = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("微软雅黑", 28F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblTitle.ForeColor = Color.FromArgb(0, 219, 222);
            lblTitle.Location = new Point(150, 42);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(192, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "登录/注册";
            // 
            // lblSub
            // 
            lblSub.AutoSize = true;
            lblSub.Font = new Font("微软雅黑", 14F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblSub.ForeColor = Color.FromArgb(150, 150, 150);
            lblSub.Location = new Point(93, 113);
            lblSub.Margin = new Padding(4, 0, 4, 0);
            lblSub.Name = "lblSub";
            lblSub.Size = new Size(291, 25);
            lblSub.TabIndex = 1;
            lblSub.Text = "DaiqToolDesktop登入/注册服务";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(93, 184);
            lblUser.Margin = new Padding(4, 0, 4, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(58, 21);
            lblUser.TabIndex = 2;
            lblUser.Text = "用户名";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(45, 45, 80);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtUsername.ForeColor = Color.White;
            txtUsername.Location = new Point(93, 227);
            txtUsername.Margin = new Padding(4, 4, 4, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(326, 29);
            txtUsername.TabIndex = 3;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblPass.ForeColor = Color.White;
            lblPass.Location = new Point(93, 298);
            lblPass.Margin = new Padding(4, 0, 4, 0);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(42, 21);
            lblPass.TabIndex = 4;
            lblPass.Text = "密码";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(45, 45, 80);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            txtPassword.ForeColor = Color.White;
            txtPassword.Location = new Point(93, 340);
            txtPassword.Margin = new Padding(4, 4, 4, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(326, 29);
            txtPassword.TabIndex = 5;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 184, 148);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("微软雅黑", 14F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(93, 425);
            btnLogin.Margin = new Padding(4, 4, 4, 4);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(158, 64);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "登 录";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(102, 126, 234);
            btnRegister.Cursor = Cursors.Hand;
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("微软雅黑", 14F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(262, 425);
            btnRegister.Margin = new Padding(4, 4, 4, 4);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(158, 64);
            btnRegister.TabIndex = 7;
            btnRegister.Text = "注 册";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(100, 100, 120);
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(93, 517);
            btnBack.Margin = new Padding(4, 4, 4, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(327, 50);
            btnBack.TabIndex = 8;
            btnBack.Text = " 返回主页";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("微软雅黑", 10F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblStatus.ForeColor = Color.FromArgb(255, 107, 107);
            lblStatus.Location = new Point(93, 595);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 20);
            lblStatus.TabIndex = 9;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 46);
            ClientSize = new Size(525, 680);
            Controls.Add(lblStatus);
            Controls.Add(btnBack);
            Controls.Add(btnRegister);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPass);
            Controls.Add(txtUsername);
            Controls.Add(lblUser);
            Controls.Add(lblSub);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            Name = "Form3";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "登录/注册";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSub;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblStatus;
    }
}
