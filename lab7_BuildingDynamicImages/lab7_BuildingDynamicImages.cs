using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab7_BuildingDynamicImages
{
    public partial class lab7_BuildingDynamicImages : Form
    {
        Bitmap pictureBoxBitMap;
        Bitmap spriteBitMap;
        Bitmap cloneBitMap;
        Graphics g_pictureBox;
        Graphics g_sprite;
        int x, y;
        int width = 300, height = 150;
        Timer timer;
        public lab7_BuildingDynamicImages() {
            InitializeComponent(); 
        }
        void DrawSprite()
        {
        int width = 100;
        int height = 100;
        //Flame
        var flame1 = new PointF[] { new PointF(width / 2 + 110, height / 3),
                                    new PointF(width / 2 + 130, height / 3 + 60),
                                    new PointF(width / 2 + 90, height / 3 + 100),
                                    new PointF(width / 2 + 60, height / 3 + 40),};
        g_sprite.FillClosedCurve(new SolidBrush(Color.FromArgb(255, 228, 2, 48)), flame1);
        var flame2 = new PointF[] { new PointF(width / 2 + 100, height / 3),
                                    new PointF(width / 2 + 120, height / 3 + 60),
                                    new PointF(width / 2 + 100, height / 3 + 90),
                                    new PointF(width / 2 + 70, height / 3 + 40),};
        g_sprite.FillClosedCurve(new SolidBrush(Color.FromArgb(255, 228, 58, 93)), flame2);
        var flame3 = new PointF[] { new PointF(width / 2 + 90, height / 3),
                                    new PointF(width / 2 + 110, height / 3 + 60),
                                    new PointF(width / 2 + 100, height / 3 + 90),
                                    new PointF(width / 2 + 80, height / 3 + 40),};
        g_sprite.FillClosedCurve(new SolidBrush(Color.FromArgb(255, 230, 115, 140)), flame3);
        //Landing gear
        var landingGearLeft = new PointF[] { new PointF(width / 2, height / 2),
                                             new PointF(width / 2 + 55, height / 3 + 30),
                                             new PointF(width / 2 + 65, height / 3 + 30),
                                             new PointF(width / 2 + 10, height / 2) };
        var landingGearRight = new PointF[] { new PointF(width / 2 + 200, height / 2),
                                              new PointF(width / 2 + 145, height / 3 + 30),
                                              new PointF(width / 2 + 135, height / 3 + 30),
                                              new PointF(width / 2 + 190, height / 2) };
        g_sprite.FillPolygon(Brushes.Gray, landingGearLeft);
        g_sprite.DrawPolygon(Pens.Black, landingGearLeft);
        g_sprite.FillEllipse(Brushes.Black, new Rectangle(width / 2, height / 2 - 10, 15, 15));
        g_sprite.FillPolygon(Brushes.Gray, landingGearRight);
        g_sprite.DrawPolygon(Pens.Black, landingGearRight);
        g_sprite.FillEllipse(Brushes.Black, new Rectangle(width / 2 + 185, height / 2 - 10, 15, 15));
        //Ship
        g_sprite.FillEllipse(new SolidBrush(Color.FromArgb(255, 126, 126, 126)), new Rectangle(width / 2, height / 3, 200, 50));
        g_sprite.DrawEllipse(Pens.Black, new Rectangle(width / 2, height / 3, 200, 50));
        //Alien
        var alien = new PointF[] { new PointF(width / 2 + 85, height / 3 + 25),
                                   new PointF(width / 2 + 95, height / 3 - 10),
                                   new PointF(width / 2 + 105, height / 3 - 10),
                                   new PointF(width / 2 + 115, height / 3 + 25) };
        g_sprite.FillClosedCurve(new SolidBrush(Color.FromArgb(255, 94, 232, 0)), alien);
        g_sprite.FillEllipse(Brushes.BlueViolet, new Rectangle(width / 2 + 95, height / 3 - 10, 10, 10));
        g_sprite.FillEllipse(Brushes.BlueViolet, new Rectangle(width / 2 + 95, height / 3, 10, 10));
        //Cabin
        var cabin = new PointF[] { new PointF(width / 2 + 70, height / 3 + 25),
                                   new PointF(width / 2 + 80, height / 3 - 20),
                                   new PointF(width / 2 + 120, height / 3 - 20),
                                   new PointF(width / 2 + 130, height / 3 + 25) };
        g_sprite.FillClosedCurve(new SolidBrush(Color.FromArgb(110, 54, 127, 255)), cabin);
        g_sprite.DrawClosedCurve(Pens.Black, cabin);
        
        }

        void SavePart(int xt, int yt)
        {
            Rectangle cloneRect = new Rectangle(xt, yt, width, height);
            System.Drawing.Imaging.PixelFormat format = pictureBoxBitMap.PixelFormat;
            cloneBitMap = pictureBoxBitMap.Clone(cloneRect, format);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void lab7_BuildingDynamicImages_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\makog\Source\Repos\Nikiroiduk\ComputerGraphics\lab7_BuildingDynamicImages\back.jpg");
            pictureBoxBitMap = new Bitmap(pictureBox1.Image);
            g_pictureBox = Graphics.FromImage(pictureBox1.Image);
            spriteBitMap = new Bitmap(width, height);
            g_sprite = Graphics.FromImage(spriteBitMap);
            DrawSprite();
            cloneBitMap = new Bitmap(width, height);
            x = this.Size.Width / 2 - 175; y = this.Size.Height - 100;
            SavePart(x, y);
            g_pictureBox.DrawImage(spriteBitMap, x, y);
            pictureBox1.Invalidate();
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer1_Tick);
        }

        private void timer1_Tick(object sender, EventArgs e)
            {
                g_pictureBox.DrawImage(cloneBitMap, x, y);
            if ( y - 6 <= 0) timer.Dispose();    
            y -= 4;
                SavePart(x, y);
                g_pictureBox.DrawImage(spriteBitMap, x, y);
                pictureBox1.Invalidate();
            }
        }
    }
