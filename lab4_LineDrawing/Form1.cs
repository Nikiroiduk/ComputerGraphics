using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace lab4_LineDrawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string CreateDragonLine()
        {
            //Порядок кривой дракона
            int orderCurve = 7;
            string str = "1";
            for (int i = 1; i < orderCurve; i++)
            {
                StringBuilder sb = new StringBuilder(str);
                int midle = (int)Math.Floor((double)sb.Length / 2);
                sb[midle] = '0';
                str = str + "1" + sb;
            }
            return str;
        }

        private void Draw_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            Pen p = new Pen(Color.FromArgb(255, 128, 0), 20);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            p.CompoundArray = new float[] { 0.0f, 0.1f, 0.3f, 0.5f, 0.8f, 1.0f};

            Pen dragonPen = new Pen(Color.FromArgb(70, 70, 70), 2);
            int dx = 23;

            //Создание строки кривой дракона
            string str = CreateDragonLine();
            int x1 = pictureBox1.Size.Width / 2;
            int y1 = pictureBox1.Size.Height / 2;
            int x2 = pictureBox1.Size.Width / 2;
            int y2 = pictureBox1.Size.Height / 2 - dx;
            int x3 = x2;
            int y3 = y2;
            //Первая линия
            g.DrawLine(dragonPen, x1, y1, x3, y3);
            //Отображение линий по всем цифрам кривой дракона
            for (int i = 0; i < str.Length; i++)
            {
                if (y2 - y1 < 0)
                {
                    if (str[i] == '1') x3 = x2 - dx;
                    else x3 = x2 + dx;
                    y3 = y2;
                }
                if (x2 - x1 < 0)
                { 
                    if (str[i] == '1') y3 = y2 - dx;
                    else y3 = y2 + dx; 
                    x3 = x2;
                }
                if (x2 - x1 > 0)
                { 
                    if (str[i] == '1') y3 = y2 + dx;
                    else y3 = y2 - dx;
                    x3 = x2;
                }
                if (y2 - y1 > 0)
                { 
                    if (str[i] == '1') x3 = x2 + dx;
                    else x3 = x2 - dx;
                    y3 = y2;
                }
                if (i == str.Length - 1)
                {
                    g.DrawLine(p, x2, y2, x3, y3);
                }
                else
                {
                    g.DrawLine(dragonPen, x2, y2, x3, y3);
                }
                x1 = x2; y1 = y2;
                x2 = x3; y2 = y3;
            }
        }
    }
}
