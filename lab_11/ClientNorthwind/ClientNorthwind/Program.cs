using ClientNorthwind;
using Grpc.Core;
using Grpc.Net.Client;

{
    using var channel = GrpcChannel.ForAddress("http://localhost:5007");
    var client = new UserService.UserServiceClient(channel);

    ListReply shippers = await client.ListUsersAsync(new Google.Protobuf.WellKnownTypes.Empty());
    foreach (var shipper in shippers.Shippers)
    {
        Console.WriteLine($"{shipper.Id}. {shipper.Name} - {shipper.Phone}");
    }
}

Console.WriteLine("");

{
    using var channel = GrpcChannel.ForAddress("http://localhost:5007");
    var client = new UserService.UserServiceClient(channel);

    UserReply shipper = await client.GetUserAsync(new GetUserRequest { Id = 1 });
    Console.WriteLine($"{shipper.Id}. {shipper.Name} - {shipper.Phone}");
}

Console.WriteLine("");

{
    using var channel = GrpcChannel.ForAddress("http://localhost:5007");
    var client = new UserService.UserServiceClient(channel);

    try
    {
        
        UserReply shipper = await client.GetUserAsync(new GetUserRequest { Id = 4 });
        Console.WriteLine($"{shipper.Id}. {shipper.Name} - {shipper.Phone}");
    }
    catch (RpcException ex)
    {
        Console.WriteLine(ex.Status.Detail);
    }
}

Console.WriteLine("");

{
    using var channel = GrpcChannel.ForAddress("http://localhost:5007");
    var client = new UserService.UserServiceClient(channel);

    
    UserReply shipper = await client.CreateUserAsync(new CreateUserRequest { Name = "DHL", Phone = "(503) 555 - 9831" });
    Console.WriteLine($"{shipper.Id}. {shipper.Name} - {shipper.Phone}");
}

Console.WriteLine("");

{
    using var channel = GrpcChannel.ForAddress("http://localhost:5007");
    var client = new UserService.UserServiceClient(channel);

    try
    {
        UserReply shipper = await client.UpdateUserAsync(new UpdateUserRequest { Id = 1, Name = "Speedy Express", Phone = "(000) 005 - 0031" });
        Console.WriteLine($"{shipper.Id}. {shipper.Name} - {shipper.Phone}");
    }
    catch (RpcException ex)
    {
        Console.WriteLine(ex.Status.Detail);
    }
}

Console.WriteLine("");

{
    using var channel = GrpcChannel.ForAddress("http://localhost:5007");
    var client = new UserService.UserServiceClient(channel);

    try
    {
        // удаление объекта с id = 2
        UserReply shipper = await client.DeleteUserAsync(new DeleteUserRequest { Id = 4 });
        Console.WriteLine($"{shipper.Id}. {shipper.Name} - {shipper.Phone}");
    }
    catch (RpcException ex)
    {
        Console.WriteLine(ex.Status.Detail);
    }
}

{
    using var channel = GrpcChannel.ForAddress("http://localhost:5007");
    var client = new UserService.UserServiceClient(channel);

    ListReply shippers = await client.ListUsersAsync(new Google.Protobuf.WellKnownTypes.Empty());
    foreach (var shipper in shippers.Shippers)
    {
        Console.WriteLine($"{shipper.Id}. {shipper.Name} - {shipper.Phone}");
    }
}
