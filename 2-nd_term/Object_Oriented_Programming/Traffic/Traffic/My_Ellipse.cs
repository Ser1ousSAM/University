using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Traffic
{
    [Serializable]
    public class MyEllipse
    {
        public int x, y;
        public int width, height;
        public Color cColor, bColor;

        public MyEllipse()
        {
            x = y = 50;
            width = height = 100;
            cColor = Color.Black;
            bColor = Color.Gray;
        }

        public MyEllipse(int xx, int yy, int w, int h, Color cc, Color bb)
        {
            x = xx;
            y = yy;
            width = w;
            height = h;
            cColor = cc;
            bColor = bb;
        }
        public override string ToString()
        {
            return "Объект класса My_elips";
        }

        public void Draw(Graphics gr)
        {
            Pen pn = new Pen(cColor, 2);
            Brush br = new SolidBrush(bColor);
            gr.FillEllipse(br, x, y, width, height);
            gr.DrawEllipse(pn, x, y, width, height);
        }
    }
}
