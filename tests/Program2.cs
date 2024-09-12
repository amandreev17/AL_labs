namespace lab1_2
{
    class Rectangle
    {
        private double sideA;
        private double sideB;

        public Rectangle(double sA, double sB) { sideA = sA; sideB = sB; }
        private double CalculateArea() { return sideB * sideA; }
        private double CalculatePerimeter() { return (sideA + sideB) * 2; }
        public double Area { get { return CalculateArea(); } }
        public double Perimeter { get { return CalculatePerimeter(); } }
    }
}

namespace lab1_3
{
    class Point
    {
        private int x;
        private int y;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Point(int _x, int _y) { x = _x; y = _y; }
    }

    class Figure
    {
        private Point[] points = new Point[5];

        public string Name { get; set; }

        public Figure(Point p1, Point p2, Point p3, Point p4, Point p5)
        {
            (points[0], points[1], points[2], points[3], points[4], Name) = (p1, p2, p3, p4, p5, "Пятиугольник");
        }
        public Figure(Point p1, Point p2, Point p3, Point p4) : this(p1, p2, p3, p4, new Point(-1, -1)) { Name = "Четырёхугольник"; }
        public Figure(Point p1, Point p2, Point p3) : this(p1, p2, p3, new Point(-1, -1)) { Name = "Треугольник"; }

        public double LengthSide(Point A, Point B)
        {
            int x = A.X - B.X;
            int y = A.Y - B.Y;
            return Math.Sqrt(x * x + y * y);
        }

        public double PerimeterCalculator()
        {
            double perimeter = 0;
            int count = 0;
            for (int i = 0; i < points.Length - 1; ++i)
            {   if (points[i + 1].X == -1) break;
                perimeter += LengthSide(points[i], points[i + 1]);
                count += 1;
            }
            perimeter += LengthSide(points[0], points[count]);
            return perimeter;
        }
    }
}