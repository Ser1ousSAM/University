using System.Drawing;

namespace Interfaces
{
    internal interface IDrawable
    {
        Color BorderColor { get; set; }

        void Draw(Graphics g);
    }
}
