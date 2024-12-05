using lab1_2;
using lab1_3;

Console.WriteLine("Первое задание");
Console.WriteLine("Минимальные и максимальные значения для предопределенных типов данных CTS:");
Console.WriteLine("Целочисленные");
Console.WriteLine($"byte: min = {byte.MinValue}, max = {byte.MaxValue}");
Console.WriteLine($"sbyte: min = {sbyte.MinValue}, max = {sbyte.MaxValue}");
Console.WriteLine($"short: min = {short.MinValue}, max = {short.MaxValue}");
Console.WriteLine($"ushort: min = {ushort.MinValue}, max = {ushort.MaxValue}");
Console.WriteLine($"int: min = {int.MinValue}, max = {int.MaxValue}");
Console.WriteLine($"unit: min = {uint.MinValue}, max = {uint.MaxValue}");
Console.WriteLine($"long: min = {long.MinValue}, max = {long.MaxValue}");
Console.WriteLine($"ulong: min = {ulong.MinValue}, max = {ulong.MaxValue}");

Console.WriteLine("С плавающей запятой");
Console.WriteLine($"float: min = {float.MinValue}, max = {float.MaxValue}");
Console.WriteLine($"double: min = {double.MinValue}, max = {double.MaxValue}");
Console.WriteLine($"decimal: min = {decimal.MinValue}, max = {decimal.MaxValue}");

Console.WriteLine("bool: true / false");
Console.WriteLine($"char: min = {char.MinValue}, max = {char.MaxValue}");
Console.WriteLine($"TimeSpan: min = {TimeSpan.MinValue}, max = {TimeSpan.MaxValue}");
Console.WriteLine($"DateTime: min = {DateTime.MinValue}, max = {DateTime.MaxValue}");
Console.WriteLine($"Nullable<T>: null");
Console.WriteLine("");


Console.WriteLine("Второе задание");
Console.WriteLine("Введите первую сторону прямоугольника:");
double sA = double.Parse(Console.ReadLine()!);
Console.WriteLine("Введите вторую сторону прямоугольника:");
double sB = double.Parse(Console.ReadLine()!);
Rectangle rectangle = new Rectangle(sA, sB);
Console.WriteLine($"Периметр прямоугольника: {rectangle.Perimeter}");
Console.WriteLine($"Площадь прямоугольника: {rectangle.Area}");
Console.WriteLine("");

Console.WriteLine("Третье задание");
Figure figure = new Figure(new Point(0, 0), new Point(5, 0), new Point(5, 5), new Point(0, 5));
Console.WriteLine($"Название: {figure.Name}, периметр: {figure.PerimeterCalculator()}");