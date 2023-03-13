using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DiaDeFeira.API.Domain.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            CreatedAt = DateTime.Now;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Nome")]
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
