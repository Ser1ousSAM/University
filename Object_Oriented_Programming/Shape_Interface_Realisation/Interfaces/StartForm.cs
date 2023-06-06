using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Interfaces
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private List<IDrawable> _shapes;
        private Shape _currentShape;
        private Graphics _g;
        private Bitmap _albedo;
        private Color _background;
        private bool _isPressedDownLineButton = false;

        private void StartForm_Load(object sender, EventArgs e)
        {
            _albedo = new Bitmap(canvas.Width, canvas.Height);
            _g = Graphics.FromImage(_albedo);
            canvas.Image = _albedo;
            _background = canvas.BackColor;
            _shapes = new List<IDrawable>();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            if (_shapes == null) return;
            foreach (var s in _shapes)
                s.Draw(e.Graphics);
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (_currentShape == null && !_isPressedDownLineButton) return;
            if (_isPressedDownLineButton)
            {
                _locationOfPoint = e.Location;
                if (_pointExists)
                {
                    _shapes.Add(new MyLine(_locationOfPoint, _locationOfPoint2));
                    _pointExists = false;
                }
                else
                {
                    _locationOfPoint2 = _locationOfPoint;
                    _pointExists = true;
                }

            }
            else
            {
                var shape = _currentShape.CloneNewLocation(e.Location);
                _shapes.Add(shape);
            }
            canvas.Invalidate();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _shapes.Clear();
            _g.Clear(_background);
            canvas.Invalidate();
        }

        private void buttonRectangle_Click_1(object sender, EventArgs e)
        {
            _isPressedDownLineButton = false;
            _currentShape = new Rectangle();
        }

        private void buttonEllipse_Click_1(object sender, EventArgs e)
        {
            _isPressedDownLineButton = false;
            _currentShape = new Ellipse();
        }

        private PointF _locationOfPoint, _locationOfPoint2;
        private bool _pointExists = false;
        private void buttonLine_Click(object sender, EventArgs e)
        {
            _isPressedDownLineButton = true;
        }
    }
}
