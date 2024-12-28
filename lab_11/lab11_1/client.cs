﻿using System.Text;
using System.Net;
using System.Net.Sockets;

try
{
    SendMessageFromSocket(11000);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    Console.ReadLine();
}

static void SendMessageFromSocket(int port)
{
    // Буфер для входящих данных
    byte[] bytes = new byte[1024];

    // Соединяемся с удаленным устройством

    // Устанавливаем удаленную точку для сокета
    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, port);

    Socket sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    // Соединяем сокет с удаленной точкой
    sender.Connect(ipEndPoint);

    Console.Write("Введите тикет: ");
    string message = Console.ReadLine();

    Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
    byte[] msg = Encoding.UTF8.GetBytes(message);

    // Отправляем данные через сокет
    sender.Send(msg);

    // Получаем ответ от сервера
    int bytesRec = sender.Receive(bytes);

    Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));

    // Используем рекурсию для неоднократного вызова SendMessageFromSocket()
    if (message.IndexOf("<TheEnd>") == -1)
        SendMessageFromSocket(port);

    // Освобождаем сокет
    sender.Shutdown(SocketShutdown.Both);
    sender.Close();
}