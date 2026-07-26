using System.Diagnostics;

namespace DaiqDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://space.bilibili.com/3493082643302614";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开浏览器: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = "https://v.douyin.com/UY0AWtnED4A/";
            try
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("无法打开浏览器: " + ex.Message);
            }
        }

        // ========== button3：进入游戏（需先登录）==========
        private void button3_Click(object sender, EventArgs e)
        {
            // 检查是否已登录
            if (!Program.IsLoggedIn)
            {
                MessageBox.Show("请先登录后再进入游戏！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 未登录，跳转到登录页面 Form3
                Form3 form3 = new Form3();
                form3.FormClosed += (s, ev) => this.Show(); // 登录窗关闭后显示 Form1
                form3.Show();
                this.Hide();
                return;
            }

            // 已登录，直接进入游戏
            Form2 form2 = new Form2();
            form2.FormClosed += (s, ev) => this.Show(); // 游戏窗关闭后显示 Form1
            form2.Show();
            this.Hide();
        }

        // ========== button4：打开登录页面 ==========
        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.FormClosed += (s, ev) => this.Show(); // 登录窗关闭后显示 Form1
            form3.Show();
            this.Hide();
        }
    }
}
