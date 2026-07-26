using System.Drawing;

namespace DaiqDesktop
{
    public partial class LeaderboardForm : Form
    {
        public LeaderboardForm(List<ScoreRecord> records)
        {
            InitializeComponent();
            BuildUI(records);
        }

        private void BuildUI(List<ScoreRecord> records)
        {
            if (records.Count == 0)
            {
                listPanel.Controls.Add(new Label
                {
                    Text = "暂无记录，快来成为第一个！",
                    Font = new Font("微软雅黑", 14),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(80, 150)
                });
            }
            else
            {
                for (int i = 0; i < records.Count; i++)
                {
                    var rec = records[i];
                    var row = new Panel
                    {
                        Location = new Point(0, i * 45),
                        Size = new Size(400, 42),
                        BackColor = i % 2 == 0 ? Color.FromArgb(30, 40, 70) : Color.FromArgb(22, 33, 62)
                    };

                    Color rankColor = rec.Rank switch
                    {
                        1 => Color.Gold,
                        2 => Color.Silver,
                        3 => Color.FromArgb(205, 127, 50),
                        _ => Color.White
                    };

                    row.Controls.Add(new Label
                    {
                        Text = rec.Rank.ToString(),
                        Font = new Font("微软雅黑", 14, rec.Rank <= 3 ? FontStyle.Bold : FontStyle.Regular),
                        ForeColor = rankColor,
                        AutoSize = true,
                        Location = new Point(25, 8)
                    });

                    row.Controls.Add(new Label
                    {
                        Text = rec.Username,
                        Font = new Font("微软雅黑", 12),
                        ForeColor = Color.White,
                        AutoSize = true,
                        Location = new Point(110, 10)
                    });

                    row.Controls.Add(new Label
                    {
                        Text = rec.Score.ToString(),
                        Font = new Font("微软雅黑", 12, FontStyle.Bold),
                        ForeColor = Color.FromArgb(0, 219, 222),
                        AutoSize = true,
                        Location = new Point(260, 10)
                    });

                    row.Controls.Add(new Label
                    {
                        Text = rec.Date.ToString("MM-dd"),
                        Font = new Font("微软雅黑", 10),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Location = new Point(340, 12)
                    });

                    listPanel.Controls.Add(row);
                }
            }

            int myBest = DatabaseHelper.GetUserBestScore(Program.CurrentUserId);
            lblMyBest.Text = $"我的最佳: {myBest} 分";
        }
    }
}
