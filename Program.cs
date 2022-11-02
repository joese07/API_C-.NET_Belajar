using API.Context;
using API.Repositories.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<DivisionRepository>();
builder.Services.AddScoped<DepartementRepository>();

builder.Services.AddControllers();

builder.Services.AddDbContext<MyContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

