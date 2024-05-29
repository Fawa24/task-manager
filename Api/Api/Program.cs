using Api.Core.Domain.RepositoryContracts;
using Api.Core.ServiceContracts;
using Api.Core.Services;
using Api.Infrastructure.DBContext;
using Api.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddDbContext<TaskDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();
app.MapControllers();
app.UseCors(origin =>
{
	origin.AllowAnyOrigin();
});

app.Run();
