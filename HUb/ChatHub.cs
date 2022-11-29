using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;
using 命名空间Mongo类型;


namespace 命名空间Hub;
public class api中心Hub : Hub
{
    public static string mongodb地址="mongodb://geniuslmt:geniuslmt@120.53.103.135:27017";

    public IMongoCollection<用户蓝图> mongo用户集合 = new MongoClient(mongodb地址)
       .GetDatabase("data")
       .GetCollection<用户蓝图>("用户集合");

    //默认情况就是方法的名称 [HubMethodName("也可以命名")]
    public async Task 测试消息(string user, string message)
    {
        Console.WriteLine("传来的东西" + user + message);
        await Clients.All.SendAsync("回传消息", ("事实的消息: " + user), message);
    }
    //用户 获取
    public async Task 获取用户列表(string 客户端用户)
    {
        var 用户列表 = await mongo用户集合.Find(_ => true).ToListAsync();
        Console.WriteLine("用户:"+客户端用户+" 获取" + 用户列表);
        await Clients.All.SendAsync("用户列表", 用户列表);
    }
    //用户 增
    public async Task 添加用户(用户蓝图 用户)
    {
        Console.WriteLine("用户:"+用户.用户名+" 已添加");
         await mongo用户集合.InsertOneAsync(用户);
        //Console.WriteLine("用户:"+用户.用户名+" 已添加");
        await Clients.All.SendAsync("添加用户", 用户);
    }
}
