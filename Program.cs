using System.Reflection.Metadata.Ecma335;
using GameStore.Dtos;
using GameStore.Endpoints;
using GameStore.Data;

// use f5 for debug
var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("GameStore");
builder.Services.AddSqlite<GameStoreContext>(connString);
var app = builder.Build();
app.MapGet("/", () => "Welcome to the games store....!");

app.MapGameEndpoints();


app.Run();





