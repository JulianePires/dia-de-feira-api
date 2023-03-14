using DiaDeFeira.API.Domain.Entities;
using MongoDB.Driver;

namespace DiaDeFeira.API.Infraestructure.Repositories.Base
{
    public class DBContext
    {
        public IMongoClient Client;
        public IMongoCollection<Categoria> Categorias;
        public IMongoCollection<Produto> Produtos;
        public IMongoCollection<Item> Itens;
        public IMongoCollection<Lista> Listas;
        public IMongoCollection<Usuario> Usuarios;
        public IMongoCollection<Historico> Historicos;

        public DBContext(IConfiguration configuration)
        {
            Client = new MongoClient(configuration["Database:ConnectionString"]);

            var database = Client.GetDatabase(configuration["Database:Name"]);

            Categorias = database.GetCollection<Categoria>("categorias");

            Produtos = database.GetCollection<Produto>("produtos");

            Itens = database.GetCollection<Item>("itens");

            Listas = database.GetCollection<Lista>("listas");

            Usuarios = database.GetCollection<Usuario>("usuarios");

            Historicos = database.GetCollection<Historico>("historicos");
        }
    }
}
