using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DiaDeFeira.API.Domain.Entities
{
    public class Item
    {
        public Item()
        {
            CreatedAt = DateTime.UtcNow;
            Valor = Preco * Quantidade;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string IdProduto { get; set; }
        public double Quantidade { get; set; } = 0.0;
        public double Preco { get; set; } = 0.0;
        public double Valor { get; set; }
        public bool Adicionado { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}
