namespace tests;
using lab1_2;
using lab1_3;
[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestPerimeter()
    {
        Rectangle rectangle = new Rectangle(3, 4);
        Assert.AreEqual(14, rectangle.Perimeter);
    }
    [TestMethod]
    public void TestArea()
    {
        Rectangle rectangle = new Rectangle(9, 5);
        Assert.AreEqual(45, rectangle.Area);
    }
    [TestMethod]
    public void TestPoint()
    {
        Point point = new Point(9, -10);
        Assert.AreEqual(9, point.X);
        Assert.AreEqual(-10, point.Y);
    }
    [TestMethod]
    public void TestLenghtSide()
    {
        Figure figure = new Figure(new Point(0, 0), new Point(3, 0), new Point(3, 3), new Point(0, 3));
        Assert.AreEqual(5, figure.LengthSide(new Point(0, 0), new Point(0, 5)));
    }
    [TestMethod]
    public void TestPerimeter2()
    {
        Figure figure = new Figure(new Point(0, 0), new Point(3, 0), new Point(3, 3), new Point(0, 3));
        Assert.AreEqual(12, figure.PerimeterCalculator());
    }
}
