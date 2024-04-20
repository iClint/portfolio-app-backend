using MongoDB.Driver;
using portfolioAPI.GraphQl.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add MongoDB context
const string connectionString = "mongodb://api_user:c%5E7Ri%40Yn8J%23p@192.168.10.201:27017/?authSource=portfolio&directConnection=true";
const string databaseName = "portfolio";
builder.Services.AddSingleton(new MongoClient(connectionString));
builder.Services.AddScoped(provider =>
{
    var mongoClient = provider.GetRequiredService<MongoClient>();
    return mongoClient.GetDatabase(databaseName);
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();
    
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapGraphQL();
app.MapGet("/", () => "GraphQL server up");
app.Run();