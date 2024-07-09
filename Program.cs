using System.Reflection.Metadata.Ecma335;
using GameStore.Dtos;

// use f5 for debug
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

string getGameEndpoint = "GetGame";
List<GameDto> games = new()
{
    new (1, "NFS", "Race", 500, new DateOnly(2000, 2, 10)),
    new (2, "NeoGeo", "Arcade", 400, new DateOnly(1997, 3, 2)),
    new (3, "GTA", "Open-World", 600, new DateOnly(2003, 12, 25))
};

app.MapGet("/", () => "Welcome to the games store....!");
app.MapGet("games", () => games);
app.MapGet("games/{id}", (int id) => {
    GameDto? game=games.Find(game=>game.ID==id);
    
    return game is null? Results.NotFound():Results.Ok(game);
    // games.Find(game => game.ID == id);
    
}).WithName(getGameEndpoint);

app.MapPost("games", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute(getGameEndpoint, new { id = game.ID }, game);
});

app.MapPut("games/{id}", (int id, UpdateGameDto updatedGame) =>
{ 
    var index = games.FindIndex(game => game.ID == id); // confusion with the game
    if(index==-1) return Results.NotFound();
    games[index] = new(
        id,
        updatedGame.Name,
        updatedGame.Genre,
        updatedGame.Price,
        updatedGame.ReleaseDate
    );

    return Results.NoContent();
});

app.MapDelete("games/{id}", (int id) => 
{
    games.RemoveAll(game => game.ID==id);
    return Results.NoContent();
}
);

app.Run();





