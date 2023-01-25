using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Traffic
{
    public class TrafficLight
    {
        Rectangle shape;
        MyEllipse red, yellow, green;

        private int x, y, height;
        private int mode, state;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Mode
        {
            get { return mode; }
            set
            {
                state = 0;
                if (value == 3)
                    mode = 0;
                else
                    mode = value;
            }
        }

        public TrafficLight()
        {
            this.X = 100;
            this.Y = 100;
            this.Height = 100;
            this.state = 0;

            red = new MyEllipse(X, Y - Height, Height, Height, Color.Black, Color.Black);
            yellow = new MyEllipse(X, Y, Height, Height, Color.Black, Color.Black);
            green = new MyEllipse(X, Y + Height, Height, Height, Color.Black, Color.Black);
            shape = new Rectangle(X - (X / 8), (Y - Height) / 4, (Height * 2) - Height / 2, Height * 4);
        }

        public TrafficLight(Panel p1, int a, int b, int height, Graphics g1)
        {
            // width and height for panel
            p1.Width = a;
            p1.Height = b;

            this.X = p1.Width / 3;
            this.Y = p1.Height / 3;
            this.Height = height;
            this.state = 0;

            red = new MyEllipse(X, Y - Height, Height, Height, Color.Black, Color.Black);
            yellow = new MyEllipse(X, Y, Height, Height, Color.Black, Color.Black);
            green = new MyEllipse(X, Y + Height, Height, Height, Color.Black, Color.Black);
            shape = new Rectangle(X - (X / 8), (Y - Height) / 4, (Height * 2) - Height / 2, Height * 4);
            g1.FillRectangle(Brushes.Gray, shape);

        }

        public void Draw(Graphics g1)
        {
            red.Draw(g1);
            yellow.Draw(g1);
            green.Draw(g1);
        }

        private void Switcher()
        {
            state++;
            switch (mode)
            {
                case 0:
                    if (state == 3)
                        state = 0;
                    break;
                case 1:
                    if (state == 4)
                        state = 0;
                    break;
                case 2:
                    if (state == 2)
                        state = 0;
                    break;
            }
        }

        public void Next()
        {
            if (mode == 0)
            {
                switch (state)
                {
                    case 0:
                        red.bColor = Color.Red;
                        yellow.bColor = Color.Black;
                        green.bColor = Color.Black;
                        break;
                    case 1:
                        red.bColor = Color.Black;
                        yellow.bColor = Color.Yellow;
                        green.bColor = Color.Black;
                        break;
                    case 2:
                        red.bColor = Color.Black;
                        yellow.bColor = Color.Black;
                        green.bColor = Color.Green;
                        break;
                }
            }
            else if (mode == 1)
            {
                switch (state)
                {
                    case 0:
                        red.bColor = Color.Red;
                        yellow.bColor = Color.Black;
                        green.bColor = Color.Black;
                        break;
                    case 1:
                        red.bColor = Color.Black;
                        yellow.bColor = Color.Yellow;
                        green.bColor = Color.Black;
                        break;
                    case 2:
                        red.bColor = Color.Black;
                        yellow.bColor = Color.Black;
                        green.bColor = Color.Green;
                        break;
                    case 3:
                        red.bColor = Color.Black;
                        yellow.bColor = Color.Yellow;
                        green.bColor = Color.Black;
                        break;
                }
            }
            else
            {
                switch (state)
                {
                    case 0:
                        red.bColor = Color.Black;
                        yellow.bColor = Color.Yellow;
                        green.bColor = Color.Black;
                        break;
                    case 1:
                        red.bColor = Color.Black;
                        yellow.bColor = Color.Black;
                        green.bColor = Color.Black;
                        break;
                }
            }
            Switcher();
        }
    }
}
