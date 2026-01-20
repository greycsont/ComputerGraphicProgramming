### week 1
CGP.Program create a new window object `CircleInSquare`, this instance called InitializeComponent via CircleSquare.Designer.cs to find `OnPaint` method, it passes itself/window as a graphics for drawing, then create a pointer/pen to draw shapes with black attributes

The Winform's built-in shape-drawing is set every shape's origin in the left-top corner. The `DrawEllipse` and `DrawRectangle` requires:
pen, x-axis compare to window's origin, y-axis compare to window's origin, width of shape, height of shape

The drawing is also uses top-left corner as origin