using Microsoft.EntityFrameworkCore;
using TaskList.Api.Data;
using TaskList.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskListDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();
