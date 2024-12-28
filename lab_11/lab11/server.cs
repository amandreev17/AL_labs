using System.Text;
using System.Net;
using System.Net.Sockets;
using Microsoft.Data.Sqlite;
// Устанавливаем для сокета локальную конечную точку 
IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 11000);

// Создаем сокет Tcp/Ip
Socket sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

// Назначаем сокет локальной конечной точке и слушаем входящие сокеты
try
{
    sListener.Bind(ipEndPoint);
    sListener.Listen(10);

    // Начинаем слушать соединения
    while (true)
    {
        Console.WriteLine("Ожидаем соединение через порт {0}", ipEndPoint);

        // Программа приостанавливается, ожидая входящее соединение
        Socket handler = sListener.Accept();
        string? ticker = null;

        // Мы дождались клиента, пытающегося с нами соединиться

        byte[] bytes = new byte[1024];
        int bytesRec = handler.Receive(bytes);

        ticker += Encoding.UTF8.GetString(bytes, 0, bytesRec);

        // Показываем данные на консоли
        Console.Write("Полученный текст: " + ticker + "\n\n");



        // Отправляем ответ клиенту\
        string reply = "";
        string? answer = lastPrice(ticker);
        if (answer == "none")
        {
            reply = "Данного тикета нет в базе данных";
        }
        else
        {
            reply = $"Стоимость: {lastPrice(ticker)}";
        }
        byte[] msg = Encoding.UTF8.GetBytes(reply);
        handler.Send(msg);

        if (ticker.IndexOf("<TheEnd>") > -1)
        {
            Console.WriteLine("Сервер завершил соединение с клиентом.");
            break;
        }

        handler.Shutdown(SocketShutdown.Both);
        handler.Close();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    Console.ReadLine();
}



string lastPrice(string ticker)
{
    string sqlExpression = $"SELECT * FROM Tickers WHERE Ticker = '{ticker}'";
    string? id = "";
    string? price = "";
    string? date = "";
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

            }
            else { return "none"; }
        }
        string sqlExpression1 = $"SELECT * FROM Prices WHERE TickerId = '{id}'";
        SqliteCommand command1 = new SqliteCommand(sqlExpression1, connection);
        using (SqliteDataReader reader = command1.ExecuteReader())
        {
            reader.Read();
            price = reader.GetValue(2).ToString();
            date = reader.GetValue(3).ToString();

        }
    }
    return price + " " + date;
}

