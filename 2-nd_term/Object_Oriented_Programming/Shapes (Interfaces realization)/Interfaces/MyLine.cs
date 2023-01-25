using System.Drawing;

namespace Interfaces
{


    internal class MyLine : IDrawable
    {
        public PointF _point1, _point2;
        public Color BorderColor { get; set; }
        public MyLine() : base()
        {
            BorderColor = Color.Black;
        }
        public MyLine(PointF point1, PointF point2) : base()
        {
            this._point1 = point1;
            this._point2 = point2;
            BorderColor = Color.Black;
        }

        public void Draw(Graphics g)
        {
            g.DrawLine(new Pen(BorderColor), _point1, _point2);
        }

    }
}
