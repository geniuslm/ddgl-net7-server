
using MongoDB.Driver;
using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace 命名空间Mongo类型;


public class 用户蓝图
{
    //使用 [BsonId] 进行批注，以将此属性指定为文档的主键。
    //使用 [BsonRepresentation(BsonType.ObjectId)] 进行批注，以允许将参数作为类型 string 
    //而非 [BsonRepresentation(BsonType.ObjectId)] 结构传递。 Mongo 处理从 string 到 ObjectId 的转换。
    //属性使用 [BsonElement] 特性进行批注。 Name 的属性值表示 MongoDB 集合中的属性名称 也就是加在mongo上的值。
    //属性使用[JsonPropertyName] 属性的 Name 值表示 Web API 的序列化 JSON 响应中的属性名称 也就是传上去的值。
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? ID { get; set; }
    public string? 用户名 { get; set; } = null!;
    public string? 密码 { get; set; } = null!;
    public string? 手机号 { get; set; } = null!;
    public Int32? __v { get; set; } = 0;
}
