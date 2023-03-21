using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DiaDeFeira.API.Domain.Entities
{
    public class Historico : BaseEntity
    {
        public Historico() { }
        public string IdUsuario { get; set; }
        [BsonElement("Listas")]
        public List<string> ListasId { get; set; } = new();
    }
}
