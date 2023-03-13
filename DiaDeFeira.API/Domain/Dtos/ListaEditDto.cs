using DiaDeFeira.API.Domain.Entities;

namespace DiaDeFeira.API.Domain.Dtos
{
    public class ListaEditDto
    {
        public string? NomeLista { get; set; }
        public List<string>? ItensId { get; set; }
        public bool Finalizada { get; set; }
    }
}
