///Работа сдана

using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab1_CreatingGraphicalWindowsApplication
{
    public partial class lab1_CreatingGraphicalWindowsApplication : Form
    {
        public lab1_CreatingGraphicalWindowsApplication()
        {
            InitializeComponent();
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    g.DrawLine(Pens.Red, 10, 5, 110, 15);
        //    g.DrawEllipse(Pens.Blue, 10, 20, 110, 45);
        //    g.DrawRectangle(Pens.Green, 10, 70, 110, 45);
        //    g.FillEllipse(Brushes.Blue, 130, 20, 110, 45);
        //    g.FillRectangle(Brushes.Green, 130, 70, 110, 45);
        //    base.OnPaint(e);
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            Pen myPen = new Pen(Color.Red, 1);
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawRectangle(myPen, 0, 0, pictureBox1.Size.Width - 1,
            pictureBox1.Size.Height - 1);
            g.Dispose();
        }
    }
}
