using System;
using Microsoft.Data.Sqlite;
Console.WriteLine("Введиет тикет:");
string? ticker = Console.ReadLine();
string sqlExpression = $"SELECT * FROM Tickers WHERE Ticker = '{ticker}'";
string? id = "";
using (var connection = new SqliteConnection("Data Source=/Users/olesaandreeva/Desktop/helloapp.db"))
{
    connection.Open();
    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
    using (SqliteDataReader reader = command.ExecuteReader())
    {
        if (reader.HasRows)
        {
            reader.Read();
            id = reader.GetValue(0).ToString();
            Console.WriteLine($"Данный тикет есть в базе данных: {id}");

        }
        else { Console.WriteLine("Данного тикета нет в базе данных"); return; }
    }
    string sqlExpression1 = $"SELECT * FROM Prices WHERE TickerId = '{id}'";
    SqliteCommand command1 = new SqliteCommand(sqlExpression1, connection);
    using (SqliteDataReader reader = command1.ExecuteReader())
    {
        reader.Read();
        string? price = reader.GetValue(2).ToString();
        string? date = reader.GetValue(3).ToString();
        Console.WriteLine($"Цена: {price}, дата: {date}");

    }
    string sqlExpression2 = $"SELECT * FROM TodayCondition WHERE TickerId = '{id}'";
    SqliteCommand command2 = new SqliteCommand(sqlExpression2, connection);
    using (SqliteDataReader reader = command2.ExecuteReader())
    {
        reader.Read();
        string? condition = reader.GetValue(2).ToString();
        Console.WriteLine($"Состояние: {condition}");

    }

}