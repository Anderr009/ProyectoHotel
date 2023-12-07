using Hotel.infraestructure.Context;
using Hotel.infraestructure.Interfaces;
using Hotel.infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Hotel.Ioc.Dependencia;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HotelContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));
//builder.Services.AddTransient<IFloorRepository, FloorRepository>();
//builder.Services.AddTransient<IRolUserRepository, RolUserRepository>();

//Dependecias del modulo de floor //
builder.Services.AddFloorDependecy();


//Dependencias del modulo de User //
builder.Services.AddRolUserDependecy();



//builder.Services.AddTransient<IReceptionRepository, ReceptionRepository>();
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
