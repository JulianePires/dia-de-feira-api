using DiaDeFeira.API.Domain.Dtos;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DiaDeFeira.API.Domain.Entities
{
    public class Lista : BaseEntity
    {
        public Lista()
        {
            CreatedAt = DateTime.Now;
            Itens.Select(x => x.Preco * x.Quantidade);
        }
        [BsonElement("Nome")]
        public string NomeLista { get; set; }
        public List<ItemDto> Itens { get; set; } = new();
        [BsonElement("ValorTotal")]
        public double Total { get; set; } = 0.0;
        public bool Finalizada { get; set; } = false;
        public DateTime CreatedAt { get; set; }
    }
}
