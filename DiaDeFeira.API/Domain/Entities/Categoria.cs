using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DiaDeFeira.API.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public Categoria()
        {
            CreatedAt = DateTime.UtcNow;
        }
        [BsonElement("Nome")] public string NomeCategoria { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
