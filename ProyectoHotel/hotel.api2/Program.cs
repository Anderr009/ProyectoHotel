using Hotel.domain.Repository;
using Hotel.infraestructure.Interfaces;
using Hotel.infraestructure.Repositories;
using Hotel.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//dependencia del contexto 
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));
//dependencia repositorios
builder.Services.AddTransient<IRoomRepository, RoomRepository>();

//dependencia de los appsets
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
