using DiaDeFeira.API.Domain.Entities;
using MongoDB.Driver;

namespace DiaDeFeira.API.Infraestructure.Repositories.Base
{
    public class DBContext
    {
        public IMongoClient Client;
        public IMongoCollection<Categoria> Categorias;

        public DBContext(IConfiguration configuration)
        {
            Client = new MongoClient(configuration["Database:ConnectionString"]);

            var database = Client.GetDatabase(configuration["Database:Name"]);

            Categorias = database.GetCollection<Categoria>("categorias");
        }
    }
}
