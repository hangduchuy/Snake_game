using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Game_Rắn_Săn_Mồi
{
    public partial class Form1 : Form
    {
        // Thiết lập độ dài ban đầu của răn
        int doDai = 3;
        // Mảng các tạo độ của răn
        int[] x;
        int[] y;
        //Khởi tạo ma trận giao diện
        int[,] matrix = new int[20, 20];
        //sử lý phím di chuyển 
        public static int GO_UP = 1;
        public static int GO_DOWN = -1;
        public static int GO_LEFT = 2;
        public static int GO_RIGHT = -2;
        bool status_vector = false;
        //Biến xét vị trí chạy mặc định khi vào game;
        int vector = GO_UP;
        int diem = 0;
        // Khởi động game
        bool playGame = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            x = new int[400];
            y = new int[400];
            // khởi tạo 3 vị trí ban đầu của rắn
            x[0] = 5;
            y[0] = 5;

            x[1] = 5;
            y[1] = 6;

            x[2] = 5;
            y[2] = 7;

            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                    matrix[i, j] = 0;
            //Khởi tạo vị trí mồi đầu tiên
            matrix[10, 10] = 2;
            //
            label6.BackColor = Color.Red;
            label7.BackColor = Color.Yellow;
            label8.BackColor = Color.Yellow;
            label9.BackColor = Color.Yellow;
            timer1.Interval = 400;
        }
        // sự kiện về khung chơi game, rắn và mồi
        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black);
            SolidBrush sb = new SolidBrush(Color.White);
            Graphics g = this.CreateGraphics();
            // Vẽ khung hình
            g.DrawRectangle(p, 0, 0, 401, 401);
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    //Vẽ ma trận giao diện
                    g.FillRectangle(sb, i * 20 + 1, j * 20 + 1, 18, 18);
                    // vẽ mồi
                    if (matrix[i, j] == 2)
                        g.FillRectangle(new SolidBrush(Color.Black), i * 20 + 1, j * 20 + 1, 18, 18);
                }
            //vẽ rắn
            for (int z = 1; z < doDai; z++)
                g.FillRectangle(new SolidBrush(Color.Blue), x[z] * 20 + 1, y[z] * 20 + 1, 18, 18);
            g.FillRectangle(new SolidBrush(Color.Green), x[0] * 20 + 1, y[0] * 20 + 1, 18, 18);
            g.Dispose();
            sb.Dispose();
        }
        // sự kiện các phím di chuyển khi chơi game
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (vector != -GO_UP && status_vector)
                {
                    vector = GO_UP;
                    status_vector = false;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (vector != -GO_DOWN && status_vector)
                {
                    vector = GO_DOWN;
                    status_vector = false;
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (vector != -GO_LEFT && status_vector)
                {
                    vector = GO_LEFT;
                    status_vector = false;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (vector != -GO_RIGHT && status_vector)
                {
                    vector = GO_RIGHT;
                    status_vector = false;
                }
            }

            if (e.KeyCode == Keys.Space)
            {
                //playGame = true;
                if (playGame)
                {
                    timer1.Enabled = true;
                    playGame = false;
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                Application.Restart();
            }
            if (e.KeyCode == Keys.F2)
            {
                if (label3.Text == "F2: Pause")
                {
                    timer1.Enabled = false;
                    label3.Text = "F2: Continue";
                }
                else
                {
                    timer1.Enabled = true;
                    label3.Text = "F2: Pause";
                }
            }
        }
        //
        int X()
        {
            Random Rd = new Random();
            return Rd.Next(0, 19);
        }
        //
        int Y()
        {
            Random Rd = new Random();
            return Rd.Next(0, 19);
        }
        //
        bool testXY(int m, int n)
        {
            if (m == 0 && n == 0) return false;
            for (int i = 0; i < doDai; i++)
                if (m == x[i] && n == y[i]) return false;
            return true;
        }
        


        

        private void timer1_Tick(object sender, EventArgs e)
        {
            //khởi tạo một timer tuần hoàn chu trình chạy của chương trình
            //dùng set thời timer để lập lever cho game
            status_vector = true;
            // dịch chuyển đuôi
            for (int i = doDai - 1; i > 0; i--)
            {
                x[i] = x[i - 1];
                y[i] = y[i - 1];
            }
            //dịch đầu
            if (vector == GO_DOWN) y[0]++;
            if (vector == GO_UP) y[0]--;
            if (vector == GO_LEFT) x[0]--;
            if (vector == GO_RIGHT) x[0]++;
           
            //Thiết lập khi đâm vào biên
            if (x[0] < 0) x[0] = 19;
            if (x[0] > 19) x[0] = 0;
            if (y[0] < 0) y[0] = 19;
            if (y[0] > 19) y[0] = 0;

            SolidBrush sb = new SolidBrush(Color.White);
            Graphics g = this.CreateGraphics();
            // set lại tường khi rắn di chuyển
            for (int i = 0; i < 20; i++)
                for (int j = 0; j < 20; j++)
                {
                    g.FillRectangle(sb, i * 20 + 1, j * 20 + 1, 18, 18);
                    if (matrix[i, j] == 2)
                        g.FillRectangle(new SolidBrush(Color.Black), i * 20 + 1, j * 20 + 1, 18, 18);
                }
            // Vẽ lại rắn khi di chuyển
            for (int z = 1; z < doDai; z++)
                g.FillRectangle(new SolidBrush(Color.Blue), x[z] * 20 + 1, y[z] * 20 + 1, 18, 18);
            g.FillRectangle(new SolidBrush(Color.Green), x[0] * 20 + 1, y[0] * 20 + 1, 18, 18);
            // Kiểm tra răn ăn mồi
            if (matrix[x[0], y[0]] == 2)
            {
                doDai++;
                diem += 10;
                IbDiem.Text = diem.ToString();
             //   g.FillRectangle(new SolidBrush(Color.White), 1, 1, 18, 18);
                matrix[x[0], y[0]] = 0;
                //Vẽ lại rắn
                for (int z = 1; z < doDai; z++)
                    g.FillRectangle(new SolidBrush(Color.Blue), x[z] * 20 + 1, y[z] * 20 + 1, 18, 18);
                g.FillRectangle(new SolidBrush(Color.Green), x[0] * 20 + 1, y[0] * 20 + 1, 18, 18);
                int m, n;
                do
                {
                    m = X();
                    n = Y();
                } while (!testXY(m, n)); // kiểm tra random trên thân rắn hay không

                matrix[m, n] = 2;
                g.FillRectangle(new SolidBrush(Color.Black), m * 20 + 1, n * 20 + 1, 18, 18);
            }
            //xử lí đâm vào thân
            for (int i = 1; i < doDai; i++)
                if (x[0] == x[i] && y[0] == y[i])
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Ban đã tự đâm vào đuôi của mình! \nĐiểm: " + diem.ToString(), "Thông báo");
                    Application.Restart();
                }
            g.Dispose();
            sb.Dispose();
        }
        //Bắt các sự kiện khi người chơi muốn tăng level
        private void label9_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.Yellow;
            label7.BackColor = Color.Yellow;
            label8.BackColor = Color.Yellow;
            label9.BackColor = Color.Red;
            timer1.Interval = 100;
        }

        private void label7_Click_1(object sender, EventArgs e)
        {
            label6.BackColor = Color.Yellow;
            label7.BackColor = Color.Red;
            label8.BackColor = Color.Yellow;
            label9.BackColor = Color.Yellow;
            timer1.Interval = 300;
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            label6.BackColor = Color.Yellow;
            label7.BackColor = Color.Yellow;
            label8.BackColor = Color.Red;
            label9.BackColor = Color.Yellow;
            timer1.Interval = 200;
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            label6.BackColor = Color.Red;
            label7.BackColor = Color.Yellow;
            label8.BackColor = Color.Yellow;
            label9.BackColor = Color.Yellow;
            timer1.Interval = 400;
        }

     
    }
}
