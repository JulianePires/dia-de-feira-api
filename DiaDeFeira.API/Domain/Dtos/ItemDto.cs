namespace DiaDeFeira.API.Domain.Dtos
{
    public class ItemDto
    {
        public string IdProduto { get; set; }
        public double Quantidade { get; set; } = 0.0;
        public double Preco { get; set; } = 0.0;
        public double Valor { get; set; }
        public bool Adicionado { get; set; } = false;
    }
}
