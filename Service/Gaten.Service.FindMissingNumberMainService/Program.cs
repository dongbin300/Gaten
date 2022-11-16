using Gaten.Service.FindMissingNumberMainService.Contexts;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ServerInfoDb>(opt => opt.UseInMemoryDatabase("ServerInfo"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/status", async (ServerInfoDb db) => await db.Initialize().Data.ToListAsync());

app.Run();
