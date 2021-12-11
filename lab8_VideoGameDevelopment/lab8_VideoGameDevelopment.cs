using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab8_VideoGameDevelopment
{
    public partial class lab8_VideoGameDevelopment : Form
    {

        PictureBox playerUFO = new PictureBox();
        PictureBox enemyUFO = new PictureBox();
        PictureBox[] bullets = new PictureBox[5];
        PictureBox[] logs = new PictureBox[5];

        bool startFlag = false;
        bool fireFlag = false;
        int cooldown = 12;
        int shooted = 10;
        int enemyHealth = 5;
        int playerSpeed = 10;
        int enemySpeed = 10;
        int bulletSpeed = 10;
        int bulletCount = 0;
        int prev = 0;
        int logSpeed = 6;
        int logCount = 0;
        int logFreq = 20;

        Timer timer1;
        Timer timer2;
        Timer timer3;
        Timer timer4;


        public lab8_VideoGameDevelopment()
        {
            InitializeComponent();
        }

        private void DeleteLog(int i)
        {
            logs[i].Dispose();
            for (int j = i; j < logCount - 1; j++)
            { 
                logs[j] = logs[j + 1];
            }
            logCount--;
        }

        private void DeleteBullet(int i)
        {
            bullets[i].Dispose();
            for (int j = i; j < bulletCount - 1; j++)
            {
                bullets[j] = bullets[j + 1];
            }
            bulletCount--;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playerUFO.Image = new Bitmap(global::lab8_VideoGameDevelopment.Properties.Resources.playerUFO);
            playerUFO.BackColor = Color.Transparent;
            playerUFO.Location = new Point(pictureBox1.Width / 2, pictureBox1.Height - 100);
            playerUFO.Size = new Size(playerUFO.Image.Width, playerUFO.Image.Height); 
            playerUFO.BringToFront();
            pictureBox1.Controls.Add(playerUFO);
            enemyUFO.Image = new Bitmap(global::lab8_VideoGameDevelopment.Properties.Resources.enemyUFO);
            enemyUFO.BackColor = Color.Transparent;
            enemyUFO.Location = new Point(pictureBox1.Width / 2, 20);
            enemyUFO.Size = new Size(playerUFO.Image.Width, playerUFO.Image.Height);
            enemyUFO.BringToFront();
            pictureBox1.Controls.Add(enemyUFO);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (startFlag)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (playerUFO.Location.X < pictureBox1.Width - playerUFO.Width)
                        playerUFO.Left += playerSpeed;
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (playerUFO.Location.X > 0)
                        playerUFO.Left -= playerSpeed;
                }
                if (e.KeyCode == Keys.Space)
                    fireFlag = true;
            }
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startFlag)
            {
                startFlag = false;
                button1.Text = "Start";
                timer1.Dispose();
                timer2.Dispose();
                timer3.Dispose();
                timer4.Dispose();
            }
            else
            {
                startFlag = true;
                button1.Text = "Pause";
                timer1 = new Timer();
                timer2 = new Timer();
                timer3 = new Timer();
                timer4 = new Timer();
                timer1.Interval = 100;
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Enabled = true;
                timer2.Interval = 50;
                timer2.Tick += new EventHandler(timer2_Tick);
                timer2.Enabled = true;
                timer3.Interval = 700;
                timer3.Tick += new EventHandler(timer3_Tick);
                timer3.Enabled = true;
                timer4.Interval = 100;
                timer4.Tick += new EventHandler(timer4_Tick);
                timer4.Enabled = true;
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (startFlag)
            {
                Random a = new Random();
                int RandomEvent = a.Next(900);
                if ((RandomEvent >= 0) & (RandomEvent < logFreq) & (logCount < 5))
                {
                    logCount++;
                    for (int i = logCount - 1; i > 0; i--)
                    {
                        logs[i] = logs[i - 1];
                    }
                    logs[0] = new PictureBox();
                    if ((RandomEvent > -1) & (RandomEvent <= logFreq / 2))
                    {
                        logs[0].Image = new Bitmap(global::lab8_VideoGameDevelopment.Properties.Resources.log);
                        logs[0].Image.Tag = "logLR";
                        logs[0].Location = new Point(0, pictureBox1.Location.Y + a.Next(100) + 100);
                    }
                    else
                    {
                        logs[0].Image = new Bitmap(global::lab8_VideoGameDevelopment.Properties.Resources.log);

                        logs[0].Image.Tag = "logRL";
                        logs[0].Location = new Point(pictureBox1.Width - logs[0].Image.Width,
                        pictureBox1.Location.Y + a.Next(100) + 100);
                    }

                    logs[0].BackColor = Color.Transparent;
                    logs[0].Size = new Size(logs[0].Image.Width, logs[0].Image.Height);
                    logs[0].Name = "log" + logCount.ToString();
                    pictureBox1.Controls.Add(logs[0]);
                    logs[0].BringToFront();
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            var rnd = new Random();
            prev = rnd.Next(2);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (prev == 1)
            {
                if (enemyUFO.Location.X > 0)
                    enemyUFO.Left -= enemySpeed;
            }
            else
            {
                if (enemyUFO.Location.X < pictureBox1.Width - enemyUFO.Width)
                    enemyUFO.Left += enemySpeed;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (shooted > 0)
                shooted--;
            if (fireFlag)
            {
                if (shooted == 0)
                {
                    bulletCount++;
                    for (int i = bulletCount - 1; i > 0; i--)
                    {
                        bullets[i] = bullets[i - 1];
                    }
                    bullets[0] = new PictureBox();
                    bullets[0].Image = new Bitmap(global::lab8_VideoGameDevelopment.Properties.Resources.bullet);
                    bullets[0].Location = new Point(playerUFO.Location.X + playerUFO.Image.Width / 2 - (bullets[0].Image.Width / 2), playerUFO.Location.Y - 50);
                    bullets[0].BackColor = Color.Transparent;
                    bullets[0].Size = new Size(bullets[0].Image.Width, bullets[0].Image.Height);
                    bullets[0].Name = "bullets" + bulletCount.ToString();
                    bullets[0].BringToFront();
                    pictureBox1.Controls.Add(bullets[0]);
                    shooted = cooldown;
                }
            }

            for (int i = 0; i < logCount; i++)
            {
                if (logs[i].Image.Tag.ToString() == "logLR")
                {
                    logs[i].Left += logSpeed;
                    if (logs[i].Left > pictureBox1.Width)
                    {
                        DeleteLog(i);
                    }
                }
                else
                {
                    logs[i].Left -= logSpeed;
                    if (logs[i].Left < 0 - logs[i].Width)
                    {
                        DeleteLog(i);
                    }
                }
            }

            for (int i = 0; i < bulletCount; i++)
            {
                bullets[i].Location = new Point(bullets[i].Location.X, bullets[i].Location.Y - bulletSpeed);

                if (bullets[i].Location.Y < 0)
                    DeleteBullet(i);
                var r1 = bullets[i].DisplayRectangle;

                for (int j = 0; j < logCount; j++)
                {
                    var r3 = logs[j].DisplayRectangle;
                    r1.Location = bullets[i].Location;
                    r3.Location = logs[j].Location;
                    if (r1.IntersectsWith(r3))
                    {
                        DeleteBullet(i);
                        DeleteLog(j);
                    }
                }

                var r2 = enemyUFO.DisplayRectangle;
                r1.Location = bullets[i].Location;
                r2.Location = enemyUFO.Location;
                if (r1.IntersectsWith(r2))
                {
                    DeleteBullet(i);
                    enemyHealth--;
                    health.Text = Convert.ToString(enemyHealth);
                    if (enemyHealth == 0)
                    {
                        button1_Click(sender, e);
                        string message = "Want to play again?";
                        string caption = "You are winner!"; 
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        result = MessageBox.Show(message, caption, buttons);
                        if (result == System.Windows.Forms.DialogResult.No)
                        {
                            this.Close();
                        }
                        else
                        {
                            enemyHealth = 5;
                            health.Text = Convert.ToString(enemyHealth);
                            clearGame();
                            Form1_Load(sender, e);
                        }
                    }
                }
            }
        }

        private void clearGame()
        {
            timer1.Dispose();
            timer2.Dispose();
            timer3.Dispose();
            timer4.Dispose();
            pictureBox1.Controls.Clear();
            startFlag = false;
            fireFlag = false;
            cooldown = 12;
            shooted = 10;
            enemyHealth = 5;
            playerSpeed = 10;
            enemySpeed = 10;
            bulletSpeed = 10;
            bulletCount = 0;
            logCount = 0;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                fireFlag = false;
        }
    }
}
