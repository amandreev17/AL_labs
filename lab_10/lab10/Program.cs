using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

using System.IO;
using System.Net;
using System.Text.Json;
using static System.Net.WebRequestMethods;


using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
    int id = 1;
    StreamReader file = new StreamReader("/Users/olesaandreeva/Desktop/ticker.txt");
    while (!file.EndOfStream)
    {
        string? ticker = file.ReadLine();
        string url = $"https://api.marketdata.app/v1/stocks/candles/D/{ticker}/?from=2024-11-21&to=2024-11-23&token=UUp6R3huX215VHp0akhZOVJaZTN5UUQ5b2F2THotTWhYQ252amhGMk9GUT0";
        JsonElement json = getJson(url);
        if (json.GetProperty("s").GetString() != "ok")
        {
            Console.WriteLine($"Ошибочный тикет : {ticker}");
            continue;
        }
        writeDB(getJson(url), ticker);
    }
    file.Close();
    JsonElement getJson(string url)
    {
        try
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string responseData = streamReader.ReadToEnd();
            JsonDocument jsonDocument = JsonDocument.Parse(responseData);
            var jsonObject = jsonDocument.RootElement;
            return jsonObject;
        }
        catch
        {
            string responseData = "{\"s\" : \"error\"}";
            JsonDocument jsonDocument = JsonDocument.Parse(responseData);
            var jsonObject = jsonDocument.RootElement;
            return jsonObject;
        }
    }

    void writeDB(JsonElement json, string ticker)
    {
        try {
            var high = json.GetProperty("h");
            var low = json.GetProperty("l");
            double priceCurrent = (high[1].GetDouble() + low[1].GetDouble()) / 2;
            string state = "";
            if (priceCurrent > ((high[0].GetDouble() + low[0].GetDouble()) / 2))
            {
                state = "gain";
            }
            else { state = "loss"; }
            Tickers tickers = new Tickers { Id = id, Ticker = ticker };
            Prices price = new Prices { Id = id, TickerId = id, Price = priceCurrent, Date = "2024-11-23" };
            TodayCondition today = new TodayCondition { Id = id, State = state, TickerId = id };
            db.Tickers.Add(tickers);
            db.Prices.Add(price);
            db.TodayCondition.Add(today);
            id++;
            Console.WriteLine(ticker);
        }
        catch
        {
            return;
        }
    }


    // добавляем их в бд
    db.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");
}

public class ApplicationContext : DbContext
{
    public DbSet<Tickers> Tickers { get; set; } = null!;
    public DbSet<Prices> Prices { get; set; } = null!;
    public DbSet<TodayCondition> TodayCondition { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }

}

public class Tickers
{
    public int Id { get; set; }
    public string? Ticker { get; set; }
}

public class Prices
{
    public int Id { get; set; }
    public int TickerId { get; set; }
    public double Price { get; set; }
    public string? Date { get; set; }
}

public class TodayCondition
{
    public int Id { get; set; }
    public int TickerId { get; set; }
    public string? State { get; set; }
}
