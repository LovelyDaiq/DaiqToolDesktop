using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DaiqDesktop
{
    public partial class GameList : Form
    {
        public GameList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (Form2 form2 = new Form2())
            {
                form2.ShowDialog(this);
            }

            this.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            using (Game_RUB gameForm = new Game_RUB())
            {
                gameForm.ShowDialog(this);
            }

            this.Show();
        }

    }
}
