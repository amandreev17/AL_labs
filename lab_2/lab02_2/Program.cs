namespace lab02_2
{
    public class Program1
    {
        public static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle(1000, 250, 2006);
            vehicle.Information();
            Console.WriteLine("");
            Plane plane = new Plane(10000, 400, 2010, 1000, 30);
            plane.Information();
            Console.WriteLine("");
            Ship ship = new Ship(10500, 80, 1999, "Royal", 3000);
            ship.Information();
            Console.WriteLine("");
        }
    }

    class Vehicle
    {
        private int price;
        private int speed;
        private int year;

        public Vehicle(int p, int s, int y)
        {
            price = p;
            speed = s;
            year = y;
        }

        public virtual void Information()
        {
            Console.Write($"цена: {price}, скорость: {speed}, год выпуска {year}");
        }
    }

    class Plane : Vehicle
    {
        private int hight;
        private int countP;

        public Plane(int p, int s, int y, int h, int c) : base(p, s, y)
        {
            hight = h;
            countP = c;
        }

        public override void Information()
        {
            base.Information();
            Console.Write($" высота: {hight}, число пассажиров: {countP}");
        }
    }

    class Ship : Vehicle
    {
        private string port;
        private int countP;

        public Ship(int p, int s, int y, string _port, int c) : base(p, s, y)
        {
            port = _port;
            countP = c;
        }

        public override void Information()
        {
            base.Information();
            Console.Write($" порт: {port}, число пассажиров: {countP}");
        }
    }
}

