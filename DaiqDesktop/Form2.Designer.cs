namespace DaiqDesktop
{
    partial class Form2
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
            panelTop = new Panel();
            lblTarget = new Label();
            lblBest = new Label();
            lblScore = new Label();
            lblTitle = new Label();
            canvas = new PictureBox();
            panelGameOver = new Panel();
            btnBack = new Button();
            btnRestart = new Button();
            lblFinalScore = new Label();
            lblGameOverTitle = new Label();
            lblHelp = new Label();
            btnStart = new Button();
            panelRight = new Panel();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            panelGameOver.SuspendLayout();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(22, 33, 62);
            panelTop.Controls.Add(lblTarget);
            panelTop.Controls.Add(lblBest);
            panelTop.Controls.Add(lblScore);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1031, 85);
            panelTop.TabIndex = 0;
            // 
            // lblTarget
            // 
            lblTarget.AutoSize = true;
            lblTarget.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblTarget.ForeColor = Color.FromArgb(150, 150, 150);
            lblTarget.Location = new Point(887, 28);
            lblTarget.Margin = new Padding(4, 0, 4, 0);
            lblTarget.Name = "lblTarget";
            lblTarget.Size = new Size(69, 21);
            lblTarget.TabIndex = 4;
            lblTarget.Text = "目标: 50";
            // 
            // lblBest
            // 
            lblBest.AutoSize = true;
            lblBest.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblBest.ForeColor = Color.FromArgb(255, 215, 0);
            lblBest.Location = new Point(758, 28);
            lblBest.Margin = new Padding(4, 0, 4, 0);
            lblBest.Name = "lblBest";
            lblBest.Size = new Size(60, 21);
            lblBest.TabIndex = 3;
            lblBest.Text = "最佳: 0";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Font = new Font("微软雅黑", 14F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblScore.ForeColor = Color.FromArgb(0, 219, 222);
            lblScore.Location = new Point(583, 26);
            lblScore.Margin = new Padding(4, 0, 4, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(73, 26);
            lblScore.TabIndex = 2;
            lblScore.Text = "分数: 0";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("微软雅黑", 18F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblTitle.ForeColor = Color.FromArgb(0, 219, 222);
            lblTitle.Location = new Point(23, 21);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(134, 31);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "神秘贪吃蛇";
            // 
            // canvas
            // 
            canvas.BackColor = Color.FromArgb(15, 52, 96);
            canvas.BorderStyle = BorderStyle.Fixed3D;
            canvas.Location = new Point(23, 113);
            canvas.Margin = new Padding(4);
            canvas.Name = "canvas";
            canvas.Size = new Size(699, 848);
            canvas.TabIndex = 1;
            canvas.TabStop = false;
            canvas.Paint += Canvas_Paint;
            // 
            // panelGameOver
            // 
            panelGameOver.BackColor = Color.FromArgb(180, 0, 0, 0);
            panelGameOver.Controls.Add(btnBack);
            panelGameOver.Controls.Add(btnRestart);
            panelGameOver.Controls.Add(lblFinalScore);
            panelGameOver.Controls.Add(lblGameOverTitle);
            panelGameOver.Location = new Point(23, 113);
            panelGameOver.Margin = new Padding(4);
            panelGameOver.Name = "panelGameOver";
            panelGameOver.Size = new Size(700, 850);
            panelGameOver.TabIndex = 3;
            panelGameOver.Visible = false;
            panelGameOver.Paint += panelGameOver_Paint;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(102, 126, 234);
            btnBack.Cursor = Cursors.Hand;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("微软雅黑", 12F, FontStyle.Regular, GraphicsUnit.Point, 134);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(362, 453);
            btnBack.Margin = new Padding(4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(163, 64);
            btnBack.TabIndex = 3;
            btnBack.Text = "返回";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // btnRestart
            // 
            btnRestart.BackColor = Color.FromArgb(0, 184, 148);
            btnRestart.Cursor = Cursors.Hand;
            btnRestart.FlatAppearance.BorderSize = 0;
            btnRestart.FlatStyle = FlatStyle.Flat;
            btnRestart.Font = new Font("微软雅黑", 12F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnRestart.ForeColor = Color.White;
            btnRestart.Location = new Point(175, 453);
            btnRestart.Margin = new Padding(4);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(163, 64);
            btnRestart.TabIndex = 2;
            btnRestart.Text = "重新开始";
            btnRestart.UseVisualStyleBackColor = false;
            // 
            // lblFinalScore
            // 
            lblFinalScore.AutoSize = true;
            lblFinalScore.Font = new Font("微软雅黑", 20F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblFinalScore.ForeColor = Color.White;
            lblFinalScore.Location = new Point(233, 326);
            lblFinalScore.Margin = new Padding(4, 0, 4, 0);
            lblFinalScore.Name = "lblFinalScore";
            lblFinalScore.Size = new Size(154, 35);
            lblFinalScore.TabIndex = 1;
            lblFinalScore.Text = "最终分数: 0";
            // 
            // lblGameOverTitle
            // 
            lblGameOverTitle.AutoSize = true;
            lblGameOverTitle.Font = new Font("微软雅黑", 36F, FontStyle.Bold, GraphicsUnit.Point, 134);
            lblGameOverTitle.ForeColor = Color.FromArgb(0, 219, 222);
            lblGameOverTitle.Location = new Point(187, 212);
            lblGameOverTitle.Margin = new Padding(4, 0, 4, 0);
            lblGameOverTitle.Name = "lblGameOverTitle";
            lblGameOverTitle.Size = new Size(219, 64);
            lblGameOverTitle.TabIndex = 0;
            lblGameOverTitle.Text = "游戏结束";
            // 
            // lblHelp
            // 
            lblHelp.Font = new Font("微软雅黑", 11F, FontStyle.Regular, GraphicsUnit.Point, 134);
            lblHelp.ForeColor = Color.White;
            lblHelp.Location = new Point(11, 78);
            lblHelp.Margin = new Padding(4, 0, 4, 0);
            lblHelp.Name = "lblHelp";
            lblHelp.Size = new Size(222, 105);
            lblHelp.TabIndex = 0;
            lblHelp.Text = "神秘贪吃蛇 规则不用我说吧";
            lblHelp.Click += lblHelp_Click;
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(0, 184, 148);
            btnStart.Cursor = Cursors.Hand;
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("微软雅黑", 14F, FontStyle.Bold, GraphicsUnit.Point, 134);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(16, 157);
            btnStart.Margin = new Padding(4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(222, 64);
            btnStart.TabIndex = 1;
            btnStart.Text = "开始游戏";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += BtnStart_Click;
            // 
            // panelRight
            // 
            panelRight.BackColor = Color.FromArgb(22, 33, 62);
            panelRight.Controls.Add(btnStart);
            panelRight.Controls.Add(lblHelp);
            panelRight.Location = new Point(746, 314);
            panelRight.Margin = new Padding(4);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(257, 256);
            panelRight.TabIndex = 2;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(26, 26, 46);
            ClientSize = new Size(1031, 1007);
            Controls.Add(panelGameOver);
            Controls.Add(panelRight);
            Controls.Add(canvas);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form2";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "贪吃蛇";
            FormClosing += Form2_FormClosing;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            panelGameOver.ResumeLayout(false);
            panelGameOver.PerformLayout();
            panelRight.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblBest;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Panel panelGameOver;
        private System.Windows.Forms.Label lblGameOverTitle;
        private System.Windows.Forms.Label lblFinalScore;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnBack;
        private Label lblHelp;
        private Button btnStart;
        private Panel panelRight;
    }
}
