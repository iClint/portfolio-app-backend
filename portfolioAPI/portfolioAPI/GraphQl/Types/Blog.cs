using MongoDB.Bson;

namespace portfolioAPI.GraphQl.Types;

public class Blog
{
    public ObjectId _id { get; set; }

    public int BlogId { get; set; }
    
    public string Date { get; set; } 
        
    public string Title { get; set; }

    public string Content { get; set; }
}
