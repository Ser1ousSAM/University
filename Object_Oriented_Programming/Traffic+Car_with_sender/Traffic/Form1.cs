using System;
using System.Drawing;
using System.Windows.Forms;

namespace Traffic
{
    public partial class Form1 : Form 
    {

        Graphics grForTraffic, grForCar;
        TrafficLight tr;
        Car aboba;
        Bitmap canvas;
        bool isMove=true;

        

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grForCar = Graphics.FromImage(canvas);
            pictureBox1.Image = canvas;
            aboba = new Car();
            aboba.Draw(grForCar);
            pictureBox1.Invalidate();

            mode0.Enabled = true;
            mode1.Enabled = true;
            grForTraffic = panel1.CreateGraphics();
            tr = new TrafficLight(panel1,panel1.Width,panel1.Height, 100, grForTraffic);
            tr.Notify += PossibilityMovement;
            tr.Draw(grForTraffic);
            create.Visible = false;
            Next.Enabled = true;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            state_timer.Stop();
            tr.Mode++;
            grForTraffic = panel1.CreateGraphics();
            state_timer.Start();
            if (mode0.Checked)
                mode1.Checked = true;
            else
                mode0.Checked = true;
        }

        private void state_timer_Tick(object sender, EventArgs e)
        {
            tr.Next();
            tr.Draw(grForTraffic);
        }

        private void mode0_CheckedChanged(object sender, EventArgs e)
        {
            isMove = true;
            if (mode0.Checked)
            {
                tr.Mode = 0;
                state_timer.Stop();
                grForTraffic = panel1.CreateGraphics();
                state_timer.Start();
            }
        }

        private void mode1_CheckedChanged(object sender, EventArgs e)
        {
            isMove = true;
            if (mode1.Checked)
            {
                tr.Mode = 1;
                state_timer.Stop();
                grForTraffic = panel1.CreateGraphics();
                state_timer.Start();
            }
        }
        private void PossibilityMovement()
        {
            isMove = !isMove;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isMove)
                return;
            if (e.KeyData == Keys.W)
            {
                if (aboba.y < 0)
                    aboba.y = pictureBox1.Height;
                else
                    aboba.Movement(e, grForCar);
            }
            if (e.KeyData == Keys.A)
            {
                if (aboba.x < 0)
                    aboba.x = pictureBox1.Width;
                else
                    aboba.Movement(e, grForCar);
            }
            if (e.KeyData == Keys.S)
            {
                if (aboba.y >= pictureBox1.Height)
                    aboba.y = 0;
                else
                    aboba.Movement(e, grForCar);
            }
            if (e.KeyData == Keys.D)
            {
                if (aboba.x >= pictureBox1.Width)
                    aboba.x = 0;
                else
                    aboba.Movement(e, grForCar);
            }
            aboba.Draw(grForCar);
            pictureBox1.Invalidate();
        }

    }
}
