using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DiaDeFeira.API.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public Produto()
        {
            CreatedAt = DateTime.UtcNow;
        }
        public string IdCategoria { get; set; }
        [BsonElement("Nome")] public string NomeProduto { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
