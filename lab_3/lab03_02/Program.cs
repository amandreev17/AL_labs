Car[] cars = { new Car("Porshe", "506", 300), new Car("Lada", "134", 180), new Car("BMW", "456", 270) };
CarsCatalog carsCatalog = new CarsCatalog(cars);

Console.WriteLine(carsCatalog[1]);
Console.WriteLine(carsCatalog[0]);
Console.WriteLine(carsCatalog[2]);

Car car = new Car("BMW", "456", 270);
Car car1 = new Car("BMW", "456", 270);

Console.WriteLine(car.ToString());
Console.WriteLine(car.Equals(car1));


class Car : IEquatable<Car>
{
    public string Name { get; }
    public string Engine { get; }
    public int MaxSpeed { get; }

    public Car(string name, string eng, int sp)
    {
        Name = name;
        Engine = eng;
        MaxSpeed = sp;
    }
    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car? car)
    {
        if (car == null) return false;
        return this.Name == car.Name && this.Engine == car.Engine && this.MaxSpeed == car.MaxSpeed;
    }
}

class CarsCatalog
{
    Car[] cars;

    public CarsCatalog(Car[] _cars) => cars = _cars;
    public string this[int index]
    {
        get
        {
            return cars[index].Name + " " + cars[index].MaxSpeed.ToString();
        }
    } 
}