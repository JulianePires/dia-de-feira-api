using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiaDeFeira.API.Domain.Entities
{
    public class Categoria
    {
        public Categoria()
        {
            CreatedAt = DateTime.UtcNow;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Nome")] public string NomeCategoria { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}
