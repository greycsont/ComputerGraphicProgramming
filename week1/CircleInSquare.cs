using System;
using System.Drawing;
using System.Windows.Forms;
namespace week1
{
    public partial class CircleInSquare : Form
    {
        public CircleInSquare()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 500;
            this.Height = 500;
            this.BackColor = Color.White;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Create a pen object
            Pen blackPen = new Pen(Color.Black);
            // Draw an ellipse
            g.DrawEllipse(blackPen, new Rectangle(250, 50, 200, 200));
            g.DrawRectangle(blackPen, 250, 50, 200, 200);

        }
    }
}
