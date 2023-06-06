using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbobaCar
{
    public partial class Form1 : Form
    {
        KeyEventArgs s;
        Graphics gr;
        Car aboba;
        Graphics g;
        Bitmap canvas;
        public Form1()
        {
            InitializeComponent();
            canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(canvas);
            pictureBox1.Image = canvas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr = this.CreateGraphics();
            aboba = new Car();
            aboba.Draw(g);
            button1.Enabled = false;
            pictureBox1.Invalidate();
        }
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Right)
            {   
                if (aboba.x >= pictureBox1.Width)
                    aboba.x = 0;
                else
                    aboba.Movement(e, g);
            }
            if (e.KeyData == Keys.Left)
            {
                if (aboba.x < 0)
                    aboba.x = pictureBox1.Width;
                else
                    aboba.Movement(e, g);
            }
            if (e.KeyData == Keys.Up)
            {
                if(aboba.y < 0)
                    aboba.y = pictureBox1.Height;
                else
                    aboba.Movement(e, g);
            }
            if (e.KeyData == Keys.Down)
            {
                if (aboba.y >= pictureBox1.Height)
                    aboba.y = 0;
                else
                    aboba.Movement(e, g);
            }
            aboba.Draw(g);
            pictureBox1.Invalidate();
        }
    }
    public class Car
    {
        public int x;
        public int y;
        public int speed;
        Rectangle model, wheel1, wheel2;
        Color color = Color.Blue;
        public Car ()
        {
            speed = 1;
            model = new Rectangle(x, y, 30, 30);
            wheel1 = new Rectangle(x, y + 30, 15, 15);
            wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
        }
        public Car (int x, int y)
        {
            x = this.x;
            y = this.y;
            model = new Rectangle(x, y, 30, 30);
            wheel1 = new Rectangle(x, y + 30, 15, 15);
            wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
        }
        public void Draw(Graphics g)
        {
            g.Clear(Color.White);
            g.FillRectangle(Brushes.Blue, model);
            g.FillEllipse(Brushes.Black, wheel2);
            g.FillEllipse(Brushes.Black, wheel1);
        }
        public void Movement(KeyEventArgs e, Graphics g)
        {

            if (e.KeyData == Keys.Up)
            {
                this.y -= 10 * speed;
                model = new Rectangle(x, y, 30, 30);
                wheel1 = new Rectangle(x, y + 30, 15, 15);
                wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
            }
            else if(e.KeyData == Keys.Down)
            {
                this.y += 10 * speed;
                model = new Rectangle(x, y, 30, 30);
                wheel1 = new Rectangle(x, y + 30, 15, 15);
                wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
            }
            else if(e.KeyData == Keys.Left)
            {
                this.x -= 10 * speed;
                model = new Rectangle(x, y, 30, 30);
                wheel1 = new Rectangle(x, y + 30, 15, 15);
                wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
            }
            else if(e.KeyData == Keys.Right)
            {
                this.x+=10 * speed;
                model = new Rectangle(x, y, 30, 30);
                wheel1 = new Rectangle(x, y + 30, 15, 15);
                wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
            }
        }
    }
}
