using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DiaDeFeira.API.Domain.Entities
{
    public class Produto
    {
        public Produto()
        {
            CreatedAt = DateTime.UtcNow;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string IdCategoria { get; set; }
        [BsonElement("Nome")] public string NomeProduto { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
