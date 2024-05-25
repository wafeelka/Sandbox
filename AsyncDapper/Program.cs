using AsyncDapper;
using AsyncDapper.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddScoped<BaseRepository<User>, UserRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
