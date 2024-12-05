using System.IO;
using System.Net;
using System.Text.Json;
using static System.Net.WebRequestMethods;

//string url = "https://api.marketdata.app/v1/stocks/candles/D/AAPL/?from=2020-01-01&to=2020-01-03";

//Console.WriteLine(json.GetProperty("l").GetArrayLength());
Mutex mutex = new();
StreamReader file = new StreamReader("/Users/olesaandreeva/Desktop/ticker.txt");
StreamWriter fileA = new StreamWriter("/Users/olesaandreeva/Desktop/tickerAverage.txt");
while (!file.EndOfStream)
{
    string ?ticker = file.ReadLine();
    string url = $"https://api.marketdata.app/v1/stocks/candles/D/{ticker}/?from=2024-01-01&to=2024-11-10&token=UUp6R3huX215VHp0akhZOVJaZTN5UUQ5b2F2THotTWhYQ252amhGMk9GUT0";
    JsonElement json = getJson(url);
    if (json.GetProperty("s").GetString() != "ok")
    {
        Console.WriteLine($"Ошибочный тикет : {ticker}");
        continue;
    }
    Task task = new Task(() => writeFile(getJson(url), fileA, ticker));
    task.Start();
}
file.Close();
fileA.Close();
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

void writeFile(JsonElement json, StreamWriter writer, string ticker)
{
    var high = json.GetProperty("h");
    var low = json.GetProperty("l");
    double average = 0;
    int lenHigh = high.GetArrayLength();
    for (int i = 0; i < lenHigh; i++)
    {
        average += (high[i].GetDouble() + low[i].GetDouble()) / 2;
    }
    mutex.WaitOne();
    writer.WriteLine($"{ticker} : {average / lenHigh}");
    Console.WriteLine($"{ticker} : {average / lenHigh}");
    mutex.ReleaseMutex();
}