using System;
using System.Drawing;
using System.Windows.Forms;

// cant use fine-scoped using f
namespace Triangle
{
    public partial class Triangle : Form
    {
        private Graphics _graphics;

        private Pen _pen;

        private Font _font;

        public Triangle()
        {
            // Maximises the form whilst retaining the menu bar;
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this._graphics = e.Graphics;
            this._pen = new Pen(Color.Black);
            this._font = new Font("VCR OSD MONO", 12);

            var firstTrianglePoints = new TrianglePoints(
                new Coordinates(100, 100), 
                new Coordinates(500, 100), 
                new Coordinates(300, 446)
            );

            DrawSierpinskiTriangle(firstTrianglePoints);
        }

        public void DrawSierpinskiTriangle(TrianglePoints trianglePoints)
        {
            int count = 0;

            DrawTriangle(trianglePoints);

            while (true)
            {
                // root((x2 - x1)^2 + (y2 - y1)^2)
                double sideLength = Math.Sqrt(
                    Math.Pow(trianglePoints.point1.x - trianglePoints.point2.x, 2) +
                    Math.Pow(trianglePoints.point1.y - trianglePoints.point2.y, 2)
                );

                if (sideLength < 1) break;

                trianglePoints = new TrianglePoints(
                    (trianglePoints.point1 + trianglePoints.point2) / 2, 
                    (trianglePoints.point2 + trianglePoints.point3) / 2, 
                    (trianglePoints.point3 + trianglePoints.point1) / 2
                );
                DrawTriangle(trianglePoints);

                count++;
            }
            
            _graphics.DrawString($"Iterations: {count}", _font, Brushes.Black, 100, 80);
        }

        public void DrawTriangle(TrianglePoints trianglePoints)
        {
            DrawLine(trianglePoints.point1, trianglePoints.point2);
            DrawLine(trianglePoints.point2, trianglePoints.point3);
            DrawLine(trianglePoints.point3, trianglePoints.point1);
        }

        public void DrawLine(Coordinates co1, Coordinates co2)
            => _graphics.DrawLine(_pen, co1.x, co1.y, co2.x, co2.y);

        public static void Main()
            => Application.Run(new Triangle());
    }

    public struct TrianglePoints
    {
        public Coordinates point1;

        public Coordinates point2;

        public Coordinates point3;

        public TrianglePoints(Coordinates p1, Coordinates p2, Coordinates p3)
        {
            point1 = p1;
            point2 = p2;
            point3 = p3;
        }
    }


    public struct Coordinates
    {
        public int x;

        public int y;
        
        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Coordinates operator +(Coordinates a, Coordinates b)
            => new Coordinates(a.x + b.x, a.y + b.y);

        public static Coordinates operator /(Coordinates a, int b)
        {
            // Why do you divide by zero?
            if (b == 0) throw new DivideByZeroException();
            return new Coordinates(a.x / b, a.y / b);
        }
    }
}