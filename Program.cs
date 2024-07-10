using System.Reflection.Metadata.Ecma335;
using GameStore.Dtos;
using GameStore.Endpoints;

// use f5 for debug
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.MapGet("/", () => "Welcome to the games store....!");

app.MapGameEndpoints();

app.Run();





