using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6_BuildingStaticImages
{
    public partial class lab6_BuildingStaticImages : Form
    {
        public lab6_BuildingStaticImages()
        {
            InitializeComponent();

            this.Show();
            Graphics g = this.CreateGraphics();

            int height = this.Size.Height;
            int width = this.Size.Width;

            //Background
            g.Clear(Color.FromArgb(255, 0, 167, 232));
            //Field
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 32, 141, 28)), new Rectangle(-500, height / 2, width, width / 2));
            g.DrawEllipse(Pens.Black, new Rectangle(-500, height / 2, width, width / 2));
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 46, 168, 54)), new Rectangle(height / 4, height / 2, width, width / 2));
            g.DrawEllipse(Pens.Black, new Rectangle(height / 4, height / 2, width, width / 2));
            //Shadow
            g.FillEllipse(new SolidBrush(Color.FromArgb(128, 126, 126, 126)), new Rectangle(width / 2 + 10, height / 2 + 30, 180, 30));
            //Flame
            var flame1 = new PointF[] { new PointF(width / 2 + 110, height / 3),
                                        new PointF(width / 2 + 130, height / 3 + 60),
                                        new PointF(width / 2 + 90, height / 3 + 100),
                                        new PointF(width / 2 + 60, height / 3 + 40),};
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(255, 228, 2, 48)), flame1);
            var flame2 = new PointF[] { new PointF(width / 2 + 100, height / 3),
                                        new PointF(width / 2 + 120, height / 3 + 60),
                                        new PointF(width / 2 + 100, height / 3 + 90),
                                        new PointF(width / 2 + 70, height / 3 + 40),};
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(255, 228, 58, 93)), flame2);
            var flame3 = new PointF[] { new PointF(width / 2 + 90, height / 3),
                                        new PointF(width / 2 + 110, height / 3 + 60),
                                        new PointF(width / 2 + 100, height / 3 + 90),
                                        new PointF(width / 2 + 80, height / 3 + 40),};
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(255, 230, 115, 140)), flame3);
            //Landing gear
            var landingGearLeft = new PointF[] { new PointF(width / 2, height / 2),
                                                 new PointF(width / 2 + 55, height / 3 + 30),
                                                 new PointF(width / 2 + 65, height / 3 + 30),
                                                 new PointF(width / 2 + 10, height / 2) };
            var landingGearRight = new PointF[] { new PointF(width / 2 + 200, height / 2),
                                                  new PointF(width / 2 + 145, height / 3 + 30),
                                                  new PointF(width / 2 + 135, height / 3 + 30),
                                                  new PointF(width / 2 + 190, height / 2) };
            g.FillPolygon(Brushes.Gray, landingGearLeft);
            g.DrawPolygon(Pens.Black, landingGearLeft);
            g.FillEllipse(Brushes.Black, new Rectangle(width / 2, height / 2 - 10, 15, 15));
            g.FillPolygon(Brushes.Gray, landingGearRight);
            g.DrawPolygon(Pens.Black, landingGearRight);
            g.FillEllipse(Brushes.Black, new Rectangle(width / 2 + 185, height / 2 - 10, 15, 15));
            //Ship
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 126, 126, 126)), new Rectangle(width / 2, height / 3, 200, 50));
            g.DrawEllipse(Pens.Black, new Rectangle(width / 2, height / 3, 200, 50));
            //Alien
            var alien = new PointF[] { new PointF(width / 2 + 85, height / 3 + 25),
                                       new PointF(width / 2 + 95, height / 3 - 10),
                                       new PointF(width / 2 + 105, height / 3 - 10),
                                       new PointF(width / 2 + 115, height / 3 + 25) };
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(255, 94, 232, 0)), alien);
            g.FillEllipse(Brushes.BlueViolet, new Rectangle(width / 2 + 95, height / 3 - 10, 10, 10));
            g.FillEllipse(Brushes.BlueViolet, new Rectangle(width / 2 + 95, height / 3, 10, 10));
            //Cabin
            var cabin = new PointF[] { new PointF(width / 2 + 70, height / 3 + 25),
                                       new PointF(width / 2 + 80, height / 3 - 20),
                                       new PointF(width / 2 + 120, height / 3 - 20),
                                       new PointF(width / 2 + 130, height / 3 + 25) };
            g.FillClosedCurve(new SolidBrush(Color.FromArgb(110, 54, 127, 255)), cabin);
            g.DrawClosedCurve(Pens.Black, cabin);
            g.Dispose();
        }
    }
}
