using MongoDB.Driver;
using portfolioAPI.GraphQl.Types;


namespace portfolioAPI.MongDb;

public class BlogContext
{
    private readonly IMongoDatabase _database;

    public BlogContext(string connectionString, string databaseName)
    {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
    }

    public IMongoCollection<Blog> BlogEntries => _database.GetCollection<Blog>("BlogEntries");
}
