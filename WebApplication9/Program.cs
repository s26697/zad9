using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;
using WebApplication9.Repositories;
using WebApplication9.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString(
        "DefaultConnection")));
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();