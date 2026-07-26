using System.Drawing;
using System.Drawing.Drawing2D;

namespace DaiqDesktop
{
    public partial class Form2 : Form
    {
        // ========== 游戏配置（常量可以保留）==========
        private const int GridSize = 20;
        private const int TileCount = 30;
        private const int CanvasSize = GridSize * TileCount;
        private const int BaseSpeed = 150;
        private const int SpeedIncrease = 5;
        private const int WinScore = 50;

        // ========== 游戏状态（这些字段Form2.Designer.cs里没有，保留）==========
        private List<Point> snake = new();
        private Point food;
        private int dx = 1, dy = 0;
        private int score = 0;
        private bool isGameOver = false;
        private bool isPaused = false;
        private System.Windows.Forms.Timer gameTimer = new();

        public Form2()
        {
            InitializeComponent();
            InitGame();
        }

        private void InitGame()
        {
            snake = new List<Point> { new Point(15, 15) };
            dx = 1; dy = 0;
            score = 0;
            isGameOver = false;
            isPaused = false;
            GenerateFood();
            canvas.Invalidate();
            gameTimer = new System.Windows.Forms.Timer();
            gameTimer.Tick += GameTimer_Tick;
        }

        private void StartGame()
        {
            if (gameTimer.Enabled) return;
            InitGame();
            gameTimer.Interval = BaseSpeed;
            gameTimer.Start();
            btnStart.Enabled = false;
            btnStart.Text = "游戏中...";
            this.Focus();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (isPaused) return;
            MoveSnake();
            canvas.Invalidate();
        }

        private void MoveSnake()
        {
            Point head = new Point(snake[0].X + dx, snake[0].Y + dy);

            if (head.X < 0) head.X = TileCount - 1;
            if (head.X >= TileCount) head.X = 0;
            if (head.Y < 0) head.Y = TileCount - 1;
            if (head.Y >= TileCount) head.Y = 0;

            if (snake.Contains(head))
            {
                EndGame(false);
                return;
            }

            snake.Insert(0, head);

            if (head == food)
            {
                score++;
                lblScore.Text = $"分数: {score}";
                int newSpeed = BaseSpeed - (score * SpeedIncrease);
                if (newSpeed > 50) gameTimer.Interval = newSpeed;
                if (score >= WinScore) { EndGame(true); return; }
                GenerateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }
        }

        private void GenerateFood()
        {
            Random rand = new Random();
            do { food = new Point(rand.Next(TileCount), rand.Next(TileCount)); }
            while (snake.Contains(food));
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var pen = new Pen(Color.FromArgb(30, 255, 255, 255)))
            {
                for (int i = 0; i <= TileCount; i++)
                {
                    g.DrawLine(pen, i * GridSize, 0, i * GridSize, CanvasSize);
                    g.DrawLine(pen, 0, i * GridSize, CanvasSize, i * GridSize);
                }
            }

            for (int i = 0; i < snake.Count; i++)
            {
                var rect = new Rectangle(snake[i].X * GridSize + 1, snake[i].Y * GridSize + 1, GridSize - 2, GridSize - 2);
                if (i == 0)
                {
                    using var brush = new SolidBrush(Color.FromArgb(0, 219, 222));
                    g.FillEllipse(brush, rect);
                    g.FillEllipse(Brushes.White, rect.X + 3, rect.Y + 3, 5, 5);
                    g.FillEllipse(Brushes.White, rect.X + 10, rect.Y + 3, 5, 5);
                    g.FillEllipse(Brushes.Black, rect.X + 4, rect.Y + 4, 3, 3);
                    g.FillEllipse(Brushes.Black, rect.X + 11, rect.Y + 4, 3, 3);
                }
                else
                {
                    int alpha = Math.Max(100, 255 - i * 5);
                    using var brush = new SolidBrush(Color.FromArgb(alpha, 0, 206, 201));
                    g.FillRectangle(brush, rect);
                }
            }

            var foodRect = new Rectangle(food.X * GridSize + 2, food.Y * GridSize + 2, GridSize - 4, GridSize - 4);
            using (var foodBrush = new SolidBrush(Color.FromArgb(255, 107, 107)))
                g.FillEllipse(foodBrush, foodRect);
            using (var highlightBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255)))
                g.FillEllipse(highlightBrush, foodRect.X + 2, foodRect.Y + 2, 6, 6);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (isGameOver && !panelGameOver.Visible) return base.ProcessCmdKey(ref msg, keyData);
            switch (keyData)
            {
                case Keys.Up: if (dy != 1) { dx = 0; dy = -1; } return true;
                case Keys.Down: if (dy != -1) { dx = 0; dy = 1; } return true;
                case Keys.Left: if (dx != 1) { dx = -1; dy = 0; } return true;
                case Keys.Right: if (dx != -1) { dx = 1; dy = 0; } return true;
                case Keys.Space:
                    if (gameTimer.Enabled)
                    {
                        isPaused = !isPaused;
                        lblScore.Text = isPaused ? $"分数: {score} (暂停)" : $"分数: {score}";
                    }
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void EndGame(bool isWin)
        {
            gameTimer.Stop();
            isGameOver = true;
            btnStart.Enabled = true;
            btnStart.Text = "▶ 开始游戏";

            if (score > 0)
            {
                DatabaseHelper.SubmitScore(Program.CurrentUserId, Program.CurrentUsername ?? "", score);
                int best = DatabaseHelper.GetUserBestScore(Program.CurrentUserId);
                lblBest.Text = $"最佳: {best}";
            }

            lblFinalScore.Text = $"最终分数: {score}";
            lblFinalScore.ForeColor = isWin ? Color.FromArgb(0, 219, 222) : Color.FromArgb(255, 107, 107);

            lblGameOverTitle.Text = isWin ? "🎉 游戏胜利！" : "😞 游戏结束";
            lblGameOverTitle.ForeColor = isWin ? Color.FromArgb(0, 219, 222) : Color.FromArgb(255, 107, 107);

            panelGameOver.Visible = true;
            panelGameOver.BringToFront();
        }

        private void BtnLeaderboard_Click(object sender, EventArgs e)
        {
            var leaderboard = DatabaseHelper.GetLeaderboard();
            var form = new LeaderboardForm(leaderboard);
            form.ShowDialog(this);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出登录吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gameTimer?.Stop();
                Program.CurrentUsername = null;
                Program.CurrentUserId = 0;
                this.Close();
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameTimer?.Stop();
        }
    }
}
