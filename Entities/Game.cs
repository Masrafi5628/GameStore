using GameStore.Entities;
using Microsoft.AspNetCore.SignalR;

namespace GameStore;

public class Game
{
    public int ID { get; set; }
    public required int Name { get; set; }
    public int GenreID { get; set; }
    public Genre? Genre { get; set; }

    public decimal Price {get; set;}
    public DateOnly ReleaseDate {get;set;}
}
