using System.Drawing;

namespace Interfaces
{
    internal abstract class Shape : IDrawable
    {
        private SizeF _size;
        public PointF Location { get; set; }
        public float Width { get; set; }
        public SizeF Size
        {
            get => _size;
            set
            {
                if (value.Width < 3)
                    _size.Width = 3;
                else
                    _size.Width = value.Width;
                if (value.Height < 3)
                    _size.Height = 3;
                else
                    _size.Height = value.Height;
            }
        }
        public Color FrontColor { get; set; }
        public Color BorderColor { get; set; }

        public Shape()
        {
            Location = new PointF(50, 50);
            Width = 5;
            Size = new SizeF(100, 100);
            FrontColor = Color.White;
            BorderColor = Color.Black;
        }

        public Shape(PointF point, SizeF size, Color frontColor, Color borderColor, float width)
        {
            Location = new PointF(point.X - size.Width / 2, point.Y - size.Height / 2);
            Width = width;
            Size = size;
            FrontColor = frontColor;
            BorderColor = borderColor;
        }

        public abstract Shape CloneNewLocation(PointF location);

        public abstract void Draw(Graphics g);

        public override string ToString()
        {
            return $"Class object: {GetType()}, Location: x = {Location.X}, y = {Location.Y}";
        }
    }
}
