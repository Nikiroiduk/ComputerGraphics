using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab2_CoordinateSystemsColorsPlottingFunctions
{
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
        private void Pixels_Click(object sender, EventArgs e)
        {
            int old_ex = 0, old_ey = 0;
            Pen axesPen = new Pen(Color.Black, 1);
            Pen graphicsPen = new Pen(Color.FromArgb(200, 0, 0), 2);
            pictureBox1.BackColor = Color.FromName("ControlLightLight");
            pictureBox1.Refresh();
            g.PageUnit = GraphicsUnit.Pixel;
            g.DrawRectangle(axesPen, 0, 0, pictureBox1.Size.Width - 1, pictureBox1.Size.Height - 1);
            g.DrawLine(axesPen, 0, (pictureBox1.Size.Height - 1) / 2, pictureBox1.Size.Width - 1, (pictureBox1.Size.Height - 1) / 2);
            g.DrawLine(axesPen, (pictureBox1.Size.Width - 1) / 2, 0, (pictureBox1.Size.Width - 1) / 2, pictureBox1.Size.Height - 1);
            double x = -1;
            int ex;
            for (ex = 0; ex <= 1000; ex++)
            {
                double y = -6 * Math.Pow(x, 2) + 3 * x;
                int ey = (int)((pictureBox1.Size.Height - 1) - y * 500 - 250);
                if (ex != 0) g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey);
                old_ex = ex; old_ey = ey;
                x += (double)2 / 1000;
            }
        }
        private void Millimeters_Click(object sender, EventArgs e)
        {
            int old_ex = 0, old_ey = 0;
            g.PageUnit = GraphicsUnit.Millimeter;
            Pen axesPen = new Pen(Color.Black, 0.1f);
            Pen graphicsPen = new Pen(Color.FromArgb(0, 0, 255), 0.4f);
            pictureBox1.BackColor = Color.FromKnownColor(KnownColor.ControlLightLight);
            pictureBox1.Refresh();
            int WidthInMM = Convert.ToInt16((pictureBox1.Size.Width - 1) / g.DpiX * 25.4);
            int HeightInMM = Convert.ToInt16((pictureBox1.Size.Height - 1) / g.DpiY * 25.4);
            g.DrawRectangle(axesPen, 0, 0, WidthInMM, HeightInMM);
            g.DrawLine(axesPen, 0, HeightInMM / 2, WidthInMM, HeightInMM / 2);
            g.DrawLine(axesPen, WidthInMM / 2, 0, WidthInMM / 2, HeightInMM);
            double x = -1;
            int ex;
            for (ex = 0; ex <= WidthInMM; ex++)
            {
                double y = -6 * Math.Pow(x, 2) + 3 * x;
                int ey = HeightInMM - (Convert.ToInt16(y * Convert.ToSingle(500 / g.DpiX * 25.4)) + Convert.ToInt16(250 / g.DpiX * 25.4));
                if (ex != 0) g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey);
                old_ex = ex; old_ey = ey;
                x += (double)2 / WidthInMM;
            }
        }
        private void Inches_Click(object sender, System.EventArgs e)
        {
            float old_ex = 0, old_ey = 0;
            g.PageUnit = GraphicsUnit.Inch;
            Pen axesPen = new Pen(Color.Black, 0.01f);
            Pen graphicsPen = new Pen(Color.FromArgb(255, 128, 0), 0.02f);
            pictureBox1.BackColor = Color.FromName("ControlLightLight");
            pictureBox1.Refresh();
            float WidthInInches = (pictureBox1.Size.Width - 1) / g.DpiX;
            float HeightInInches = (pictureBox1.Size.Height - 1) / g.DpiY;
            g.DrawRectangle(axesPen, 0, 0, WidthInInches, HeightInInches);
            g.DrawLine(axesPen, 0, HeightInInches / 2, WidthInInches, HeightInInches / 2);
            g.DrawLine(axesPen, WidthInInches / 2, 0, WidthInInches / 2, HeightInInches);
            float x = -1;
            float ex = 4;
            float step = WidthInInches / 30;
            while (ex <= WidthInInches + step)
            {
                float y = Convert.ToSingle(-6 * Math.Pow(x, 2) + 3 * x);
                float ey = Math.Abs(y - HeightInInches / 4);
                if (ex > 4) g.DrawLine(graphicsPen, old_ex, old_ey, ex, ey); 
                old_ex = ex; old_ey = ey;
                ex += step;
                x += 2 / WidthInInches;
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(240, 240, 240));
        }
    }
}