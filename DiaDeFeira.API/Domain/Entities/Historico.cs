using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DiaDeFeira.API.Domain.Entities
{
    public class Historico
    {
        public Historico() { }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string IdUsuario { get; set; }
        [BsonElement("Listas")]
        public List<string> ListasId { get; set; } = new();
    }
}
