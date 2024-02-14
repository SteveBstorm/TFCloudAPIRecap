using Microsoft.Data.SqlClient;
using System.Text.Json.Serialization;
using TFCloudAPIRecap.DAL.Interfaces;
using TFCloudAPIRecap.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(sp => 
    new SqlConnection(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IPokemonRepo, PokemonRepo>();
builder.Services.AddScoped<ITypeRepo, TypeRepo>();
builder.Services.AddScoped<IType_PokemonRepo, Type_PokemonRepo>();

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
