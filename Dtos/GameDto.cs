using System.ComponentModel.DataAnnotations;
namespace GameStore.Dtos;

public record class GameDto(
    int ID, 
    [Required][StringLength(100)] string Name,
    string Genre,
    [Required] decimal Price,
    [Required] DateOnly ReleaseDate
);
