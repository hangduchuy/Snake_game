using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WMPLib;

namespace Game_Rắn_Săn_Mồi
{
    

    public partial class Form2 : Form
    {
        WindowsMediaPlayer sound = new WindowsMediaPlayer();   
        public Form2()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lb1.ForeColor == Color.Black && lb2.BackColor == Color.Blue)
            {
                lb1.ForeColor = Color.Red;
                lb2.BackColor = Color.Green;
                lb3.BackColor = Color.Green;
                lb4.BackColor = Color.Green;
            }
            else
            {
                lb1.ForeColor = Color.Black;
                lb2.BackColor = Color.Blue;
                lb3.BackColor = Color.Blue;
                lb4.BackColor = Color.Blue;
            }
            timer1.Interval = 300;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            sound.URL = "y2meta.com - Tăng Duy Tân _ Bên Trên Tầng Lầu , em ơi đừng khóc Remix Hot Trên Tiktok _ Audio Lyrics Video (128 kbps).mp3";
            sound.controls.play(); //Play sound
        }

        private void lb2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
            sound.controls.stop(); // close sound
        }

        private void lb1_Click(object sender, EventArgs e)
        {

        }

        private void lb3_Click(object sender, EventArgs e)
        {
            Game1 g1 = new Game1();
            this.Hide();
            g1.Show();
            sound.controls.stop();
        }

        
    }
}
