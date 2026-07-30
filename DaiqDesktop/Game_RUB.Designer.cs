namespace DaiqDesktop
{
    partial class Game_RUB
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox gameBoard;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label linesLabel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.Label nextLabel;
        private System.Windows.Forms.PictureBox nextPieceBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Label controlLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            gameTimer = new System.Windows.Forms.Timer(components);
            gameBoard = new PictureBox();
            scoreLabel = new Label();
            linesLabel = new Label();
            levelLabel = new Label();
            nextLabel = new Label();
            nextPieceBox = new PictureBox();
            titleLabel = new Label();
            infoPanel = new Panel();
            controlLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)gameBoard).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nextPieceBox).BeginInit();
            infoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Interval = 800;
            gameTimer.Tick += GameTimer_Tick;
            // 
            // gameBoard
            // 
            gameBoard.Location = new Point(23, 26);
            gameBoard.Margin = new Padding(4);
            gameBoard.Name = "gameBoard";
            gameBoard.Size = new Size(350, 785);
            gameBoard.TabIndex = 0;
            gameBoard.TabStop = false;
            gameBoard.Paint += GameBoard_Paint;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Courier New", 14F, FontStyle.Bold);
            scoreLabel.ForeColor = Color.White;
            scoreLabel.Location = new Point(12, 105);
            scoreLabel.Margin = new Padding(4, 0, 4, 0);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(98, 22);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "SCORE: 0";
            // 
            // linesLabel
            // 
            linesLabel.AutoSize = true;
            linesLabel.Font = new Font("Courier New", 14F, FontStyle.Bold);
            linesLabel.ForeColor = Color.White;
            linesLabel.Location = new Point(12, 157);
            linesLabel.Margin = new Padding(4, 0, 4, 0);
            linesLabel.Name = "linesLabel";
            linesLabel.Size = new Size(98, 22);
            linesLabel.TabIndex = 2;
            linesLabel.Text = "LINES: 0";
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Font = new Font("Courier New", 14F, FontStyle.Bold);
            levelLabel.ForeColor = Color.White;
            levelLabel.Location = new Point(12, 209);
            levelLabel.Margin = new Padding(4, 0, 4, 0);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(98, 22);
            levelLabel.TabIndex = 3;
            levelLabel.Text = "LEVEL: 1";
            // 
            // nextLabel
            // 
            nextLabel.AutoSize = true;
            nextLabel.Font = new Font("Courier New", 14F, FontStyle.Bold);
            nextLabel.ForeColor = Color.Yellow;
            nextLabel.Location = new Point(12, 288);
            nextLabel.Margin = new Padding(4, 0, 4, 0);
            nextLabel.Name = "nextLabel";
            nextLabel.Size = new Size(148, 22);
            nextLabel.TabIndex = 4;
            nextLabel.Text = "下一个方块是";
            // 
            // nextPieceBox
            // 
            nextPieceBox.Location = new Point(12, 327);
            nextPieceBox.Margin = new Padding(4);
            nextPieceBox.Name = "nextPieceBox";
            nextPieceBox.Size = new Size(140, 157);
            nextPieceBox.TabIndex = 5;
            nextPieceBox.TabStop = false;
            nextPieceBox.Paint += NextPieceBox_Paint;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Courier New", 18F, FontStyle.Bold);
            titleLabel.ForeColor = Color.Cyan;
            titleLabel.Location = new Point(12, 26);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(157, 27);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "俄罗斯方块";
            titleLabel.Click += titleLabel_Click;
            // 
            // infoPanel
            // 
            infoPanel.BackColor = Color.Black;
            infoPanel.BorderStyle = BorderStyle.Fixed3D;
            infoPanel.Controls.Add(titleLabel);
            infoPanel.Controls.Add(scoreLabel);
            infoPanel.Controls.Add(linesLabel);
            infoPanel.Controls.Add(levelLabel);
            infoPanel.Controls.Add(nextLabel);
            infoPanel.Controls.Add(nextPieceBox);
            infoPanel.Controls.Add(controlLabel);
            infoPanel.Location = new Point(397, 26);
            infoPanel.Margin = new Padding(4);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(198, 783);
            infoPanel.TabIndex = 8;
            infoPanel.UseWaitCursor = true;
            // 
            // controlLabel
            // 
            controlLabel.AutoSize = true;
            controlLabel.Font = new Font("Courier New", 9F);
            controlLabel.ForeColor = Color.Gray;
            controlLabel.Location = new Point(12, 523);
            controlLabel.Margin = new Padding(4, 0, 4, 0);
            controlLabel.Name = "controlLabel";
            controlLabel.Size = new Size(98, 75);
            controlLabel.TabIndex = 7;
            controlLabel.Text = "← → 控制\r\n↑ 变换\r\n↓ 向下一格 \r\n空格 快速落脚\r\nESC 关闭";
            controlLabel.UseWaitCursor = true;
            // 
            // Game_RUB
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(618, 837);
            Controls.Add(infoPanel);
            Controls.Add(gameBoard);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Game_RUB";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "俄罗斯方块";
            UseWaitCursor = true;
            Load += Game_RUB_Load;
            KeyDown += Game_RUB_KeyDown;
            ((System.ComponentModel.ISupportInitialize)gameBoard).EndInit();
            ((System.ComponentModel.ISupportInitialize)nextPieceBox).EndInit();
            infoPanel.ResumeLayout(false);
            infoPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}
