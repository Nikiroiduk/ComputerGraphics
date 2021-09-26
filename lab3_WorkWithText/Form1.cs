using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace lab3_WorkWithText
{
    public partial class Form1 : Form
    {
        Graphics g;
        string filename = @"Strings.txt";
        List<String> sm = new List<String>{
            "First line", "Second line", "Third line",
            "Fourth line", "Fifth line", "Sixth line",
            "Seventh line", "Eighth line", "Ninth line",
            "Tenth line", "Eleven line", "Twelve line",
            "Thirteenth line", "Fourteenth line",
            "Fifteenth line"};

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void SaveInFile_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter(new FileStream(filename,
            FileMode.Create, FileAccess.Write));

            foreach (string s in sm) f.WriteLine(s);
            f.Close();
            MessageBox.Show("15 строк записано в файл!");
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.FromArgb(240, 240, 240));
            File.Delete(filename);
            MessageBox.Show("Файл Strings.txt удалён!");
        }

        private void Show_Click(object sender, EventArgs e)
        {
            int k = 0;
            try
            {
                StreamReader f = new StreamReader(new FileStream(filename,
                FileMode.Open, FileAccess.Read));
                for (int i = 0; i < 15; i++) { sm[i] = f.ReadLine(); }
                f.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            pictureBox1.BackColor = Color.FromArgb(240, 240, 240);
            pictureBox1.Refresh();
            for (int i = 0; i < 15; i++)
            {
                if ((i >= 0) && (i < 6))
                {
                    Font fn = new Font("Arial", 36, FontStyle.Underline);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;
                    g.DrawString(sm[i], fn, Brushes.Black,
                    new RectangleF(0 + i * 46, 0, pictureBox1.Size.Width - 20,
                    pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }
                if ((i >= 6) && (i < 9))
                {
                    k = i - 6;
                    Font fn = new Font("Broadway", 24, FontStyle.Regular);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Far;
                    sf.LineAlignment = StringAlignment.Near;
                    g.DrawString(sm[i], fn, Brushes.Black,
                    new RectangleF(0, 0 + k * 36, pictureBox1.Size.Width - 20,
                    pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }
                if (i == 9)
                {
                    Font fn = new Font("Times New Roman", 36, FontStyle.Strikeout);
                    StringFormat sf =
                    (StringFormat)StringFormat.GenericTypographic.Clone();
                    sf.Alignment = StringAlignment.Near;
                    sf.LineAlignment = StringAlignment.Far;
                    g.DrawString(sm[i], fn, Brushes.Black,
                    new RectangleF(0, 0, pictureBox1.Size.Width - 20,
                    pictureBox1.Size.Height - 20), sf);
                    fn.Dispose();
                }

            }
        }
    }
}
