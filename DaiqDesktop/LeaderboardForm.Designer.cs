namespace DaiqDesktop
{
    partial class LeaderboardForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblDateH = new System.Windows.Forms.Label();
            this.lblScoreH = new System.Windows.Forms.Label();
            this.lblNameH = new System.Windows.Forms.Label();
            this.lblRankH = new System.Windows.Forms.Label();
            this.listPanel = new System.Windows.Forms.Panel();
            this.lblMyBest = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(219)))), ((int)(((byte)(222)))));
            this.lblTitle.Location = new System.Drawing.Point(170, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(163, 42);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🏆 排行榜";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(184)))), ((int)(((byte)(148)))));
            this.panelHeader.Controls.Add(this.lblDateH);
            this.panelHeader.Controls.Add(this.lblScoreH);
            this.panelHeader.Controls.Add(this.lblNameH);
            this.panelHeader.Controls.Add(this.lblRankH);
            this.panelHeader.Location = new System.Drawing.Point(30, 70);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(420, 40);
            this.panelHeader.TabIndex = 1;
            // 
            // lblDateH
            // 
            this.lblDateH.AutoSize = true;
            this.lblDateH.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDateH.ForeColor = System.Drawing.Color.White;
            this.lblDateH.Location = new System.Drawing.Point(340, 8);
            this.lblDateH.Name = "lblDateH";
            this.lblDateH.Size = new System.Drawing.Size(42, 21);
            this.lblDateH.TabIndex = 3;
            this.lblDateH.Text = "日期";
            // 
            // lblScoreH
            // 
            this.lblScoreH.AutoSize = true;
            this.lblScoreH.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblScoreH.ForeColor = System.Drawing.Color.White;
            this.lblScoreH.Location = new System.Drawing.Point(260, 8);
            this.lblScoreH.Name = "lblScoreH";
            this.lblScoreH.Size = new System.Drawing.Size(42, 21);
            this.lblScoreH.TabIndex = 2;
            this.lblScoreH.Text = "分数";
            // 
            // lblNameH
            // 
            this.lblNameH.AutoSize = true;
            this.lblNameH.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNameH.ForeColor = System.Drawing.Color.White;
            this.lblNameH.Location = new System.Drawing.Point(130, 8);
            this.lblNameH.Name = "lblNameH";
            this.lblNameH.Size = new System.Drawing.Size(42, 21);
            this.lblNameH.TabIndex = 1;
            this.lblNameH.Text = "玩家";
            // 
            // lblRankH
            // 
            this.lblRankH.AutoSize = true;
            this.lblRankH.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRankH.ForeColor = System.Drawing.Color.White;
            this.lblRankH.Location = new System.Drawing.Point(20, 8);
            this.lblRankH.Name = "lblRankH";
            this.lblRankH.Size = new System.Drawing.Size(42, 21);
            this.lblRankH.TabIndex = 0;
            this.lblRankH.Text = "排名";
            // 
            // listPanel
            // 
            this.listPanel.AutoScroll = true;
            this.listPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(33)))), ((int)(((byte)(62)))));
            this.listPanel.Location = new System.Drawing.Point(30, 110);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(420, 380);
            this.listPanel.TabIndex = 2;
            // 
            // lblMyBest
            // 
            this.lblMyBest.AutoSize = true;
            this.lblMyBest.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMyBest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(219)))), ((int)(((byte)(222)))));
            this.lblMyBest.Location = new System.Drawing.Point(160, 470);
            this.lblMyBest.Name = "lblMyBest";
            this.lblMyBest.Size = new System.Drawing.Size(90, 21);
            this.lblMyBest.TabIndex = 3;
            this.lblMyBest.Text = "我的最佳: 0";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(126)))), ((int)(((byte)(234)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(170, 510);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关 闭";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // LeaderboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblMyBest);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LeaderboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "🏆 排行榜";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblRankH;
        private System.Windows.Forms.Label lblNameH;
        private System.Windows.Forms.Label lblScoreH;
        private System.Windows.Forms.Label lblDateH;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Label lblMyBest;
        private System.Windows.Forms.Button btnClose;
    }
}
