using Api.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TaskDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
