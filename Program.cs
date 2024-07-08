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
app.MapGet("games/{id}", (int id) => games.Find(game => game.ID == id)).WithName(getGameEndpoint);

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

app.Run();
