using DiaDeFeira.API.Domain.Entities;

namespace DiaDeFeira.API.Domain.Dtos
{
    public class ListaEditDto
    {
        public string? NomeLista { get; set; }
        public List<ItemDto>? Itens { get; set; }
        public bool? Finalizada { get; set; }
    }
}
