using MongoDB.Driver;

namespace Exercises.API.Utilitities
{
    public static class MongoUtilities<T>
    {
        public static IMongoCollection<T> GetCollection(string collectionName, IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            return database.GetCollection<T>(configuration.GetValue<string>($"DatabaseSettings:{collectionName}"));
        } 
    }
}
