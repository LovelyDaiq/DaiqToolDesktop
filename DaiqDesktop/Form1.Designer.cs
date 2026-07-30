namespace DaiqDesktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            label2 = new Label();
            GitHub = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(2, 426);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "BiliBili";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 406);
            label1.Name = "label1";
            label1.Size = new Size(128, 17);
            label1.TabIndex = 2;
            label1.Text = "作者:可爱的呆Q(Daiq)";
            label1.Click += label1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(83, 426);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "抖音";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(2, 27);
            button3.Name = "button3";
            button3.Size = new Size(129, 39);
            button3.TabIndex = 4;
            button3.Text = "小游戏列表";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 7);
            label2.Name = "label2";
            label2.Size = new Size(61, 17);
            label2.TabIndex = 6;
            label2.Text = "休闲/娱乐";
            // 
            // GitHub
            // 
            GitHub.Location = new Point(164, 426);
            GitHub.Name = "GitHub";
            GitHub.Size = new Size(75, 23);
            GitHub.TabIndex = 9;
            GitHub.Text = "GitHub";
            GitHub.UseVisualStyleBackColor = true;
            GitHub.Click += button5_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GitHub);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            Text = "DaiqToolDesktop";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button2;
        private Button button3;
        private Label label2;
        private Button GitHub;
    }
}
