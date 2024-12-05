using System;

Car car2 = new Car("porshe", 2010, 300);
Car car3 = new Car("lada", 2005, 200);
Car car4 = new Car("bmw", 2020, 340);

Car[] cars = { car2, car3, car4 };
Array.Sort(cars, new CarComparer("name"));
foreach (Car car in cars)
{
    car.Print();
}
Console.WriteLine("");
Array.Sort(cars, new CarComparer("year"));
foreach (Car car in cars)
{
    car.Print();
}
Console.WriteLine("");
Array.Sort(cars, new CarComparer("speed"));
foreach (Car car in cars)
{
    car.Print();
}
Console.WriteLine("");
var cars1 = new CarCatalog(cars);

foreach (Car car in cars1.GetCars())
{
    car.Print();
}
Console.WriteLine("");
foreach (Car car in cars1.GetReverse())
{
    car.Print();
}
Console.WriteLine("");

foreach (int car in cars1.GetYear())
{
    Console.WriteLine(car);
}
Console.WriteLine("");
foreach (int car in cars1.GetSpeed())
{
    Console.WriteLine(car);
}

class CarComparer : IComparer<Car>
{
    private string _type = "";

    public CarComparer(string type)
    {
        _type = type;
    }

    public int Compare(Car? car, Car? car1)
    {
        if (car is null || car1 is null)
        {
            throw new Exception("Некорректное значение параметра");
        }
        else if (_type == "name")
        {
            return car.Name.Length - car1.Name.Length;
        }
        else if (_type == "year")
        {
            return car.ProductionYear - car1.ProductionYear;
        }
        return car.MaxSpeed - car1.MaxSpeed;
    }
}


class Car
{
    public string Name { get; set; } = "";

    public int ProductionYear { get; set; }

    public int MaxSpeed { get; set; }

    public Car(string name, int year, int speed)
    {
        Name = name;
        ProductionYear = year;
        MaxSpeed = speed;
    }

    public void Print()
    {
        Console.WriteLine($"скорость: {Name}, год выпуска: {ProductionYear}, макс. скорость: {MaxSpeed}");
    }
}

class CarCatalog
{
    Car[] cars;
    public CarCatalog(Car[] c) => this.cars = c;
    
    public IEnumerable<Car> GetCars()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            yield return cars[i];
        }
    }

    public IEnumerable<Car> GetReverse()
    {
        for (int i = cars.Length - 1; i >= 0; i--)
        {
            yield return cars[i];
        }
    }

    public IEnumerable<int> GetYear()
    {
        for (int i = 0; i < cars.Length; i++)
        {
           
            yield return cars[i].ProductionYear;
            
        }
    }

    public IEnumerable<int> GetSpeed()
    {
        for (int i = 0; i < cars.Length; i++)
        {
           
            yield return cars[i].MaxSpeed;
        }
    }
}