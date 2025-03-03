using GameStore.Dtos;

namespace GameStore.Endpoints;

public static class GamesEndpoints
{

    const string getGameEndpoint = "GetGame";
    private static readonly List<GameDto> games = [
        new (1, "NFS", "Race", 500, new DateOnly(2000, 2, 10)),
    new (2, "NeoGeo", "Arcade", 400, new DateOnly(1997, 3, 2)),
    new (3, "GTA", "Open-World", 600, new DateOnly(2003, 12, 25))
    ];

    public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();

        group.MapGet("/", () => games);
        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.ID == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
            // games.Find(game => game.ID == id);

        }).WithName(getGameEndpoint);

        group.MapPost("/", (CreateGameDto newGame) =>
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

        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.ID == id); // confusion with the game
            if (index == -1) return Results.NotFound();
            games[index] = new(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.ID == id);
            return Results.NoContent();
        }
        );

        return group;
    }
}