using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab5_BrushesAndFill_Сharting
{
    public partial class lab5_BrushesAndFill_Сharting : Form
    {
        public lab5_BrushesAndFill_Сharting()
        {
            InitializeComponent();

            this.Show();
            Graphics g = this.CreateGraphics();

            //Вывод подсказки на экран
            Font fn = new Font("Arial", 15, FontStyle.Regular);
            StringFormat sf =
            (StringFormat)StringFormat.GenericTypographic.Clone();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString("Кликните мышкой по окну приложения", fn, Brushes.Black, new RectangleF(0, 0, this.Size.Width - 20, this.Size.Height - 20), sf);
            fn.Dispose();

            //Добавление обработчика события на нажатие мышкой по pictureBox
            this.pictureBox.Click += new EventHandler(this.Form1_Click);
        }

        //Глобальный объект pictureBox
        PictureBox pictureBox = new PictureBox
        {
            Dock = DockStyle.Fill,
        };

        private void Form1_Click(object sender, EventArgs e)
        {
            //Добавление pictureBox на форму
            Controls.Add(pictureBox);

            this.Refresh();
            Graphics g = pictureBox.CreateGraphics();
            //Многоугольник для заголовка
            Point[] point = new Point[11] {
                new Point(120, 20), new Point(180, 30),
                new Point(240, 20), new Point(300, 30),
                new Point(360, 20), new Point(420, 30),
                new Point(420, 80), new Point(360, 90),
                new Point(300, 80), new Point(240, 90),
                new Point(120, 90)
                };
            g.DrawPolygon(new Pen(Color.FromArgb(255,128,0), 2), point);
            Font fn = new Font("Arial", 10, FontStyle.Bold);
            StringFormat sf = new StringFormat();

            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            string s = "Оценки по программированию девяти студентов группы.";
            g.DrawString(s, fn, Brushes.Black, new Rectangle(125, 20, 300, 70), sf);
            //Начало и конец осей X & Y
            int startX = 30;
            int endX = pictureBox.Width - 10;
            int startY = 120;
            int endY = pictureBox.Height - 20;
            //OX
            g.DrawLine(new Pen(Color.Black, 1), startX, endY, endX, endY);
            //OY
            g.DrawLine(new Pen(Color.Black, 1), startX, startY, startX, endY);
            //Имена студентов
            string[] students = new string[9] { "stud 1", "stud 2", "stud 3", "stud 4", "stud 5", "stud 6", "stud 7", "stud 8", "stud 9" };
            //Оценки студентов
            int[] ratings = new int[9] { 2, 3, 5, 5, 4, 1, 5, 4, 2 };
            //Поиск максимального элемента
            int max = ratings[0];
            for (int i = 0; i < ratings.Length; i++)
                if (ratings[i] > max) 
                    max = ratings[i];
            double mash = 5.0;
            double dy = (endY - startY) / (max / mash);
            int widthRect = ((endX - startX) / ratings.Length) / 2;
            //Сплошная заливка
            SolidBrush sb = new SolidBrush(Color.FromArgb(255, 155, 0));
            //Заливка стилем BackwardDiagonal
            HatchBrush hb = new HatchBrush(HatchStyle.BackwardDiagonal, Color.FromArgb(0,0,0), Color.FromArgb(255, 100, 0));
            //Создание текстурной кисти
            Image img = Image.FromFile(System.IO.Path.GetFullPath(@"../../brick.png"));
            TextureBrush tb = new TextureBrush(img);
            Pen p = new Pen(Color.FromArgb(25, 0, 0, 0), 2)
            {
                DashStyle = DashStyle.Solid
            };
            fn = new Font("Arial", 8, FontStyle.Bold);
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            //Цикл по оценкам
            for (int i = 0; i < ratings.Length; i++)
            {
                g.DrawLine(p, startX - 5, endY - (int)(dy * (ratings[i] / mash)), endX, endY - (int)(dy * (ratings[i] / mash)));
                g.DrawString(ratings[i].ToString(), fn, Brushes.Black, new Rectangle(1, endY - (int)(dy * (ratings[i] / mash)) - (int)fn.Size, 30, 20), sf);
            }
            //Вывод элементов диаграммы
            int x = startX + widthRect;
            for (int i = 0; i < ratings.Length; i++)
            {
                Rectangle rect = new Rectangle(x, endY - (int)(dy * (ratings[i] / mash)), widthRect, (int)(dy * (ratings[i] / mash)));
                if (i < 3) g.FillRectangle(sb, rect);
                if ((i >= 3) && (i < 6)) g.FillRectangle(hb, rect);
                if ((i >= 6) && (i < 9)) g.FillRectangle(tb, rect);
                x += 2 * widthRect;
            }
            //Линии и имена студентов
            sf.Alignment = StringAlignment.Center;
            x = startX + widthRect + widthRect / 2;
            for (int i = 0; i < students.Length; i++)
            {
                g.DrawLine(new Pen(Color.Black, 1), x, endY - 5, x, endY + 5);
                g.DrawString(students[i], fn, Brushes.Black, new Rectangle(x - 25, endY, 50, 22), sf);
                x += 2 * widthRect;
            }
        }
    }
}
