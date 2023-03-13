using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DiaDeFeira.API.Domain.Entities
{
    public class Lista
    {
        public Lista()
        {
            CreatedAt = DateTime.Now;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Nome")]
        public string? NomeLista { get; set; }
        [BsonElement("Itens")]
        public List<string> ItensId { get; set; } = new();
        [BsonElement("ValorTotal")]
        public double Total { get; set; } = 0.0;
        public bool Finalizada { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}
