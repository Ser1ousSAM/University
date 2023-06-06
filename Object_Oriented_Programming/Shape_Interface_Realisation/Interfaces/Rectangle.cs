using System.Drawing;

namespace Interfaces
{
    internal class Rectangle : Shape
    {
        public Rectangle() : base() { }

        public Rectangle(PointF loc, SizeF size, Color frontColor, Color borderColor, float width) : base(loc, size, frontColor, borderColor, width) { }

        public override Shape CloneNewLocation(PointF location)
        {
            return new Rectangle(location, Size, FrontColor, BorderColor, Width);
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(BorderColor, Width), Location.X, Location.Y, Size.Width, Size.Height);
            g.FillRectangle(new SolidBrush(FrontColor), Location.X, Location.Y, Size.Width, Size.Height);
        }
    }
}
