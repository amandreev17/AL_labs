using System.Net;
using System.Text.Json;

List<Weather> weathers = new List<Weather>();
FillStatistic(weathers);

var temp = from w in weathers
               orderby w.Temp
               select w;
Weather w_max = temp.Last();
Weather w_min = temp.First();
Console.WriteLine("");
Console.WriteLine($"{w_max.Country} {w_max.Temp}");
Console.WriteLine($"{w_min.Country} {w_min.Temp}");
var med = weathers.Average(w => w.Temp);
Console.WriteLine($"Среднее значение температуры: {med}");
var count = weathers.Count();
Console.WriteLine($"Число стран {count}");
var weather1 = from w in weathers
               where w.Description == "clear sky" || w.Description == "rain" || w.Description == "few clouds"
               select w;
var f_weather = weather1.First();
Console.WriteLine($"{f_weather.Country} {f_weather.Name} {f_weather.Description}");
void FillStatistic(List<Weather> weathers)
{
    while (weathers.Count != 50)
    {
        Random rnd = new Random();
        int lat = rnd.Next(-90, 90);
        int lon = rnd.Next(-180, 180);
        string url = "https://api.openweathermap.org/data/2.5/weather?lat=" + lat.ToString() + "&lon=" + lon.ToString() + "&appid=7ba73cf7112e70ee865966068b0eb102";

        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        StreamReader streamReader = new StreamReader(response.GetResponseStream());

        string responseData = streamReader.ReadToEnd();
        JsonDocument jsonDocument = JsonDocument.Parse(responseData);
        var jsonObject = jsonDocument.RootElement;
        string? name = jsonObject.GetProperty("name").GetString();
        if (name == "") { continue; }
        else
        {
            string? weather = jsonObject.GetProperty("sys").GetProperty("country").GetString();
            double temp = jsonObject.GetProperty("main").GetProperty("temp").GetDouble();
            string? desc = jsonObject.GetProperty("weather")[0].GetProperty("description").GetString();
            weathers.Add(new Weather(weather, name, temp, desc));
            Console.WriteLine("Местность добавлена");
        }
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
