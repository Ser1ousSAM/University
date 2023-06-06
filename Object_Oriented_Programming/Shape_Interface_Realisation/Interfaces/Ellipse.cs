using System.Drawing;

namespace Interfaces
{
    internal class Ellipse : Shape
    {
        public Ellipse() : base() { }

        public Ellipse(PointF loc, SizeF size, Color frontColor, Color borderColor, float width) : base(loc, size, frontColor, borderColor, width) { }

        public override Shape CloneNewLocation(PointF location)
        {
            return new Ellipse(location, Size, FrontColor, BorderColor, Width);
        }

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(BorderColor, Width), Location.X, Location.Y, Size.Width, Size.Height);
            g.FillEllipse(new SolidBrush(FrontColor), Location.X, Location.Y, Size.Width, Size.Height);
        }
    }
}
