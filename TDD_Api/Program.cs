using TDD.Application.Gamecube.Interfaces;
using TDD.Application.Gamecube.Services;
using TDD.Data.Interfaces;
using TDD.Data.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ✅ Your DI registrations
builder.Services.AddScoped<IGamecubeService, GamecubeService>();
builder.Services.AddScoped<IDataAccess, DataAccess>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
