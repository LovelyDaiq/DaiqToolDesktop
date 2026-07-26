using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DaiqDesktop
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        // ========== 登录 ==========
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "❌ 请输入用户名和密码";
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "登录中...";

            var result = DatabaseHelper.ValidateLogin(username, password);

            if (result.success)
            {
                Program.CurrentUsername = result.username;
                Program.CurrentUserId = result.userId;

                lblStatus.ForeColor = Color.FromArgb(0, 219, 222);
                lblStatus.Text = "✅ 登录成功！";

                var timer = new System.Windows.Forms.Timer { Interval = 500 };
                timer.Tick += (s, ev) =>
                {
                    timer.Stop();
                    this.Close();
                };
                timer.Start();
            }
            else
            {
                lblStatus.ForeColor = Color.FromArgb(255, 107, 107);
                lblStatus.Text = $"❌ {result.message}";
                btnLogin.Enabled = true;
                btnLogin.Text = "登 录";
            }
        }

        // ========== 注册 ==========
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "❌ 请输入用户名和密码";
                return;
            }

            if (username.Length < 3)
            {
                lblStatus.Text = "❌ 用户名至少3个字符";
                return;
            }

            if (password.Length < 6)
            {
                lblStatus.Text = "❌ 密码至少6个字符";
                return;
            }

            btnRegister.Enabled = false;
            btnRegister.Text = "注册中...";

            var result = DatabaseHelper.RegisterUser(username, password);

            if (result.success)
            {
                lblStatus.ForeColor = Color.FromArgb(0, 219, 222);
                lblStatus.Text = "✅ 注册成功！请登录";

                // 清空密码，方便直接登录
                txtPassword.Text = "";
                btnRegister.Enabled = true;
                btnRegister.Text = "注 册";
            }
            else
            {
                lblStatus.ForeColor = Color.FromArgb(255, 107, 107);
                lblStatus.Text = $"❌ {result.message}";
                btnRegister.Enabled = true;
                btnRegister.Text = "注 册";
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
