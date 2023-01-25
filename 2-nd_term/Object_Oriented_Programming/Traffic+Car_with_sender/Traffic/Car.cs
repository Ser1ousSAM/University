using System.Drawing;
using System.Windows.Forms;

namespace Traffic
{
    public class Car
    {
        public int x;
        public int y;
        public int speed;
        Rectangle model, wheel1, wheel2;
        Color color = Color.Blue;
        public Car()
        {
            speed = 1;
            model = new Rectangle(x, y, 30, 30);
            wheel1 = new Rectangle(x, y + 30, 15, 15);
            wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
        }
        public Car(int x, int y)
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

            if (e.KeyData == Keys.W)
            {
                this.y -= 10 * speed;
                model = new Rectangle(x, y, 30, 30);
                wheel1 = new Rectangle(x, y + 30, 15, 15);
                wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
            }
            else if (e.KeyData == Keys.S)
            {
                this.y += 10 * speed;
                model = new Rectangle(x, y, 30, 30);
                wheel1 = new Rectangle(x, y + 30, 15, 15);
                wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
            }
            else if (e.KeyData == Keys.A)
            {
                this.x -= 10 * speed;
                model = new Rectangle(x, y, 30, 30);
                wheel1 = new Rectangle(x, y + 30, 15, 15);
                wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
            }
            else if (e.KeyData == Keys.D)
            {
                this.x += 10 * speed;
                model = new Rectangle(x, y, 30, 30);
                wheel1 = new Rectangle(x, y + 30, 15, 15);
                wheel2 = new Rectangle(x + 20, y + 30, 15, 15);
            }
        }
    }
}
