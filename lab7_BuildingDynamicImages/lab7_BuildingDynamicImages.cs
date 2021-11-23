using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab7_BuildingDynamicImages
{
    public partial class lab7_BuildingDynamicImages : Form
    {
            // Битовая картинка pictureBox
            Bitmap pictureBoxBitMap;
            // Битовая картинка динамического изображения
            Bitmap spriteBitMap;
            // Битовая картинка для временного хранения области экрана
            Bitmap cloneBitMap;
            // Графический контекст picturebox
            Graphics g_pictureBox;
            // Графический контекст спрайта
            Graphics g_sprite;
            int x, y; // Координаты автобуса
            int width = 451, height = 209; // Ширина и высота автобуса
            Timer timer;
            public lab7_BuildingDynamicImages() { InitializeComponent(); }
            // Функция рисования спрайта (автобуса)
            void DrawSprite()
            {
                // Рисуем колеса
                g_sprite.DrawEllipse(new Pen(Color.Black, 2), 70, 150, 60, 60);
                g_sprite.FillEllipse(new SolidBrush(Color.Black), 70, 150, 60, 60);
                g_sprite.DrawEllipse(new Pen(Color.Black, 2), 350, 150, 60, 60);
                g_sprite.FillEllipse(new SolidBrush(Color.Black), 350, 150, 60, 60);
                // Рисуем корпус автобуса
                Point[] points = new Point[6] { new Point(1,1), new Point(430,1),
new Point(450, 90), new Point(450, 180),
new Point(1, 180), new Point(1, 1)

};
                g_sprite.FillPolygon(Brushes.Yellow, points);
                g_sprite.DrawPolygon(new Pen(Color.Black, 2), points);
                // Рисуем четыре пассажирских окна
                for (int i = 0; i < 4; i++)
                {
                    g_sprite.FillRectangle(Brushes.LightGray, 10 + i * 60 + i * 10, 10, 60, 80);
                    g_sprite.DrawRectangle(new Pen(Color.Black, 2), 10 + i * 60 + i * 10, 10, 60, 80);
                }

                // Рисуем контур двери
                g_sprite.DrawRectangle(new Pen(Color.Black, 2), 290, 10, 60, 160);
                // Рисуем окно двери и контур окна
                g_sprite.FillRectangle(Brushes.LightGray, 295, 15, 50, 90);
                g_sprite.DrawRectangle(new Pen(Color.Black, 2), 295, 15, 50, 90);
                // Рисуем окно кабины и его контур
                Point[] point = new Point[5]{ new Point(360,10), new Point(420,10),
new Point(438,90), new Point(360,90), new Point(360,10)
};
                g_sprite.FillPolygon(Brushes.LightGray, point);
                g_sprite.DrawPolygon(new Pen(Color.Black, 2), point);
            }
            // Функция сохранения части изображения шириной
            void SavePart(int xt, int yt)
            {
                Rectangle cloneRect = new Rectangle(xt, yt, width, height);
            //g_pictureBox.DrawRectangle(Pens.Red, cloneRect);
                System.Drawing.Imaging.PixelFormat format = pictureBoxBitMap.PixelFormat;
            // Клонируем изображение, заданное прямоугольной областью
                cloneBitMap = pictureBoxBitMap.Clone(cloneRect, format);
            }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void lab7_BuildingDynamicImages_Load(object sender, EventArgs e)
        {
            // Создаём Bitmap для pictureBox1 и графический контекст
            pictureBox1.Image = Image.FromFile(@"C:\Users\Nikit\Source\Repos\Nikiroiduk\ComputerGraphics\lab7_BuildingDynamicImages\back.jpg");
            pictureBoxBitMap = new Bitmap(pictureBox1.Image);
            g_pictureBox = Graphics.FromImage(pictureBox1.Image);
            // Создаём Bitmap для спрайта и графический контекст
            spriteBitMap = new Bitmap(width, height);
            g_sprite = Graphics.FromImage(spriteBitMap);
            // Рисуем линию движения автобуса
            g_pictureBox.DrawLine(new Pen(Color.Black, 2), 0, 410,
            pictureBox1.Width - 1, 410);
            // Рисуем автобус на графическом контексте g_sprite
            DrawSprite();
            // Создаём Bitmap для временного хранения части изображения
            cloneBitMap = new Bitmap(width, height);
            // Задаем начальные координаты вывода движущегося объекта
            x = 0; y = 200;
            // Сохраняем область экрана перед первым выводом объекта
            SavePart(x, y);
            // Выводим автобус на графический контекст g_pictureBox
            g_pictureBox.DrawImage(spriteBitMap, x, y);
            // Перерисовываем pictureBox1
            pictureBox1.Invalidate();
            // Создаём таймер с интервалом 100 миллисекунд
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(timer1_Tick);
        }

        // Обрабатываем событие от таймера
        private void timer1_Tick(object sender, EventArgs e)
            {
                // Восстанавливаем затёртую область статического изображения
                g_pictureBox.DrawImage(cloneBitMap, x, y);
                // Изменяем координаты для следующего вывода автобуса
                x += 6;
                // Проверяем на выход изображения автобуса за правую границу
                if (x > pictureBox1.Width - 1) x = pictureBox1.Location.X;
                // Сохраняем область экрана перед первым выводом автобуса
                SavePart(x, y);
                // Выводим автобус
                g_pictureBox.DrawImage(spriteBitMap, x, y);
                // Перерисовываем pictureBox1
                pictureBox1.Invalidate();
            }
        }
    }
