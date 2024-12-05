using System.Net;
using System.Text;
using System.Text.Json;;
string path = "/Users/olesaandreeva/Desktop/city.txt";
List<string[]> cities = new List<string[]>();
using (StreamReader reader = new StreamReader(path))
{
    string? line;
    while ((line = await reader.ReadLineAsync()) != null)
    {
        string[] parts = line.Replace(", ", "\t").Replace(".", ",").Split('\t');
        cities.Add(parts);
    }
}


while (true)
{
    int count = 0;
    foreach (var el in cities)
    {
        count += 1;
        Console.WriteLine($"{count}. {el[0]}");
    }

    Console.WriteLine("Введите номер страны, если хотите завершить прогамму, то введите 0: ");
    int number = Int16.Parse(Console.ReadLine());
    if (number == 0)
    {
        return;
    }
    FillStatistic(cities[number - 1][1], cities[number - 1][2]);
}




void FillStatistic(string lat,string lon)
{
    string url = "https://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon + "&appid=7ba73cf7112e70ee865966068b0eb102";
    Console.WriteLine(url);
    WebRequest request = WebRequest.Create(url);
    WebResponse response = request.GetResponse();
    StreamReader streamReader = new StreamReader(response.GetResponseStream());
    string responseData = streamReader.ReadToEnd();
    JsonDocument jsonDocument = JsonDocument.Parse(responseData);
    var jsonObject = jsonDocument.RootElement;
    string? name = jsonObject.GetProperty("name").GetString();
    if (name == "") { Console.WriteLine("Неверные координаты"); }
    else
    {
        string? weather = jsonObject.GetProperty("sys").GetProperty("country").GetString();
        double temp = jsonObject.GetProperty("main").GetProperty("temp").GetDouble();
        string? desc = jsonObject.GetProperty("weather")[0].GetProperty("description").GetString();
        Console.WriteLine($"Страна: {weather} город: {name} темпиратура: {temp} описание погоды: {desc}");
    }
}

struct Weather
{
    public string Country { get; set; }

    public string Name { get; set; }

    public double Temp { get; set; }

    public string Description { get; set; }

    public Weather(string country, string name, double temp, string description)
    {
        Country = country;
        Name = name;
        Temp = temp;
        Description = description;
    }

}
