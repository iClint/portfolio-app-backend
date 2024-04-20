using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using portfolioAPI.GraphQl.Types;

namespace portfolioAPI.GraphQl.Queries
{
    public class Query
    {
        private readonly IMongoCollection<Blog> _blogCollection;

        public Query(IMongoDatabase database)
        {
            _blogCollection = database.GetCollection<Blog>("blogEntries");
        }

        public async Task<List<Blog>> GetBlogEntries()
        {
            try
            {
                return await _blogCollection.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"An error occurred while retrieving blog entries: {ex.Message} {ex.StackTrace}");
                // You can throw an exception or return an empty list, depending on your error handling strategy
                throw; // Rethrow the exception to propagate it to the caller
            }
        }
    }
}