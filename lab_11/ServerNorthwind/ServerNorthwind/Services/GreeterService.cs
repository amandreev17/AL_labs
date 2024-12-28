using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ServerNorthwind;
using Microsoft.Data.Sqlite;
using System;

namespace CrudGrpcApp.Services;

public class UserApiService : UserService.UserServiceBase
{
    static Shipper shipper = new Shipper();
    static List<Shipper> Shippers = shipper.FillShippers();
    int id = Shippers.Count();

    //static int id = 0;  // счетчик для генерации id
    //// условная база данных
    //static List<Shipper> Shippers = new() { new Shipper(++id, "Tom", "00"), new Shipper(++id, "Bob", "00") };
    public override Task<ListReply> ListUsers(Empty request, ServerCallContext context)
    {
        var listReply = new ListReply();    // определяем список
        // преобразуем каждый объект из списка users в объект UserReply
        var shipperList = Shippers.Select(item => new UserReply { Id = item.ShipperId, Name = item.CompanyName, Phone = item.Phone }).ToList();
        listReply.Shippers.AddRange(shipperList);
        return Task.FromResult(listReply);
    }
    // отправляем одного пользователя по id
    public override Task<UserReply> GetUser(GetUserRequest request, ServerCallContext context)
    {
        var shipper = Shippers.Find(u => u.ShipperId == request.Id);
        // если пользователь не найден, генерируем исключение
        if (shipper == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
        }
        UserReply shipperReply = new UserReply() { Id = shipper.ShipperId, Name = shipper.CompanyName, Phone = shipper.Phone };
        return Task.FromResult(shipperReply);
    }
    // добавление пользователя
    public override Task<UserReply> CreateUser(CreateUserRequest request, ServerCallContext context)
    {
        // формируем из данных объект User и добавляем его в список users
        var shipper = new Shipper(++id, request.Name, request.Phone);
        Shippers.Add(shipper);
        var reply = new UserReply() { Id = shipper.ShipperId, Name = shipper.CompanyName, Phone = shipper.Phone };
        return Task.FromResult(reply);
    }
    // обновление пользователя
    public override Task<UserReply> UpdateUser(UpdateUserRequest request, ServerCallContext context)
    {
        var shipper = Shippers.Find(u => u.ShipperId == request.Id);

        if (shipper == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
        }
        // обновляем даннные
        shipper.CompanyName = request.Name;
        shipper.Phone = request.Phone;

        var reply = new UserReply() { Id = shipper.ShipperId, Name = shipper.CompanyName, Phone = shipper.Phone };
        return Task.FromResult(reply);
    }
    // удаление пользователя
    public override Task<UserReply> DeleteUser(DeleteUserRequest request, ServerCallContext context)
    {
        var shipper = Shippers.Find(u => u.ShipperId == request.Id);

        if (shipper == null)
        {
            throw new RpcException(new Status(StatusCode.NotFound, "User not found"));
        }

        Shippers.Remove(shipper);
        var reply = new UserReply() { Id = shipper.ShipperId, Name = shipper.CompanyName, Phone = shipper.Phone };
        return Task.FromResult(reply);
    }

}

public class Shipper
{
    public int ShipperId { get; set; }
    public string CompanyName { get; set; }
    public string Phone { get; set; }
    public Shipper() { }
    public Shipper(int id, string name, string phone)
    {
        ShipperId = id;
        CompanyName = name;
        Phone = phone;
    }

    public List<Shipper> FillShippers()
    {
        List<Shipper> shippers = new List<Shipper>();
        string sqlExpression = "SELECT * FROM Shippers";
        using (var connection = new SqliteConnection("Data Source=/Users/olesaandreeva/Downloads/northwind.db"))
        {
            connection.Open();

            SqliteCommand command = new SqliteCommand(sqlExpression, connection);
            using (SqliteDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read())   // построчно считываем данные
                    {
                        int id = reader.GetValue(0).GetHashCode();
                        string? name = reader.GetValue(1).ToString();
                        string? phone = reader.GetValue(2).ToString();
                        shippers.Add(new Shipper(id, name, phone));
                    }
                }
            }
        }
        return shippers;
    }
}


