using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace week2test
{
    public partial class Rectangles : Form
    {
        public Graphics g;

        public Rectangles()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            // Specify form located top left origin of screen
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
            this.Width = 500;
            this.Height = 500;
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Please make sure the your code is like some sequence
            // not randomly paste and it just work
            this.g = e.Graphics;
            var myFont = new System.Drawing.Font("Helvetica", 9);

            var blackPen = new Pen(Color.Black);
            var blackwriter = new SolidBrush(System.Drawing.Color.Black);

            // boundry to other rectangles
            g.DrawRectangle(blackPen, 10, 10, 300, 300);
            g.DrawString("First rectangle", myFont, blackwriter, 10, 10);

            // normal black rectangle
            Rectangle r2 = new Rectangle(200, 30, 50, 50);
            g.DrawRectangle(blackPen, r2);
            g.DrawString("Second Rectangle", myFont, blackwriter, 200, 30);

            // Redefine the position of the rectangle
            r2.Location = new Point(20, 150);

            // Create a green pen and brush
            var greenPen = new Pen(Color.Green, 5);
            var greenwriter = new SolidBrush(System.Drawing.Color.Green);

            // Redraw the rectangle using green pen and brush
            g.DrawRectangle(greenPen, r2);
            g.DrawString("Third Rectangle", myFont, greenwriter, 20, 150);

            // Enlarge rectangle by expanding 25 pixels in both directions on each axis
            r2.Inflate(25, 25); // width and height now 100x100
            // Relocate enlarged rectangle
            r2.Location = new Point(150, 150);
            // Redraw enlarged rectangle at new position with black pen          
            g.DrawRectangle(blackPen, r2);

            // Now fill the rectangle with a fancy gradient colour change from top left red to bottom right green
            // Create a diagonal linear gradient from start to end points of pure colour   
            LinearGradientBrush gradient = new LinearGradientBrush(
                new Point(150, 150),
                new Point(250, 250),
                Color.FromArgb(255, 255, 0, 0),
                Color.FromArgb(255, 0, 255, 0));

            g.FillRectangle(gradient, r2);

            // Use a new font and write italicised title over the rectangle 
            Font newFont = new System.Drawing.Font("Georgia", 12, FontStyle.Italic);
            g.DrawString("Fourth Rectangle", newFont, blackwriter, 150, 150);
        }
    }
}
