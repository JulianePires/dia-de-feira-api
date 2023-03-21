using DiaDeFeira.API.Domain.Entities;
using MongoDB.Driver;

namespace DiaDeFeira.API.Helpers
{
    public static class RepositoryHelper
    {
        public static FilterDefinition<T>? FiltraPorId<T>(string id)
            => Builders<BaseEntity>.Filter.Eq(x => x.Id!, id) as FilterDefinition<T>;
    }
}
